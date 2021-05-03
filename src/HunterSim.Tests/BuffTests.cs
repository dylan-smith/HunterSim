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

            // 121 base agi + buff
            Assert.AreEqual(242 + 140, RangedAttackPowerCalculator.Calculate(state));
            // 121 base agi + 5% base crit + buff
            Assert.AreEqual(0.023 + 0.05 + 0.05, CritChanceCalculator.Calculate(state), 0.001);
        }
    }
}
