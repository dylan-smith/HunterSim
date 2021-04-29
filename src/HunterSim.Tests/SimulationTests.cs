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

            foreach (var e in result.DamageEvents)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            Assert.AreEqual(9822, totalDamage, 0.9);
            Assert.AreEqual(18, result.DamageEvents.Count);

            var expected = new DamageEvent(3.2, 868.46, DamageType.Crit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[0]);

            expected = new DamageEvent(6.4, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[1]);

            expected = new DamageEvent(9.6, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[2]);

            expected = new DamageEvent(12.8, 868.46, DamageType.Crit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[3]);

            expected = new DamageEvent(16.0, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[4]);

            expected = new DamageEvent(19.2, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[5]);

            expected = new DamageEvent(22.4, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[6]);

            expected = new DamageEvent(25.6, 868.46, DamageType.Crit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[7]);

            expected = new DamageEvent(28.8, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[8]);

            expected = new DamageEvent(32.0, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[9]);

            expected = new DamageEvent(35.2, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[10]);

            expected = new DamageEvent(38.4, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[11]);

            expected = new DamageEvent(41.6, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[12]);

            expected = new DamageEvent(44.8, 868.46, DamageType.Crit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[13]);

            expected = new DamageEvent(48.0, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[14]);

            expected = new DamageEvent(51.2, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[15]);

            expected = new DamageEvent(54.4, 421.58, DamageType.Hit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[16]);

            expected = new DamageEvent(57.6, 868.46, DamageType.Crit, 0, 0.247, 0.753);
            AssertDamageEvent(expected, result.DamageEvents[17]);
        }

        private void AssertDamageEvent(DamageEvent expected, DamageEvent actual)
        {
            Assert.AreEqual(expected.Damage, actual.Damage, 0.01);
            Assert.AreEqual(expected.Timestamp, actual.Timestamp, 0.01);
            Assert.AreEqual(expected.DamageType, actual.DamageType);
            Assert.AreEqual(expected.CritChance, actual.CritChance, 0.001);
            Assert.AreEqual(expected.HitChance, actual.HitChance, 0.001);
            Assert.AreEqual(expected.MissChance, actual.MissChance, 0.001);
        }

        // TODO: Mock out the rolls to always hit, always miss, etc
    }
}
