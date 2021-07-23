using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class EnhancedBattleShoutTests
    {
        [TestMethod]
        public void EnhancedBattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedBattleShout);

            // 65 base str + 381 buff
            Assert.AreEqual(65 + 381, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
