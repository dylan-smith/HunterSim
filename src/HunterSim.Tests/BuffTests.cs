using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class BuffTests
    {
        [TestMethod]
        public void OnyBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.RallyingCryOfTheDragonSlayer);

            // 121 base agi * 2 + 140 buff
            Assert.AreEqual(242 + 140, RangedAttackPowerCalculator.Calculate(state));
            // 121 base agi * 1 + 57 base str + 140 buff
            Assert.AreEqual(121 + 57 + 140, MeleeAttackPowerCalculator.Calculate(state));
            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, MeleeCritCalculator.Calculate(state), 0.001);
            // 0% base crit + 10% buff
            Assert.AreEqual(0.1, SpellCritCalculator.Calculate(state), 0.01);
        }

        [TestMethod]
        public void ZGBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SpiritOfZandalar);

            // 121 base agi + 15% buff
            Assert.AreEqual(121 * 1.15, AgilityCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void SongflowerBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SongflowerSerenade);

            // 121 base agi + 15 buff
            Assert.AreEqual(121 + 15, AgilityCalculator.Calculate(state), 0.001);
            // 57 base str + 15 buff
            Assert.AreEqual(57 + 15, StrengthCalculator.Calculate(state), 0.001);
            // 93 base sta + 15 buff
            Assert.AreEqual(93 + 15, StaminaCalculator.Calculate(state), 0.001);
            // 69 base spi + 15 buff
            Assert.AreEqual(69 + 15, SpiritCalculator.Calculate(state), 0.001);
            // 64 base int + 15 buff
            Assert.AreEqual(64 + 15, IntellectCalculator.Calculate(state), 0.001);

            // 5% base crit + 5% buff + 15 buff agi
            Assert.AreEqual(0.05 + 0.05 + 0.0028, RangedCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 5% buff + 15 buff agi
            Assert.AreEqual(0.05 + 0.05 + 0.0028, RangedCritCalculator.Calculate(state), 0.0001);
            // 0% base crit + 5% buff
            Assert.AreEqual(0.05, SpellCritCalculator.Calculate(state), 0.01);
        }

        [TestMethod]
        public void WarchiefsBlessingBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.WarchiefsBlessing);

            Assert.AreEqual(0.15, HasteCalculator.Calculate(state), 0.01);
        }
    }
}
