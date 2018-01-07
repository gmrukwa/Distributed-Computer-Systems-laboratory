using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AssemblyStationClient.StateMachine;
using AssemblyStationClient.ViewModel;

namespace AssemblyStationClient.StationAutomation
{
    public class WorkingState : AssemblyStationState, IDisposable
    {
        public WorkingState(AssemblyStationState previous) : base(previous)
        {
            ControlService.Write("ST_INPUT", false);
            ControlService.Write("RUN", true);
            var workingTime = (byte) new Random().Next(10, 51);
            Debug.WriteLine($"Working time: {workingTime}s");
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
                return new InterventionState(this);
            if (updatedPropertyName == "Blocked" || vm.Blocked)
                return new BlockedState(this);
            if (updatedPropertyName == "Run" && vm.Run)
                return this;
            if (updatedPropertyName == "StOutput")
                return this;
            if (updatedPropertyName == "Run" && vm.StInput && !vm.Blocked)
                return new WorkingState(this);
            return new IdleState(this);
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
            if (!_cancellationToken.IsCancellationRequested)
                ControlService.Write(AssemblyStationVm.StOutput ? "BLOCKED" : "ST_OUTPUT", true);
            ControlService.Write("TIMEOUT", false);
            ControlService.Write("RUN", false);
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
