using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HunterSim.Tests
{
    [TestClass]
    public class BuffTests
    {
        [TestMethod]
        public void OnyBuff()
        {
            var state = new SimulationState();
            state.Config = new SimulationConfig();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.RallyingCryOfTheDragonSlayer);

            // 121 base agi * 2 + 140 buff
            Assert.AreEqual(242 + 140, RangedAttackPowerCalculator.Calculate(state));
            // 121 base agi * 1 + 140 buff
            Assert.AreEqual(121 + 140, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi + 5% base crit + 5% buff
            Assert.AreEqual(0.023 + 0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void ZGBuff()
        {
            var state = new SimulationState();
            state.Config = new SimulationConfig();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SpiritOfZandalar);

            // 121 base agi + 15% buff
            Assert.AreEqual(121 * 1.15, AgilityCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void SongflowerBuff()
        {
            var state = new SimulationState();
            state.Config = new SimulationConfig();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SongflowerSerenade);

            // 121 base agi + 15 buff agi
            Assert.AreEqual(121 + 15, AgilityCalculator.Calculate(state), 0.001);
            // 121 base agi + 15 buff agi + 5% base crit + 5% buff
            Assert.AreEqual(0.026 + 0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void WarchiefsBlessingBuff()
        {
            var state = new SimulationState();
            state.Config = new SimulationConfig();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.WarchiefsBlessing);

            Assert.AreEqual(0.15, HasteCalculator.Calculate(state), 0.01);
        }
    }
}
