using Dacs7;
using Dacs7.Domain;
using Microsoft.Extensions.Configuration;
using Papper;
using Papper.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using webpac.Interfaces;

namespace webpac.Services
{
    public class MappingService : IMappingService
    {
        #region Fields
        private ReaderWriterLockSlim _connectionLock = new ReaderWriterLockSlim();
        private Dacs7Client _client = new Dacs7Client();
        private static PlcDataMapper _papper;
        private string _connectionString = string.Empty;
        private bool _disposed; // to detect redundant calls
        private bool _connectOnStartup;
        private IRuntimeCompilerService _rumtimeCompiler;
        private readonly ConcurrentDictionary<string,SubscriptionTree> _subscritions = new ConcurrentDictionary<string,SubscriptionTree>();

        private class SubscriptionTree
        {
            private readonly OnDataChangeEventHandler _dataChanged;
            public string Name { get; set; }
            public ConcurrentDictionary<string, SubscriptionTree> Childs { get; private set; }
            public ConcurrentDictionary<string, object> Subscribers { get; private set; }
            private int _subscriptions = 0;

            private SubscriptionTree()
            {
                Subscribers = new ConcurrentDictionary<string, object>();
                Childs = new ConcurrentDictionary<string, SubscriptionTree>();
            }


            internal SubscriptionTree(OnDataChangeEventHandler dataChanged) : this()
            {
                _dataChanged = dataChanged;
            }

            public IEnumerable<string> GetSubscribersFor(IEnumerable<IEnumerable<string>> vars)
            {
                var subscribers = new List<string>();
                foreach (var varPath in vars)
                    subscribers.AddRange(GetSubscribersFor(varPath));
                return subscribers;
            }

            private IEnumerable<string> GetSubscribersFor(IEnumerable<string> variablePath)
            {
                var subscribers = new List<string>();
                if (variablePath.Any())
                {
                    foreach (var child in Childs.Where(item => item.Key == variablePath.FirstOrDefault()))
                    {
                        subscribers.AddRange(child.Value.GetSubscribersFor(variablePath.Skip(1)));
                    }
                }
                else
                    return Subscribers.Keys;
                return subscribers;
            }

            public int AddSubscribtion(string id, IEnumerable<IEnumerable<string>> vars)
            {
                var updated = 0;
                foreach (var variablePath in vars)
                {
                    if (UpdateSubscribtion(id, variablePath, false, ref _subscriptions))
                        updated++;
                }
                if (_subscriptions > 0 && _dataChanged != null)
                    _papper.SubscribeDataChanges(Name, OnDataChanged);
                return updated;
            }

            public int RemoveSubscription(string id, IEnumerable<IEnumerable<string>> vars)
            {
                var updated = 0;
                foreach (var variablePath in vars)
                {
                    if (UpdateSubscribtion(id, variablePath, true, ref _subscriptions))
                        updated++;
                }

                if(_subscriptions <= 0 && _dataChanged != null)
                    _papper.UnsubscribeChanges(Name, OnDataChanged);
                return updated;
            }

            public void RemoveSubscription(string id)
            {
                RemoveSubscription(id, ref _subscriptions);
                if (_subscriptions <= 0 && _dataChanged != null)
                    _papper.UnsubscribeChanges(Name, OnDataChanged);
            }

