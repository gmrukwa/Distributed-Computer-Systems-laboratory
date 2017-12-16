using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.StationAutomation
{
    interface IUpdateable
    {
        void Update(Subscription subscription, DataChangedEventArgs e);
        string InstanceName { get; }
        IList<string> FieldNames { get; }
    }
}
