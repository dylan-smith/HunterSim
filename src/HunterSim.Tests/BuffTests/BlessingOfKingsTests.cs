using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.BuffTests
{
    [TestClass]
    public class BlessingOfKingsTests
    {
        [TestMethod]
        public void BlessingOfKings()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BlessingOfKings);

            // 148 base agi + 10% buff
            Assert.AreEqual(148 * 1.1, AgilityCalculator.Calculate(state), 0.001);
            // 65 base str + 10% buff
            Assert.AreEqual(65 * 1.1, StrengthCalculator.Calculate(state), 0.001);
            // 107 base sta + 10% buff
            Assert.AreEqual(107 * 1.1, StaminaCalculator.Calculate(state), 0.001);
            // 78 base int + 10% buff
            Assert.AreEqual(78 * 1.1, IntellectCalculator.Calculate(state), 0.001);
            // 85 base spi + 10% buff
            Assert.AreEqual(85 * 1.1, SpiritCalculator.Calculate(state), 0.001);
        }
    }
}
