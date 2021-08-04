using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class ImprovedMarkOfTheWildTests
    {
        [TestMethod]
        public void ImprovedMarkOfTheWild()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedMarkOfTheWild);

            Assert.AreEqual(((Constants.DRAENEI_AGI + 18.9) * 2) + 459, ArmorCalculator.Calculate(state), 0.0001);

            Assert.AreEqual(Constants.DRAENEI_AGI + 18.9, AgilityCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_STR + 18.9, StrengthCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_STA + 18.9, StaminaCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_INT + 18.9, IntellectCalculator.Calculate(state), 0.001);
            Assert.AreEqual(Constants.DRAENEI_SPI + 18.9, SpiritCalculator.Calculate(state), 0.001);

            Assert.AreEqual(33.75, ArcaneResistanceCalculator.Calculate(state));
            Assert.AreEqual(33.75, FireResistanceCalculator.Calculate(state));
            Assert.AreEqual(33.75, FrostResistanceCalculator.Calculate(state));
            Assert.AreEqual(33.75, NatureResistanceCalculator.Calculate(state));
            Assert.AreEqual(33.75, ShadowResistanceCalculator.Calculate(state));
        }
    }
}
