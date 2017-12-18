using System;
using System.Collections.Generic;
using System.Linq;
using AssemblyStationClient.ViewModel;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.Monitoring
{
    /// <summary>
    /// Updates local AssemblyStationVm instance from the server.
    /// </summary>
    internal class MonitorService : IDisposable
    {
        public MonitorService(Session session, AssemblyStationVm vm, string namespaceName)
        {
            _subscriptionManager = new SubscriptionManager(session);
            _subscriptionManager.DataChanged += HandleDataChange;
            var monitoredItems = BuildMonitoredItems(session, vm, namespaceName);
            _subscriptionManager.RegisterListeners(monitoredItems);
        }

        private List<MonitoredItem> BuildMonitoredItems(Session session, AssemblyStationVm vm, string namespaceName)
        {
            var factory = new MonitoredItemFactory(session, vm.Name, namespaceName);

            var listeners = new []
            {
                factory.Create<bool>("ST_INPUT", v => vm.StInput = v),
                factory.Create<bool>("ST_OUTPUT", v => vm.StOutput = v),
                factory.Create<bool>("ALARM", v => vm.Alarm = v),
                factory.Create<bool>("BLOCKED", v => vm.Blocked = v),
                factory.Create<byte>("CYCLE_TIME", v => vm.CycleTime = v),
                factory.Create<bool>("EMPTY", v => vm.Empty = v),
                factory.Create<bool>("EXCLUDED", v => vm.Excluded= v),
                factory.Create<bool>("INTERVENTION", v => vm.Intervention = v),
                factory.Create<bool>("RUN", v => vm.Run = v),
                factory.Create<bool>("TIMEOUT", v => vm.Timeout = v)
            };

            return listeners.ToList();
        }

        private static void HandleDataChange(object userData, object value)
        {
            ((Action<object>)userData)(value);
        }

        private readonly SubscriptionManager _subscriptionManager;

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MonitorService()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
                _subscriptionManager.Dispose();
            _disposed = true;
        }

        private bool _disposed;
        #endregion
    }
}
