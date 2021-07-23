using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class TrueshotAuraTests
    {
        [TestMethod]
        public void TrueShotAura()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            // 121 base agi * 1 + 57 base str + 100 talent
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 talent
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 121 base agi * 1 + 57 base str + 100 talent
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 talent
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }
    }
}
