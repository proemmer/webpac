using InacS7Core;
using InacS7Core.Domain;
using Microsoft.Extensions.Configuration;
using Papper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace webpac.Services
{
    public interface IMappingService
    {
        void Configure(IConfigurationSection config);
        void OpenConnection();
        void CloseConnection();
        IEnumerable<string> GetSymbolicBlocks();
        IEnumerable<string> GetDataBlocks();
        IEnumerable<string> GetSymbols();
        Dictionary<string, object> Read(string mapping, params string[] vars);
        bool Write(string mapping, Dictionary<string, object> values);
    }


    public class MappingService : IMappingService
    {
        #region Fields
        private InacS7CoreClient _client;
        private static PlcDataMapper _papper;
        private string _connectionString = string.Empty;
        #endregion

        ~MappingService()
        {
            CloseConnection();
        }

        public void Configure(IConfigurationSection config)
        {
            _connectionString = config.Get<string>("ConnectionString");
        }

        public void OpenConnection()
        {
            if (_client != null)
                CloseConnection();
            else
                _client = new InacS7CoreClient();
            _client.Connect(_connectionString);

            if(_client.IsConnected)
            {
                var pduSize = _client.PduSize;
                _papper = new PlcDataMapper(pduSize);
                _papper.OnRead += OnRead;
                _papper.OnWrite += OnWrite;
            }
        }

        public void CloseConnection()
        {
            if(_client != null)
            {
                _client.Disconnect();
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

        #endregion
    }

}
