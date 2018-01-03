using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AssemblyStationClient.Controlling;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class WorkingState : AssemblyStationState, IDisposable
    {
        public WorkingState(ControlService controlService) : base(controlService)
        {
            ControlService.Write("ST_INPUT", false);
            ControlService.Write("RUN", true);
            var workingTime = (byte) new Random().Next(10, 51);
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
            _stationRunner = new Task(() => DoStationWork(workingTime), _cancellationToken);
            _stationRunner.Start();
        }

        public override bool ChangesState(AssemblyStationVm vm, string updatedPropertyName)
        {
            return TransitionVariables.Contains(updatedPropertyName);
        }

        public override IState<AssemblyStationVm> GetNext(AssemblyStationVm vm, string updatedPropertyName)
        {
            if (vm.Intervention)
                return new InterventionState(ControlService);
            if (vm.StOutput)    
                return new BlockedState(ControlService);
            if (vm.Run)
                return this;
            return new IdleState(ControlService);
        }

        private void DoStationWork(byte workingTime)
        {
            const int second = 1000;
            for (byte current = 0; current < workingTime; ++current)
            {
                if (_cancellationToken.IsCancellationRequested)
                    break;
                Thread.Sleep(second);
                ControlService.Write("CYCLE_TIME", current);
                if (current == TimeoutTime)
                {
                    ControlService.Write("TIMEOUT", true);
                }
            }
            ControlService.Write("RUN", false);
            ControlService.Write("TIMEOUT", false);
            if (!_cancellationToken.IsCancellationRequested)
                ControlService.Write("ST_OUTPUT", true);
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~WorkingState()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _tokenSource.Cancel();
                _stationRunner.Wait();
                _stationRunner.Dispose();
            }
            _disposed = true;
        }

        private bool _disposed;
        #endregion

        private static readonly IEnumerable<string> TransitionVariables = new[] { "Intervention", "Alarm", "Run" };
        private const byte TimeoutTime = 60;
        private readonly Task _stationRunner;
        private readonly CancellationToken _cancellationToken;
        private readonly CancellationTokenSource _tokenSource;
    }
}
