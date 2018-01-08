using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PolslMacrocourse.DcsLab.Abstraction;
using PolslMacrocourse.DcsLab.StateMachine;

namespace PolslMacrocourse.DcsLab.StationAutomation
{
    class WorkingState : AssemblyStationState, IDisposable
    {
        public WorkingState(AssemblyStationState previous) : base(previous)
        {
            AssemblyStation.StInput = false;
            AssemblyStation.Run = true;
            var workingTime = (byte) new Random().Next(10, 51);
            Debug.WriteLine($"Working time: {workingTime}s");
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
            _stationRunner = new Task(() => DoStationWork(workingTime), _cancellationToken);
            _stationRunner.Start();
        }

        public override bool ChangesState(AssemblyStation vm, string updatedPropertyName)
        {
            return TransitionVariables.Contains(updatedPropertyName);
        }

        public override IState<AssemblyStation> GetNext(AssemblyStation vm, string updatedPropertyName)
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
                AssemblyStation.CycleTime = current;
                if (current == TimeoutTime)
                {
                    AssemblyStation.Timeout = true;
                }
            }
            if (!_cancellationToken.IsCancellationRequested)
            {
                if (AssemblyStation.StOutput)
                {
                    AssemblyStation.Blocked = true;
                }
                else
                {
                    AssemblyStation.StOutput = true;
                }
            }
            AssemblyStation.Timeout = true;
            AssemblyStation.Run = false;
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
