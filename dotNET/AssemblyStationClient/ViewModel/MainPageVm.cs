using System;
using System.Collections.ObjectModel;
using System.Linq;
using AssemblyStationClient.Connection;
using Spectre.Mvvm.Base;
using UnifiedAutomation.UaBase;

namespace AssemblyStationClient.ViewModel
{
    class MainPageVm : PropertyChangedNotification, IDisposable
    {
        public MainPageVm()
        {
            _context = new ServerContext(ApplicationInstance.Default, ServerAddress);
            var info = new SessionInfo(_context.Session);
            var namespaceName = info.GetAvailableNamespaces().First(name => name.Contains(NamespaceUniqueString));
            AssemblyStations = new ObservableCollection<AssemblyStationVm>(
                InstanceNames.Select(name => new AssemblyStationVm(_context.Session, name, namespaceName)));
        }

        public ObservableCollection<AssemblyStationVm> AssemblyStations
        {
            get { return GetValue(() => AssemblyStations); }
            set { SetValue(() => AssemblyStations, value); }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~MainPageVm()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                foreach (var assemblyStationVm in AssemblyStations)
                {
                    assemblyStationVm.Dispose();
                }
                AssemblyStations.Clear();
                _context.Dispose();
            }
            _disposed = true;
        }

        private bool _disposed;
        #endregion

        private static readonly string[] InstanceNames = {"UA1_1_1", "UA2_1_1"};
        private const string ServerAddress = "opc.tcp://localhost:48030";
        private const string NamespaceUniqueString = "DCS-lab";
        private readonly ServerContext _context;
    }
}
