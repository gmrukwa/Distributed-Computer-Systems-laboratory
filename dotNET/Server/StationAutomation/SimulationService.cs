using AssemblyStationClient.Controlling;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    /// <summary>
    /// Simulates AssemblyStation behavior.
    /// </summary>
    class SimulationService
    {
        public SimulationService(ControlService controlService, AssemblyStationVm vm)
        {
            var state = new IdleState(controlService, vm);
            vm.PropertyChanged += state.Notify;
        }
    }
}
