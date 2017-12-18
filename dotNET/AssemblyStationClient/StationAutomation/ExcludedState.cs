using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    class ExcludedState : AssemblyStationState
    {
        public ExcludedState(ControlService controlService) : base(controlService) { }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Excluded";
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            return new IdleState(ControlService);
        }
    }
}
