using Spectre.Mvvm.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyStationClient.ViewModel
{
    class AssemblyStationVm : PropertyChangedNotification
    {
        public bool StInput
        {
            get { return GetValue(() => StInput); }
            set { SetValue(() => StInput, value); }
        }

        public bool StOutput
        {
            get { return GetValue(() => StOutput); }
            set { SetValue(() => StOutput, value); }
        }

        public byte CycleTime
        {
            get { return GetValue(() => CycleTime); }
            set { SetValue(() => CycleTime, value); }
        }

        public bool Alarm
        {
            get { return GetValue(() => Alarm); }
            set { SetValue(() => Alarm, value); }
        }

        public bool Blocked
        {
            get { return GetValue(() => Blocked); }
            set { SetValue(() => Blocked, value); }
        }

        public bool Empty
        {
            get { return GetValue(() => Empty); }
            set { SetValue(() => Empty, value); }
        }

        public bool Excluded
        {
            get { return GetValue(() => Excluded); }
            set { SetValue(() => Excluded, value); }
        }

        public bool Intervention
        {
            get { return GetValue(() => Intervention); }
            set { SetValue(() => Intervention, value); }
        }

        public bool Run
        {
            get { return GetValue(() => Run); }
            set { SetValue(() => Run, value); }
        }

        public bool Timeout
        {
            get { return GetValue(() => Timeout); }
            set { SetValue(() => Timeout, value); }
        }
    }
}