            private bool UpdateSubscribtion(string id, IEnumerable<string> variablePath, bool remove, ref int subscriptions)
            {
                if (variablePath.Any())
                {
                    var key = variablePath.First();
                    SubscriptionTree entry;
                    if (!Childs.TryGetValue(key, out entry) && !remove)
                    {
                        entry = new SubscriptionTree();
                        if (!Childs.TryAdd(key, entry))
                            entry = Childs[key];
                    }
                    return entry != null ? entry.UpdateSubscribtion(id, variablePath.Skip(1), remove, ref subscriptions) : false;
                }
                else
                {
                    if(remove)
                    {
                        object o;
                        if(Subscribers.TryRemove(id, out o))
                        {
                            Interlocked.Decrement(ref subscriptions);
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        if(Subscribers.TryAdd(id, null))
                        {
                            Interlocked.Increment(ref subscriptions);
                            return true;
                        }
                        return false;
                    }
                }
            }

            private void RemoveSubscription(string id, ref int subscriptions)
            {
                object o;
                if (Subscribers.TryRemove(id, out o))
                    Interlocked.Decrement(ref subscriptions);
                foreach (var child in Childs)
                    child.Value.RemoveSubscription(id, ref subscriptions);
            }

            private void OnDataChanged(object sender, PlcNotificationEventArgs e)
            {
                if(_dataChanged != null)
                {
                    var changed = new List<SubscriptionInformationPackage>();
                    foreach (var changes in e)
                    {
                        changed.Add(new SubscriptionInformationPackage
                        {
                            Mapping = Name,
                            Variable = changes.Key,
                            Value = changes.Value,
                            Subscribers = GetSubscribersFor(changes.Key.Split('.'))
                        });
                    }

                    _dataChanged(changed);
                }
            }
        }


        public event OnDataChangeEventHandler DataChanged;

        #endregion


        public MappingService(IRuntimeCompilerService rumtimeCompiler)
        {
            _rumtimeCompiler = rumtimeCompiler;
        }

        ~MappingService()
        {
            Dispose(false);
        }

        #region IService Interface
        public void Configure(IConfigurationSection config)
        {
            _connectionString = config.Get<string>("ConnectionString");
            _connectOnStartup = config.Get<bool>("ConnectOnStartup");
        }

        public void Init()
        {
            if (_connectOnStartup)
                OpenConnection();
        }

        public void Release()
        {
            CloseConnection();
        }
        #endregion

        #region IDispasble Implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_client != null)
                    {
                        _client.Disconnect();
                        _client = null;
                    }

                    if (_connectionLock != null)
                    {
                        _connectionLock.Dispose();
                        _connectionLock = null;
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            _disposed = true;

            // If it is available, make the call to the
            // base class's Dispose(Boolean) method
            // base.Dispose(disposing);
        }
        #endregion

        private void OpenConnection()
        {
            _connectionLock.EnterWriteLock();
            try
            {
                _client.Connect(_connectionString);
                if (_client.IsConnected && (_papper == null || _papper.PduSize > _client.PduSize)) //TODO
                {
                    var pduSize = _client.PduSize;
                    _papper = new PlcDataMapper(pduSize);
                    _papper.OnRead += OnRead;
                    _papper.OnWrite += OnWrite;

                    foreach (var type in _rumtimeCompiler.GetTypes()
                                         .Where(type => type.GetTypeInfo()
                                                            .GetCustomAttribute<MappingAttribute>() != null))
                    {
                        _papper.AddMapping(type);
                    }
                }
            }
            finally
            {
                _connectionLock.ExitWriteLock();
            }
        }

        private void CloseConnection()
        {
            _connectionLock.EnterWriteLock();
            try
            {
                _client.Disconnect();
            }
            finally
            {
                _connectionLock.ExitWriteLock();
            }
        }


        /// <summary>
        /// This method starts a request to the plc to get information of the loaded data blocks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetDataBlocks()
        {
            return _client.GetBlocksOfType(PlcBlockType.Db).Select(bi => $"DB{bi.Number}");
        }

