using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class InterventionState : AssemblyStationState
    {
        public InterventionState(AssemblyStationState previous) : base(previous)
        {
            AssemblyStation.Intervention = true;
        }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Intervention";
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
        {
            if (vm.StInput)
                return new WorkingState(this);
            return new IdleState(this);
        }
    }
}
