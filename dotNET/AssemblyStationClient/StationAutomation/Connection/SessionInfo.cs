using System.Collections.Generic;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation.Connection
{
    class SessionInfo
    {
        public SessionInfo(Session session)
        {
            _session = session;
        }

        public ushort GetNamespaceIndex(string name)
        {
            for (ushort i = 0; i < _session.NamespaceUris.Count; ++i)
            {
                if (_session.NamespaceUris[i] == name)
                {
                    return i;
                }
            }
            throw new KeyNotFoundException($"Unknown namespace: {name}");
        }

        public IEnumerable<string> GetAvailableNamespaces() => _session.NamespaceUris;

        private readonly Session _session;
    }
}
