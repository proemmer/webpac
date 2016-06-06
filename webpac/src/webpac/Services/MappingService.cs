﻿using Dacs7;
using Dacs7.Domain;
using Microsoft.Extensions.Configuration;
using Papper;
using Papper.Attributes;
using Papper.Helper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using webpac.Interfaces;

namespace webpac.Services
{
    /// <summary>
    /// This service handles the connection to the plc
    /// </summary>
    public class MappingService : IMappingService
    {
        #region Fields
        private const string ADDRESS_PREFIX = "$ABSSYMBOLS$_";
        private ReaderWriterLockSlim _connectionLock = new ReaderWriterLockSlim();
        private Dacs7Client _client = new Dacs7Client();
        private static ReaderWriterLockSlim _papperLock = new ReaderWriterLockSlim();
        private static PlcDataMapper _papper;
        private string _connectionString = string.Empty;
        private bool _disposed; // to detect redundant calls
        private bool _connectOnStartup;
        private IRuntimeCompilerService _rumtimeCompiler;
        private readonly ConcurrentDictionary<string,SubscriptionTree> _subscritions = new ConcurrentDictionary<string,SubscriptionTree>();
        #endregion

        #region Helper class for Subscriptions
        private class SubscriptionTree
        {
            private readonly OnDataChangeEventHandler _dataChanged;
            public string Name { get; private set; }
            public bool IsRaw { get; private set; }
            public ConcurrentDictionary<string, SubscriptionTree> Childs { get; private set; }
            public ConcurrentDictionary<string, object> Subscribers { get; private set; }
            private int _subscriptions = 0;

            private SubscriptionTree()
            {
                Subscribers = new ConcurrentDictionary<string, object>();
                Childs = new ConcurrentDictionary<string, SubscriptionTree>();
            }


            internal SubscriptionTree(string name, OnDataChangeEventHandler dataChanged, bool isRaw = false) : this()
            {
                Name = name;
                IsRaw = isRaw;
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
                        subscribers.AddRange(child.Value.GetSubscribersFor(variablePath.Skip(1)));
                }
                else
                    return Subscribers.Keys;
                return subscribers;
            }

            public int AddRawSubscription(string id, IEnumerable<string> adresses)
            { 
                var updated = 0;
                var varNames = new List<string>();
                foreach (var address in adresses)
                {
                    if (UpdateSubscribtion(id, new List<string> { address }, false, ref _subscriptions))
                    {
                        updated++;
                    }
                }
                if (_subscriptions > 0 && _dataChanged != null)
                {
                    using (var guard = new ReaderGuard(_papperLock))
                    {
                        _papper.SubscribeRawDataChanges(Name, OnDataChanged);
                        _papper.SetRawActiveState(true, Name, adresses.ToArray());
                    }
                }
                return updated;
            }

            public int RemoveRawSubscription(string id, IEnumerable<string> adresses)
            {
                var updated = 0;
                foreach (var address in adresses)
                {
                    if (UpdateSubscribtion(id, new List<string> { address }, true, ref _subscriptions))
                        updated++;
                }

                if (_subscriptions <= 0 && _dataChanged != null)
                {
                    using (var guard = new ReaderGuard(_papperLock))
                    {
                        _papper.SetRawActiveState(false, Name, adresses.ToArray());
                        _papper.UnsubscribeRawDataChanges(Name, OnDataChanged);
                    }
                }
                return updated;
            }

            public int AddSubscribtion(string id, IEnumerable<IEnumerable<string>> vars)
            {
                var updated = 0;
                var varNames = new List<string>();
                foreach (var variablePath in vars)
                {
                    if (UpdateSubscribtion(id, variablePath, false, ref _subscriptions))
                    {
                        varNames.Add(variablePath.Aggregate((a, b) => $"{a}.{b}"));
                        updated++;
                    }
                }
                if (_subscriptions > 0 && _dataChanged != null)
                {
                    using (var guard = new ReaderGuard(_papperLock))
                    {
                        _papper.SetActiveState(true, Name, varNames.ToArray());
                        _papper.SubscribeDataChanges(Name, OnDataChanged);
                    }
                }
                return updated;
            }

