using System;
using System.IO;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation.Connection
{
    internal class ServerContext : IDisposable
    {
        private bool _disposed;

        public ServerContext(ApplicationInstance applicationInstance, string serverUrl)
        {
            Session = new Session(applicationInstance);
            Session.ConnectionStatusUpdate += ThrowOnConnectionLost;
            Session.UseDnsNameAndPortFromDiscoveryUrl = true;
            Session.Connect(serverUrl, SecuritySelection.None);
        }

        public Session Session { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ServerContext()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                Session.Disconnect();
                Session.Dispose();
                _disposed = true;
            }
        }

        private void ThrowOnConnectionLost(Session sender, ServerConnectionStatusUpdateEventArgs e)
        {
            switch (e.Status)
            {
                case ServerConnectionStatus.Disconnected:
                case ServerConnectionStatus.LicenseExpired:
                case ServerConnectionStatus.ServerShutdown:
                case ServerConnectionStatus.ServerShutdownInProgress:
                    throw new IOException("Connection to the server lost.");
                case ServerConnectionStatus.Connected:
                case ServerConnectionStatus.ConnectionWarningWatchdogTimeout:
                case ServerConnectionStatus.ConnectionErrorClientReconnect:
                case ServerConnectionStatus.SessionAutomaticallyRecreated:
                case ServerConnectionStatus.Connecting:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}