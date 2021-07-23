using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class TrueshotAuraTests
    {
        [TestMethod]
        public void TrueShotAuraFromTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            Assert.AreEqual(Constants.DRAENEI_STR + 125, MeleeAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(Constants.DRAENEI_AGI + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.TrueshotAura);

            Assert.AreEqual(Constants.DRAENEI_STR + 125, MeleeAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(Constants.DRAENEI_AGI + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            Assert.AreEqual(Constants.DRAENEI_STR + 125, MeleeAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(Constants.DRAENEI_AGI + 125, RangedAttackPowerCalculator.Calculate(state));
        }
    }
}
