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

            Assert.AreEqual(Constants.DRAENEI_AGI + 440, RangedAttackPowerCalculator.Calculate(state));
            // buff shouldn't affect melee ap
            Assert.AreEqual(Constants.DRAENEI_STR, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
