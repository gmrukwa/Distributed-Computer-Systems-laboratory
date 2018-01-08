using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class ExcludedState : AssemblyStationState
    {
        public ExcludedState(AssemblyStationState previous) : base(previous)
        {
            AssemblyStation.Excluded = true;
        }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Excluded";
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
        {
            if (vm.StInput)
                return new WorkingState(this);
            return new IdleState(this);
        }
    }
}
