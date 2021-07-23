using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class MarkOfTheWildTests
    {
        [TestMethod]
        public void MarkOfTheWild()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.MarkOfTheWild);

            // (148 agi + 14 agi) * 2 + 340 buff
            Assert.AreEqual(324 + 340, ArmorCalculator.Calculate(state));

            // 148 base agi + 14 buff
            Assert.AreEqual(148 + 14, AgilityCalculator.Calculate(state), 0.001);
            // 65 base str + 14 buff
            Assert.AreEqual(65 + 14, StrengthCalculator.Calculate(state), 0.001);
            // 107 base sta + 14 buff
            Assert.AreEqual(107 + 14, StaminaCalculator.Calculate(state), 0.001);
            // 78 base int + 14 buff
            Assert.AreEqual(78 + 14, IntellectCalculator.Calculate(state), 0.001);
            // 85 base spi + 14 buff
            Assert.AreEqual(85 + 14, SpiritCalculator.Calculate(state), 0.001);

            Assert.AreEqual(25, ArcaneResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, FireResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, FrostResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, NatureResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, ShadowResistanceCalculator.Calculate(state));
        }
    }
}
