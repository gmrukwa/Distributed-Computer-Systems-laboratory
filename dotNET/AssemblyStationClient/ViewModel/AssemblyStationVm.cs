using Spectre.Mvvm.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyStationClient.StationAutomation;
using UnifiedAutomation.UaClient;

namespace AssemblyStationClient.ViewModel
{
    /// <summary>
    /// ViewModel for AssemblyStation defined in UaModeler
    /// </summary>
    /// <seealso cref="Spectre.Mvvm.Base.PropertyChangedNotification" />
    class AssemblyStationVm : PropertyChangedNotification
    {
        #region Constructor
        public AssemblyStationVm(Session session, string name)
        {
            Name = name;
            // GUI: updates through PropertyChangedNotification
            // MonitorService: needs no binding to events, updates VM directly (causes PropertyChangedNotification)
            // ControlService: has dedicated functions to call update (no event fired)
            // SimulationService: gets updates through PropertyChangedNotification, acts through ControlService
            _monitorService = new MonitorService(session, this);
            _controlService = new ControlService(session, this);
            _simulationService = new SimulationService(this, _controlService);
        }
        #endregion

        #region Properties
        public string Name { get; }

        public bool StInput
        {
            get { return GetValue(() => StInput); }
            set { SetValue(() => StInput, value); }
        }

        public bool StOutput
        {
            get { return GetValue(() => StOutput); }
            set { SetValue(() => StOutput, value); }
        }

        public byte CycleTime
        {
            get { return GetValue(() => CycleTime); }
            set { SetValue(() => CycleTime, value); }
        }

        public bool Alarm
        {
            get { return GetValue(() => Alarm); }
            set { SetValue(() => Alarm, value); }
        }

        public bool Blocked
        {
            get { return GetValue(() => Blocked); }
            set { SetValue(() => Blocked, value); }
        }

        public bool Empty
        {
            get { return GetValue(() => Empty); }
            set { SetValue(() => Empty, value); }
        }

        public bool Excluded
        {
            get { return GetValue(() => Excluded); }
            set { SetValue(() => Excluded, value); }
        }

        public bool Intervention
        {
            get { return GetValue(() => Intervention); }
            set { SetValue(() => Intervention, value); }
        }

        public bool Run
        {
            get { return GetValue(() => Run); }
            set { SetValue(() => Run, value); }
        }

        public bool Timeout
        {
            get { return GetValue(() => Timeout); }
            set { SetValue(() => Timeout, value); }
        }
        #endregion
        
        #region Privates
        private readonly MonitorService _monitorService;
        private readonly ControlService _controlService;
        private readonly SimulationService _simulationService;
        #endregion
    }
}
