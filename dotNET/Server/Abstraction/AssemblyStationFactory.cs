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
            

            var station = new AssemblyStation(node, _nodeManager);

            var setters = makeSetters(station);
            var getters = makeGetters(station);

            foreach (var variableName in variables)
            {
                _nodeManager.SetVariableConfiguration(
                    node.NodeId,
                    new QualifiedName(variableName, _nodeManager.TypeNamespaceIndex),
                    NodeHandleType.ExternalPolled,
                    new Tuple<Func<object>, Action<object>>(getters[variableName], setters[variableName])
                );
            }

            return station;
        }

        private readonly DcsLabNodeManager _nodeManager;

        private readonly string[] variables = new string[]
        {
            "ST_INPUT",
            "ST_OUTPUT",
            "CYCLE_TIME",
            "ALARM",
            "BLOCKED",
            "EMPTY",
            "EXCLUDED",
            "INTERVENTION",
            "RUN",
            "TIMEOUT",
        };
        
        private Dictionary<string, Action<object>> makeSetters(AssemblyStation station)
        {
            return new Dictionary<string, Action<object>>(){
                {"ST_INPUT", v => station.StInput = (bool)v},
                {"ST_OUTPUT", v => station.StOutput = (bool)v},
                {"CYCLE_TIME", v => station.CycleTime = (byte)v},
                {"ALARM", v => station.Alarm = (bool)v},
                {"BLOCKED", v => station.Blocked = (bool)v},
                {"EMPTY", v => station.Empty = (bool)v},
                {"EXCLUDED", v => station.Excluded = (bool)v},
                {"INTERVENTION", v => station.Intervention = (bool)v},
                {"RUN", v => station.Run = (bool)v},
                {"TIMEOUT", v => station.Timeout = (bool)v},
            };
        }

        private Dictionary<string, Func<object>> makeGetters(AssemblyStation station)
        {
            return new Dictionary<string, Func<object>>(){
                {"ST_INPUT", () => station.StInput},
                {"ST_OUTPUT", () => station.StOutput},
                {"CYCLE_TIME", () => station.CycleTime},
                {"ALARM", () => station.Alarm},
                {"BLOCKED", () => station.Blocked},
                {"EMPTY", () => station.Empty},
                {"EXCLUDED", () => station.Excluded},
                {"INTERVENTION", () => station.Intervention},
                {"RUN", () => station.Run},
                {"TIMEOUT", () => station.Timeout},
            };
        }
    }
}
