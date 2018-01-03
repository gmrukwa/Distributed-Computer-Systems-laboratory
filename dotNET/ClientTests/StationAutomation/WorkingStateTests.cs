using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicMoq;
using AssemblyStationClient.StationAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyStationClient.Controlling;
using Moq;

namespace AssemblyStationClient.StationAutomation.Tests
{
    [TestClass()]
    public class WorkingStateTests
    {
        [TestMethod()]
        public void resets_input_and_toggles_run_on_entry()
        {
            var magic = new Moqer();
            magic.Setup<ControlService>(c => c.Write("ST_INPUT", false)).Verifiable();
            magic.Setup<ControlService>(c => c.Write("RUN", true)).Verifiable();

            var controlService = magic.Resolve<ControlService>();
            new WorkingState(controlService);

            magic.Verify<ControlService>(control => control.Write("ST_INPUT", false), Times.Once());
            magic.Verify<ControlService>(control => control.Write("RUN", true), Times.Once());
        }

        [TestMethod()]
        public void ChangesStateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNextTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}