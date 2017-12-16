using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation
{
    class MonitoredInstance<T>: IDisposable where T: IUpdateable, new()
    {
        public MonitoredInstance(Session session, ushort namespaceIndex)
        {
            _namespaceIndex = namespaceIndex;
            Instance = new T();
            _subscription = CreateSubscription(session, Instance);

        }

        public T Instance { get; }

        #region IDisposable
        ~MonitoredInstance()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _subscription.Delete();
                _disposed = true;
            }
        }
        #endregion

        private Subscription CreateSubscription(Session session, T instance)
        {
            var subscription = new Subscription(session)
            {
                PublishingEnabled = true,
                PublishingInterval = 100
            };
            subscription.DataChanged += new DataChangedEventHandler(instance.Update);
            subscription.Create();
            return subscription;
        }

        private IEnumerable<MonitoredItem> ToMonitored(string instanceName, IEnumerable<string> fieldNames)
        {
            return fieldNames
                .Select(name => new DataMonitoredItem(
                    new NodeId($"{instanceName}.{name}", _namespaceIndex)));
        }

        private bool _disposed;
        private readonly ushort _namespaceIndex;
        private readonly Subscription _subscription;
    }
}
