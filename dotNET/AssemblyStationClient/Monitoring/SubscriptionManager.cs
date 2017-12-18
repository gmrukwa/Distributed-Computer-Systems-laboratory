using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.Monitoring
{
    internal class SubscriptionManager : IDisposable
    {
        private readonly Subscription _subscription;

        public SubscriptionManager(Session session)
        {
            _subscription = CreateSubscription(session);
        }

        public Subscription CreateSubscription(Session session)
        {
            var subscription = new Subscription(session)
            {
                PublishingEnabled = true,
                PublishingInterval = 100
            };
            subscription.DataChanged += HandleDataChange;
            return subscription;
        }

        public void RegisterListeners(IList<MonitoredItem> listeners)
        {
            var statusCodes = _subscription.CreateMonitoredItems(listeners);
            if (statusCodes.Any(code => code.IsBad()))
                throw new IOException("Unable to register listeners.");
        }

        public delegate void SubscribedDataEventHandler(object userData, object value);
        public SubscribedDataEventHandler DataChanged;

        private void HandleDataChange(Subscription subscription, DataChangedEventArgs eventArgs)
        {
            if (!ReferenceEquals(subscription, _subscription))
                return;

            foreach (var change in eventArgs.DataChanges)
            {
                if (change.Value.StatusCode.IsBad())
                    throw new IOException($"Error fetching data change of {change.MonitoredItem.NodeId.Identifier}.");
                DataChanged?.Invoke(change.MonitoredItem.UserData, change.Value.Value);
            }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~SubscriptionManager()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
                _subscription.Delete();
            _disposed = true;
        }

        private bool _disposed;
        #endregion
    }
}