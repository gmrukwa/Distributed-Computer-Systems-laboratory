using System;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation
{
    class MonitoredItemFactory
    {
        public MonitoredItemFactory(Session session, string instanceName, string namespaceName)
        {
            _instanceName = instanceName;
            var info = new SessionInfo(session);
            _namespaceIndex = info.GetNamespaceIndex(namespaceName);
        }

        public MonitoredItem Create<T>(string fieldName, Action<T> setter)
        {
            var nodeId = new NodeId($"{_instanceName}.{fieldName}", _namespaceIndex);
            var normalizedSetter = new Action<object>(o => setter((T)o));
            return new DataMonitoredItem(nodeId)
            {
                UserData = normalizedSetter
            };
        }

        private readonly string _instanceName;
        private readonly ushort _namespaceIndex;
    }
}
