using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    class BlockedState : AssemblyStationState
    {
        public BlockedState(ControlService controlService) : base(controlService)
        {
            ControlService.Write("BLOCKED", true);
        }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return updatedPropertyName == "StOutput";
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            ControlService.Write("BLOCKED", false);
            ControlService.Write("ST_OUTPUT", true);
            return new IdleState(ControlService);
        }
    }
}
