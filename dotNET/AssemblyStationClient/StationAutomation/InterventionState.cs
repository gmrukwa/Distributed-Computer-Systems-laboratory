using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class InterventionState : AssemblyStationState
    {
        public InterventionState(AssemblyStationState previous) : base(previous)
        {
            ControlService.Write("INTERVENTION", true);
        }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Intervention";
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            if (vm.StInput)
                return new WorkingState(this);
            return new IdleState(this);
        }
    }
}
