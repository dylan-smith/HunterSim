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

            var expected = new DamageEvent(2.8, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[0]);

            expected = new DamageEvent(5.6, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[1]);

            expected = new DamageEvent(8.4, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[2]);

            expected = new DamageEvent(11.2, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[3]);

            expected = new DamageEvent(14.0, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[4]);

            expected = new DamageEvent(16.8, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[5]);

            expected = new DamageEvent(19.6, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[6]);

            expected = new DamageEvent(22.4, 186.6, DamageTypes.Crit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[7]);

            expected = new DamageEvent(25.2, 0.0, DamageTypes.Miss, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[8]);

            expected = new DamageEvent(28.0, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[9]);

            expected = new DamageEvent(30.8, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[10]);

            expected = new DamageEvent(33.6, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[11]);

            expected = new DamageEvent(36.4, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[12]);

            expected = new DamageEvent(39.2, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[13]);

            expected = new DamageEvent(42.0, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[14]);

            expected = new DamageEvent(44.8, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[15]);

            expected = new DamageEvent(47.6, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[16]);

            expected = new DamageEvent(50.4, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[17]);

            expected = new DamageEvent(53.2, 186.6, DamageTypes.Crit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[18]);

            expected = new DamageEvent(56.0, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[19]);

            expected = new DamageEvent(58.8, 93.3, DamageTypes.Hit, 0.09, 0.05, 0.95);
            AssertDamageEvent(expected, result.DamageEvents[20]);
        }

        private void AssertDamageEvent(DamageEvent expected, DamageEvent actual)
        {
            Assert.AreEqual(expected.Damage, actual.Damage, 0.0001);
            Assert.AreEqual(expected.Timestamp, actual.Timestamp, 0.0001);
            Assert.AreEqual(expected.DamageType, actual.DamageType);
            Assert.AreEqual(expected.CritChance, actual.CritChance, 0.0001);
            Assert.AreEqual(expected.HitChance, actual.HitChance, 0.0001);
            Assert.AreEqual(expected.MissChance, actual.MissChance, 0.0001);
        }

        // TODO: Mock out the rolls to always hit, always miss, etc
    }
}
