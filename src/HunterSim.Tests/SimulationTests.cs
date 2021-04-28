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

            RandomGenerator.Instance = new RandomGenerator(64852147);

            var dps = sim.Run();

            Assert.AreEqual(2052.6, dps, 0.0001);
            // TODO: Assert the damage events data
        }

        // TODO: Mock out the rolls to always hit, always miss, etc
    }
}
