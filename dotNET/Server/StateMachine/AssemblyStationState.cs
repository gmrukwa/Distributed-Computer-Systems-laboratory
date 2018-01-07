using System.Diagnostics;
using AssemblyStationClient.Controlling;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StateMachine
{
    public abstract class AssemblyStationState : BaseState<AssemblyStationVm>
    {
        protected AssemblyStationState(ControlService controlService, AssemblyStationVm vm)
        {
            Debug.WriteLine(GetType().Name);
            ControlService = controlService;
            AssemblyStationVm = vm;
        }

        protected AssemblyStationState(AssemblyStationState previous) :
            this(previous.ControlService, previous.AssemblyStationVm)
        {
        }

        protected readonly ControlService ControlService;

        /// <summary>
        /// The assembly station vm. Do not rewrite its properties from the state!
        /// </summary>
        protected readonly AssemblyStationVm AssemblyStationVm;
    }
}