using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class BattleShoutTests
    {
        [TestMethod]
        public void BattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BattleShout);

            // 65 base str + 290 buff
            Assert.AreEqual(65 + 305, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
