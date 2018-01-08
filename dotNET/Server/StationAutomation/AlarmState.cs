using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class AlarmState : AssemblyStationState
    {
        public AlarmState(AssemblyStationState previous) : base(previous)
        {
            AssemblyStation.Alarm = true;
        }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Alarm";
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
        {
            return new IdleState(this);
        }
    }
}