        /// <summary>
        /// This method returns all Symbols (e.g. M, E , A ,T ,..) which are registered
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSymbols()
        {
            return _papper?.Mappings ?? new List<string>();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetAddresses(string mapping, params string[] variables)
        {
            //TODO resolve correct
            var kvp = new Dictionary<string, string>();
            foreach (var variable in variables)
            {
                var address = _papper.GetAddressOf(mapping, variable);
                var bitOffset = address.Offset.Bits > -1 ? address.Offset.Bits : 0;
                var bitSize = address.Size.Bits > -1 ? address.Size.Bits : 0;
                kvp.Add(variable, $"{address.Selector},{address.Offset.Bytes}.{bitOffset},{address.Size.Bytes}.{bitSize}");
            }
            return kvp;
        }

        /// <summary>
        /// Read the given variables from the plc
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="vars"></param>
        /// <returns></returns>
        public Dictionary<string, object> Read(string mapping, params string[] vars)
        {
            return _papper.Read(mapping, vars);
        }

        /// <summary>
        /// Read the given variables from the plc
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="vars"></param>
        /// <returns></returns>
        public Dictionary<string, object> ReadAbs(string mapping, params string[] vars)
        {
            return _papper.ReadAbs(mapping, vars);
        }

        /// <summary>
        /// Write the given values to the plc
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool Write(string mapping, Dictionary<string, object> values)
        {
            return _papper.Write(mapping, values);
        }

        /// <summary>
        /// Write the given values to the plc
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool WriteAbs(string mapping, Dictionary<string, object> values)
        {
            return _papper.WriteAbs(mapping, values);
        }


        public bool SubscribeChanges(string subscriberId, string mapping, params string[] vars)
        {
            if (DataChanged == null)
                throw new NullReferenceException("DataChanged");
            var enumerable = new List<List<string>>();
            foreach (var variable in vars)
                enumerable.Add(variable.Split('.').ToList());

            SubscriptionTree item;
            if(!_subscritions.TryGetValue(mapping, out item))
            {
                item = new SubscriptionTree(DataChanged);
                if (!_subscritions.TryAdd(mapping, item))
                    item = _subscritions[mapping];
            }

            return item.AddSubscribtion(subscriberId, enumerable) == vars.Length;
        }


        public bool UnsubscribeChanges(string subscriberId, string mapping, params string[] vars)
        {
            var enumerable = new List<List<string>>();
            foreach (var variable in vars)
                enumerable.Add(variable.Split('.').ToList());
            SubscriptionTree item;
            if (!_subscritions.TryGetValue(mapping, out item))
                return false;
            return item.RemoveSubscription(subscriberId, enumerable) == vars.Length;
        }

        public void RemoveSubscriptionsForId(string subscriberId)
        {
            foreach (var item in _subscritions.Values)
                item.RemoveSubscription(subscriberId);
        }

        #region Helper



        private bool OnWrite(string selector, int offset, byte[] data, byte bitMask = 0)
        {
            var ad = ExtractAreaData(selector);
            switch (ad.Item1)
            {
                case PlcArea.DB:
                    try
                    {
                        _client.WriteAny(PlcArea.DB, offset, data, new[] { data.Length, ad.Item2 });
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private byte[] OnRead(string selector, int offset, int length)
        {
            var ad = ExtractAreaData(selector);
            switch (ad.Item1)
            {
                case PlcArea.DB:
                    return _client.ReadAny(PlcArea.DB, offset, typeof(byte), new[] { length, ad.Item2 }) as byte[];
                default:
                    throw new NotImplementedException();
            }
        }

        private static Tuple<PlcArea, int> ExtractAreaData(string selector)
        {
            int blockNumber = 0;
            PlcArea area;
            if (!Enum.TryParse(selector.Substring(0, 2), out area))
                throw new ArgumentException($"Invalid selector {selector} given! Could not determine area");

            if (area == PlcArea.DB)
            {
                if (!int.TryParse(selector.Substring(2), out blockNumber))
                    throw new ArgumentException($"Invalid selector {selector} given! Could not pars block number");
            }
            return new Tuple<PlcArea, int>(area, blockNumber);
        }

        private bool EnsureConnection()
        {
            _connectionLock.EnterUpgradeableReadLock();
            try
            {
                if (!_client.IsConnected)
                {
                    OpenConnection();
                    if (!_client.IsConnected)
                        throw new PlcConnectionException();
                }
                return _papper != null && _client.IsConnected;
            }
            finally
            {
                _connectionLock.ExitUpgradeableReadLock();
            }
        }

        #endregion
    }

}
