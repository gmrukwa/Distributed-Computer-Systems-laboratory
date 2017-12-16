using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation
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

        public string GetFirstAvailableNamespace() => _session.NamespaceUris.FirstOrDefault();

        private readonly Session _session;
    }
}
