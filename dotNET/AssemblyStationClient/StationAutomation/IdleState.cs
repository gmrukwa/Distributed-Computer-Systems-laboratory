using System.Linq;
using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class IdleState: AssemblyStationState
    {
        public IdleState(AssemblyStationState previous) : base(previous) { }

        public IdleState(ControlService controlService, AssemblyStationVm vm) : base(controlService, vm) { }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return new []{"Excluded", "Alarm", "Intervention", "StInput"}.Any(name => name == updatedPropertyName);
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            if(vm.Intervention)
                return new InterventionState(this);
            if (vm.Alarm)
                return new AlarmState(this);
            if (vm.Excluded)
                return new ExcludedState(this);
            if (!vm.StInput)
                return this;
            return new WorkingState(this);
        }
    }
}
