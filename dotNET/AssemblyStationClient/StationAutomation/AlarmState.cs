using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class AlarmState : AssemblyStationState
    {
        public AlarmState(ControlService controlService) : base(controlService) { }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return updatedPropertyName == "Alarm";
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            return new IdleState(ControlService);
        }
    }
}
