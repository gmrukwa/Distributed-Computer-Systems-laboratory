using System;
using System.Collections.Generic;
using System.IO;
using AssemblyStationClient.ViewModel;
using UnifiedAutomation.UaBase;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.Controlling
{
    /// <summary>
    /// Maps changes from VM to server.
    /// 
    /// Controls the remote instance of AssemblyStation.
    /// </summary>
    public class ControlService
    {
        public ControlService(Session session, AssemblyStationVm vm, string namespaceName)
        {
            _writer = new InstanceWriter(session, vm.Name, namespaceName);
        }

        public void Write<T>(string variableName, T value)
        {
            ValidateType<T>(variableName);
            _writer.Write(variableName, value);
        }

        private static void ValidateType<T>(string variableName)
        {
            if(variableName == "CYCLE_TIME" && typeof(T) != typeof(byte))
                throw new ArgumentException(variableName);
            if(variableName != "CYCLE_TIME" && typeof(T) != typeof(bool))
                throw new ArgumentException(variableName);
        }

        private readonly InstanceWriter _writer;
    }
}
