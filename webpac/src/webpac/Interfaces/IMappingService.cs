using System;
using System.Collections.Generic;

namespace Webpac.Interfaces
{
    public delegate void OnDataChangeEventHandler(List<SubscriptionInformationPackage> package);
    public delegate void OnPlcConnectionChangeEventHandler(List<string> subscribers, bool state);

    public class SubscriptionInformationPackage
    {
        public string Mapping { get; set; }
        public string Variable { get; set; }
        public object Value { get; set; }
        public bool IsRaw { get; set; }

        public IEnumerable<string> Subscribers { get; set; }
    }

    public interface IMappingService : IService, IDisposable
    {
        IEnumerable<string> GetDataBlocks();
        IEnumerable<string> GetSymbols();
        Dictionary<string, object> Read(string mapping, params string[] vars);
        Dictionary<string, object> ReadAbs(string mapping, params string[] vars);
        bool Write(string mapping, Dictionary<string, object> values);
        bool WriteAbs(string mapping, Dictionary<string, object> values);
        bool SubscribeChanges(string subscriberId, string mapping, params string[] vars);
        bool UnsubscribeChanges(string subscriberId, string mapping, params string[] vars);
        bool SubscribeRawChanges(string subscriberId, string area, params string[] adresses);
        bool UnsubscribeRawChanges(string subscriberId, string area, params string[] adresses);
        void RemoveSubscriptionsForId(string subscriberId);

        void AddConnectionSubscriber(string subscriberId);
        void RemoveConnectionSubscriber(string subscriberId);

        event OnDataChangeEventHandler DataChanged;
        event OnPlcConnectionChangeEventHandler PlcConnectionChanged;

        bool IsConnected { get; }
    }
}
