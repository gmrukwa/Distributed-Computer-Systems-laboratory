using System.Linq;
using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    class IdleState: AssemblyStationState
    {
        public IdleState(ControlService controlService) : base(controlService) { }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return new []{"Excluded", "Alarm", "Intervention", "StInput"}.Any(name => name == updatedPropertyName);
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            if(vm.Intervention)
                return new InterventionState(ControlService);
            if (vm.Alarm)
                return new AlarmState(ControlService);
            if (vm.Excluded)
                return new ExcludedState(ControlService);
            ControlService.Write("RUN", true);
            ControlService.Write("ST_INPUT", false);
            return new WorkingState(ControlService);
        }
    }
}
