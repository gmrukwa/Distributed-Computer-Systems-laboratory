using AssemblyStationClient.Controlling;
﻿using System.Diagnostics;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StateMachine
{
    public abstract class AssemblyStationState : BaseState<AssemblyStationVm>
    {
        protected AssemblyStationState(ControlService controlService)
        {
            Debug.WriteLine(GetType().Name);
            ControlService = controlService;
        }

        protected readonly ControlService ControlService;
    }
}
