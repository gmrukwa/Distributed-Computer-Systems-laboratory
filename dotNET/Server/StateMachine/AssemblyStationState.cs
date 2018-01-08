using System.Diagnostics;
using PolslMacrocourse.DcsLab.Abstraction;

namespace PolslMacrocourse.DcsLab.StateMachine
{
    abstract class AssemblyStationState : BaseState<AssemblyStation>
    {
        protected AssemblyStationState(AssemblyStation station)
        {
            Debug.WriteLine(GetType().Name);
            AssemblyStation = station;
        }

        protected AssemblyStationState(AssemblyStationState previous) :
            this(previous.AssemblyStation)
        {
        }

        protected readonly AssemblyStation AssemblyStation;
    }
}