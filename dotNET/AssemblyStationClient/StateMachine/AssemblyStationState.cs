﻿using AssemblyStationClient.Controlling;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StateMachine
{
    abstract class AssemblyStationState : BaseState<AssemblyStationVm>
    {
        protected AssemblyStationState(ControlService controlService)
        {
            ControlService = controlService;
        }

        protected readonly ControlService ControlService;
    }
}