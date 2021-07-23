using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class ImprovedHuntersMarkTests
    {
        [TestMethod]
        public void ImprovedHuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.HuntersMark);
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 3);

            // 148 base agi + 440 hunters mark
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 * 60% improved hunters mark
            Assert.AreEqual(65 + (110 * 0.6), MeleeAttackPowerCalculator.Calculate(state));
        }

        // TODO: Isn't this identical to the above test?
        [TestMethod]
        public void ImprovedHuntersMarkTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 3);
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);

            // 148 base agi + 440 hunters mark
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 improved hunters mark
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
