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

            Assert.AreEqual(Constants.DRAENEI_AGI * 1.1, AgilityCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_STR * 1.1, StrengthCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_STA * 1.1, StaminaCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_INT * 1.1, IntellectCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_SPI * 1.1, SpiritCalculator.Calculate(state), 0.001);
        }
    }
}
