using AssemblyStationClient.Controlling;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    /// <summary>
    /// Simulates AssemblyStation behavior.
    /// </summary>
    class SimulationService
    {
        public SimulationService(AssemblyStationVm vm, ControlService controlService)
        {
            var state = new IdleState(controlService);
            vm.PropertyChanged += state.Notify;
        }
    }
}
