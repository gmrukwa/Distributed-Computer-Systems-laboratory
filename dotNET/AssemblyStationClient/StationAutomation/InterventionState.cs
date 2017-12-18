using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    class InterventionState : AssemblyStationState
    {
        public InterventionState(ControlService controlService) : base(controlService) { }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Intervention";
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            return new IdleState(ControlService);
        }
    }
}
