using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class TrueshotAuraTests
    {
        [TestMethod]
        public void TrueShotAura()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }
    }
}
