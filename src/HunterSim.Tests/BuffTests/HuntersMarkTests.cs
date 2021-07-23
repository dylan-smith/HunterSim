using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class HuntersMarkTests
    {
        [TestMethod]
        public void HuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.HuntersMark);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str (buff shouldn't affect melee ap)
            Assert.AreEqual(65, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
