using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class BlockedState : AssemblyStationState
    {
        public BlockedState(AssemblyStationState previous) : base(previous)
        {
            AssemblyStation.Blocked = true;
        }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return updatedPropertyName == "StOutput";
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
        {
            AssemblyStation.Blocked = false;
            AssemblyStation.StOutput = true;
            if (vm.StInput)
                return new WorkingState(this);
            else
                return new IdleState(this);
        }
    }
}
