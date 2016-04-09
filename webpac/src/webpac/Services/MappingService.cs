using InacS7Core;
using InacS7Core.Domain;
using Microsoft.Extensions.Configuration;
using Papper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using webpac.Interfaces;

namespace webpac.Services
{
    public class MappingService : IMappingService
    {
        #region Fields
        private ReaderWriterLockSlim _connectionLock = new ReaderWriterLockSlim();
        private InacS7CoreClient _client = new InacS7CoreClient();
        private static PlcDataMapper _papper;
        private string _connectionString = string.Empty;
        private bool _disposed; // to detect redundant calls
        private bool _connectOnStartup;
        #endregion

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
            if(_connectOnStartup)
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
                if (_client.IsConnected && (_papper == null /*&& _papper.PduSize > _client.PduSize*/)) //TODO
                {
                    var pduSize = _client.PduSize;
                    _papper = new PlcDataMapper(pduSize);
                    _papper.OnRead += OnRead;
                    _papper.OnWrite += OnWrite;
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

        public IEnumerable<string> GetSymbolicBlocks()
        {
            //return _papper.Mappings;
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetDataBlocks()
        {
            return _client.GetBlocksOfType(PlcBlockType.Db).Select( bi => $"DB{bi.Number}");
        }

        public IEnumerable<string> GetSymbols()
        {
            //return _papper.GetVariablesOf("Symbols");
            throw new NotImplementedException();
        }

        public string GetAddresses(string mapping, params string[] varaible)
        {
            throw new NotImplementedException();
        }

        public object ReadAddress(string address)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string,object> Read(string mapping, params string[] vars)
        {
            return _papper.Read(mapping, vars);
        }

        public bool Write(string mapping, Dictionary<string, object> values)
        {
            return _papper.Write(mapping, values);
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
                    return _client.ReadAny(PlcArea.DB, offset, typeof(byte), new [] { length, ad.Item2 }) as byte[];
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

            if(area == PlcArea.DB)
            {
                if(!int.TryParse(selector.Substring(2), out blockNumber))
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
