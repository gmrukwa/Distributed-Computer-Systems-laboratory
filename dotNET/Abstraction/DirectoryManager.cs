using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaServer;

namespace PolslMacrocourse.DcsLab.Abstraction
{
    using Directory = ObjectNode;

    internal class DirectoryManager
    {
        public DirectoryManager(DcsLabNodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }

        public Directory Get(ExpandedNodeId expandedNodeId)
        {
            var nodeId = new NodeId((uint)expandedNodeId.Identifier, _nodeManager.InstanceNamespaceIndex);
            var node = _nodeManager.FindInMemoryNode(nodeId);
            return (Directory)node;
        }

        private readonly DcsLabNodeManager _nodeManager;
        private RequestContext Context => _nodeManager.Server.DefaultRequestContext;
    }
}
