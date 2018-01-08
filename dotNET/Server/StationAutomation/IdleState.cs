using System.Linq;
using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class IdleState: AssemblyStationState
    {
        public IdleState(AssemblyStationState previous) : base(previous) { }

        public IdleState(AssemblyStation station) : base(station) { }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return new []{"Excluded", "Alarm", "Intervention", "StInput"}.Any(name => name == updatedPropertyName);
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
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