            public int RemoveSubscription(string id, IEnumerable<IEnumerable<string>> vars)
            {
                var updated = 0;
                var varNames = new List<string>();
                foreach (var variablePath in vars)
                {
                    if (UpdateSubscribtion(id, variablePath, true, ref _subscriptions))
                    {
                        varNames.Add(variablePath.Aggregate((a, b) => $"{a}.{b}"));
                        updated++;
                    }
                }

                if (_subscriptions <= 0 && _dataChanged != null)
                {
                    using (var guard = new ReaderGuard(_papperLock))
                    {
                        _papper.SetActiveState(false, Name, varNames.ToArray());
                        _papper.UnsubscribeDataChanges(Name, OnDataChanged);
                    }
                }
                return updated;
            }

            public void RemoveSubscription(string id)
            {
                RemoveSubscription(id, ref _subscriptions);
                if (_subscriptions <= 0 && _dataChanged != null)
                {
                    using (var guard = new ReaderGuard(_papperLock))
                        _papper.UnsubscribeDataChanges(Name, OnDataChanged);
                }
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
                    if (remove)
                    {
                        object o;
                        if (Subscribers.TryRemove(id, out o))
                        {
                            Interlocked.Decrement(ref subscriptions);
                            return true;
                        }
                        return false;
                    }
                    else
                    {
                        if (Subscribers.TryAdd(id, null))
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
                if (_dataChanged != null)
                {
                    var changed = new List<SubscriptionInformationPackage>();
                    foreach (var changes in e)
                    {
                        changed.Add(new SubscriptionInformationPackage
                        {
                            Mapping = Name,
                            Variable = changes.Key,
                            Value = changes.Value,
                            IsRaw = IsRaw,
                            Subscribers = GetSubscribersFor(changes.Key.Split('.'))
                        });
                    }

                    _dataChanged(changed);
                }
            }
        }
        #endregion

        public event OnDataChangeEventHandler DataChanged;

        /// <summary>
        /// Constructor with injection
        /// </summary>
        /// <param name="rumtimeCompiler"></param>
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

                    //Remove handles if exists
                    var handler = DataChanged;
                    if (handler != null)
                        DataChanged -= handler;

                    ClosePapperIfExits();

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

