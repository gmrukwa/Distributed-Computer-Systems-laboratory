using PolslMacrocourse.DcsLab.StationAutomation;
using Spectre.Mvvm.Base;
using UnifiedAutomation.UaBase;

namespace PolslMacrocourse.DcsLab.Abstraction
{
    class AssemblyStation: PropertyChangedNotification
    {

        #region Constructor
        public AssemblyStation(ObjectNode node, DcsLabNodeManager nodeManager)
        {
            _simulation = new SimulationService(this);
            // TODO: Add update on the server for each change notification
            // TODO: Add notification for update through client
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

        private readonly SimulationService _simulation;

        #endregion
    }
}
