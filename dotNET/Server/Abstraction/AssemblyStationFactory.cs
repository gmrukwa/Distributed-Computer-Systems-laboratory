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

    internal class AssemblyStationFactory
    {

        public AssemblyStationFactory(DcsLabNodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }

        public AssemblyStation Create(string name, Directory directory)
        {
            var settings = new CreateObjectSettings()
            {
                ParentNodeId = directory.NodeId,
                ReferenceTypeId = UnifiedAutomation.UaBase.ReferenceTypeIds.Organizes,
                RequestedNodeId = new NodeId(name, _nodeManager.InstanceNamespaceIndex),
                BrowseName = new QualifiedName(name, _nodeManager.InstanceNamespaceIndex),
                TypeDefinitionId = new NodeId(PolslMacrocourse.DcsLab.ObjectTypes.AssemblyStationType, _nodeManager.TypeNamespaceIndex)
            };
            var node = _nodeManager.CreateObject(_nodeManager.Server.DefaultRequestContext, settings);
            return new AssemblyStation(node, _nodeManager);
        }

        private readonly DcsLabNodeManager _nodeManager;
    }
}
