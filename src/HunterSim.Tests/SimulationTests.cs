using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HunterSim.Tests
{
    [TestClass]
    public class SimulationTests
    {
        [TestMethod]
        public void ZeroDps()
        {
            var config = new DefaultConfig();
            var sim = new Simulation(config);

            var dps = sim.Run();

            Assert.AreEqual(Math.Floor(60 / 2.8) * 93.3, dps, 0.0001);
        }
    }
}
