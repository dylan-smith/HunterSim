using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class BlessingOfMightTests
    {
        [TestMethod]
        public void BlessingOfMight()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BlessingOfMight);

            // 148 base agi + 220 buff
            Assert.AreEqual(148 + 220, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 220 buff
            Assert.AreEqual(65 + 220, MeleeAttackPowerCalculator.Calculate(state));
        }

        // TODO: Improved Blessing of Might
    }
}
