using System;
using System.Collections.Generic;
using System.IO;
using AssemblyStationClient.Connection;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.Controlling
{
    class InstanceWriter
    {
        public InstanceWriter(Session session, string instanceName, string namespaceName)
        {
            _session = session;
            _instanceName = instanceName;
            var info = new SessionInfo(session);
            _namespaceIndex = info.GetNamespaceIndex(namespaceName);
        }

        public void Write<T>(string variableName, T value)
        {
            var type = GetRemoteType(variableName);
            Write(variableName, value, type);
        }

        private BuiltInType GetRemoteType(string variableName)
        {
            var nodeName = $"{_instanceName}.{variableName}";
            var nodeToRead = new ReadValueId()
            {
                AttributeId = Attributes.DataType,
                NodeId = new NodeId(nodeName, _namespaceIndex)
            };

            DataValue result;
            try
            {
                result = _session.Read(new List<ReadValueId> { nodeToRead }, 0, TimestampsToReturn.Neither, null)[0];
            }
            catch (Exception exception)
            {
                throw new IOException($"Failed to read {nodeName} type.", exception);
            }
            if (result.StatusCode.IsBad())
            {
                throw new IOException($"Failed to read {nodeName} type.");
            }

            return TypeUtils.GetBuiltInType((NodeId)result.Value);
        }

        private void Write<T>(string variableName, T value, BuiltInType type)
        {
            var dataValue = new DataValue { Value = TypeUtils.Cast(value, type) };
            var nodeName = $"{_instanceName}.{variableName}";
            var writeValue = new WriteValue()
            {
                NodeId = new NodeId(nodeName, _namespaceIndex),
                AttributeId = Attributes.Value,
                Value = dataValue
            };
            var statusCode = _session.Write(new List<WriteValue> { writeValue })[0];
            if (!statusCode.IsGood())
            {
                throw new IOException($"Failed to write {value} on {nodeName}.");
            }
        }

        private readonly Session _session;
        private readonly string _instanceName;
        private readonly ushort _namespaceIndex;
    }
}
