using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

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

            var result = sim.Run();
            var totalDamage = result.DamageEvents.Sum(x => x.Damage);

            Assert.AreEqual(2052.6, totalDamage, 0.0001);

            Assert.AreEqual(21, result.DamageEvents.Count);

            var damage1 = result.DamageEvents[0];

            Assert.AreEqual(93.3, damage1.Damage, 0.0001);
            Assert.AreEqual(2.8, damage1.Timestamp, 0.0001);
            Assert.AreEqual(DamageTypes.Hit, damage1.DamageType);
            Assert.AreEqual(0.05, damage1.CritChance, 0.0001);
            Assert.AreEqual(0.95, damage1.HitChance, 0.0001);
            Assert.AreEqual(0.09, damage1.MissChance, 0.0001);

            // TODO: assert the rest of the events
        }

        // TODO: Mock out the rolls to always hit, always miss, etc
    }
}