        /// <summary>
        /// Open connection to plc
        /// </summary>
        private void OpenConnection()
        {
            using (var guard = new WriterGuard(_connectionLock))
            { 
                _client.Connect(_connectionString);
                //If papper was null or pdu size of the client is smaller then the last detected
                if (_client.IsConnected && (_papper == null || _papper.PduSize > _client.PduSize))
                {
                    var pduSize = _client.PduSize;
                    
                    using (var papperGuard = new WriterGuard(_papperLock))
                    {
                        ClosePapperIfExits();
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
            }
        }

        /// <summary>
        /// Close connection to plc
        /// </summary>
        private void CloseConnection()
        {
            using (var guard = new WriterGuard(_connectionLock))
                _client.Disconnect();
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
            return _papper?.Mappings.Where(x => !x.StartsWith("$ABSSYMBOLS$")) ?? new List<string>();
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

        /// <summary>
        /// Subscribe to data changes
        /// </summary>
        /// <param name="subscriberId">client id from signalR</param>
        /// <param name="mapping">mapping to subscribe</param>
        /// <param name="vars">variables to detect</param>
        /// <returns></returns>
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
                item = new SubscriptionTree(mapping, DataChanged);
                if (!_subscritions.TryAdd(mapping, item))
                    item = _subscritions[mapping];
            }

            return item.AddSubscribtion(subscriberId, enumerable) == vars.Length;
        }

        /// <summary>
        /// Unsubscribe from data changes
        /// </summary>
        /// <param name="subscriberId">client id from signalR</param>
        /// <param name="mapping">mapping to subscribe</param>
        /// <param name="vars">variables to detect</param>
        /// <returns></returns>
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

        /// <summary>
        /// Subscribe to raw data changes
        /// </summary>
        /// <param name="subscriberId">client id from signalR</param>
        /// <param name="mapping">mapping to subscribe</param>
        /// <param name="vars">variables to detect</param>
        /// <returns></returns>
        public bool SubscribeRawChanges(string subscriberId, string area, params string[] adresses)
        {
            if (DataChanged == null)
                throw new NullReferenceException("DataChanged");

            SubscriptionTree item;
            var key = $"{ADDRESS_PREFIX}{area}";
            if (!_subscritions.TryGetValue(key, out item))
            {
                item = new SubscriptionTree(area, DataChanged, true);
                if (!_subscritions.TryAdd(key, item))
                    item = _subscritions[key];
            }

            return item.AddRawSubscription(subscriberId, adresses) == adresses.Length;
        }

        /// <summary>
        /// Unsubscribe from raw data changes
        /// </summary>
        /// <param name="subscriberId">client id from signalR</param>
        /// <param name="mapping">mapping to subscribe</param>
        /// <param name="vars">variables to detect</param>
        /// <returns></returns>
        public bool UnsubscribeRawChanges(string subscriberId, string area, params string[] adresses)
        {
            var enumerable = new List<List<string>>();
            SubscriptionTree item;
            var key = $"{ADDRESS_PREFIX}{area}";
            if (!_subscritions.TryGetValue(key, out item))
                return false;
            return item.RemoveRawSubscription(subscriberId, adresses) == adresses.Length;
        }

        /// <summary>
        /// Remove all subscribtions for the given id
        /// </summary>
        /// <param name="subscriberId">client id from signalR</param>
        public void RemoveSubscriptionsForId(string subscriberId)
        {
            foreach (var item in _subscritions.Values)
                item.RemoveSubscription(subscriberId);
        }

        #region Helper


        /// <summary>
        /// write event from papper
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="offset"></param>
        /// <param name="data"></param>
        /// <param name="bitMask"></param>
        /// <returns></returns>
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
                case PlcArea.FB:
                    try
                    {
                        _client.WriteAny(PlcArea.FB, offset, data, new[] { data.Length });
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case PlcArea.QB:
                    try
                    {
                        _client.WriteAny(PlcArea.QB, offset, data, new[] { data.Length });
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case PlcArea.IB:
                    try
                    {
                        _client.WriteAny(PlcArea.IB, offset, data, new[] { data.Length });
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

        /// <summary>
        /// Read event from papper
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] OnRead(string selector, int offset, int length)
        {
            var ad = ExtractAreaData(selector);
            switch (ad.Item1)
            {
                case PlcArea.DB:
                    return _client.ReadAny(PlcArea.DB, offset, typeof(byte), new[] { length, ad.Item2 }) as byte[];
                case PlcArea.FB:
                    return _client.ReadAny(PlcArea.FB, offset, typeof(byte), new[] { length }) as byte[];
                case PlcArea.QB:
                    return _client.ReadAny(PlcArea.QB, offset, typeof(byte), new[] { length }) as byte[];
                case PlcArea.IB:
                    return _client.ReadAny(PlcArea.IB, offset, typeof(byte), new[] { length }) as byte[];
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Extract the plcArea from the given selector
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validate a connection, if not connected, try connect
        /// </summary>
        /// <returns></returns>
        private bool EnsureConnection()
        {
            using (var guard = new UpgradeableGuard(_connectionLock))
            {
                if (!_client.IsConnected)
                {
                    OpenConnection();
                    if (!_client.IsConnected)
                        throw new PlcConnectionException();
                }
                return _papper != null && _client.IsConnected;
            }
        }

        /// <summary>
        /// If papper is existing, release the events and set it to null
        /// </summary>
        private void ClosePapperIfExits()
        {
            if (_papper != null)
            {
                using (var papperGuard = new WriterGuard(_papperLock))
                {
                    ClosePapperIfExits();
                    _papper.OnRead -= OnRead;
                    _papper.OnWrite -= OnWrite;
                    _papper = null;
                }
            }
        }


        #endregion
    }

}
