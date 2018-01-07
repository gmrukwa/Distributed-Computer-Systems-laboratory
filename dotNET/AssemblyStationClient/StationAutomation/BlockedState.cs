using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class BlockedState : AssemblyStationState
    {
        public BlockedState(AssemblyStationState previous) : base(previous)
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
            if (vm.StInput)
                return new WorkingState(this);
            else
                return new IdleState(this);
        }
    }
}
