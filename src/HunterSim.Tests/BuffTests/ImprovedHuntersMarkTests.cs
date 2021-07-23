using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class ImprovedHuntersMarkTests
    {
        [TestMethod]
        public void ImprovedHuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 buff
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedHuntersMarkBuffAndTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 5);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 buff
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
