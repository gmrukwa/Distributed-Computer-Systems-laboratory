using PolslMacrocourse.DcsLab.Abstraction;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    /// <summary>
    /// Simulates AssemblyStation behavior.
    /// </summary>
    class SimulationService
    {
        public SimulationService(AssemblyStation vm)
        {
            var state = new IdleState(vm);
            vm.PropertyChanged += state.Notify;
        }
    }
}
