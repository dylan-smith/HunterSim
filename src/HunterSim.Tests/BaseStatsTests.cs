using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HunterSim.Tests
{
    [TestClass]
    public class BaseStatsTests
    {
        [TestMethod]
        public void Dwarf()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;

            Assert.AreEqual(57, StrengthCalculator.Calculate(state));
            Assert.AreEqual(121, AgilityCalculator.Calculate(state));
            Assert.AreEqual(93, StaminaCalculator.Calculate(state));
            Assert.AreEqual(64, IntellectCalculator.Calculate(state));
            Assert.AreEqual(69, SpiritCalculator.Calculate(state));
            // Base Health + Stamina * 10
            Assert.AreEqual(1467 + 930, HealthCalculator.Calculate(state));
            // Base Mana + Intellect * 15
            Assert.AreEqual(1720 + 960, ManaCalculator.Calculate(state));
        }

        [TestMethod]
        public void NightElf()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.NightElf;

            Assert.AreEqual(52, StrengthCalculator.Calculate(state));
            Assert.AreEqual(130, AgilityCalculator.Calculate(state));
            Assert.AreEqual(89, StaminaCalculator.Calculate(state));
            Assert.AreEqual(65, IntellectCalculator.Calculate(state));
            Assert.AreEqual(70, SpiritCalculator.Calculate(state));
            // Base Health + Stamina * 10
            Assert.AreEqual(1467 + 890, HealthCalculator.Calculate(state));
            // Base Mana + Intellect * 15
            Assert.AreEqual(1720 + 975, ManaCalculator.Calculate(state));
        }

        [TestMethod]
        public void Orc()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Orc;

            Assert.AreEqual(58, StrengthCalculator.Calculate(state));
            Assert.AreEqual(122, AgilityCalculator.Calculate(state));
            Assert.AreEqual(92, StaminaCalculator.Calculate(state));
            Assert.AreEqual(62, IntellectCalculator.Calculate(state));
            Assert.AreEqual(73, SpiritCalculator.Calculate(state));
            // Base Health + Stamina * 10
            Assert.AreEqual(1467 + 920, HealthCalculator.Calculate(state));
            // Base Mana + Intellect * 15
            Assert.AreEqual(1720 + 930, ManaCalculator.Calculate(state));
        }

        [TestMethod]
        public void Tauren()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Tauren;

            Assert.AreEqual(60, StrengthCalculator.Calculate(state));
            Assert.AreEqual(120, AgilityCalculator.Calculate(state));
            Assert.AreEqual(92, StaminaCalculator.Calculate(state));
            Assert.AreEqual(60, IntellectCalculator.Calculate(state));
            Assert.AreEqual(72, SpiritCalculator.Calculate(state));
            // Base Health + Stamina * 10
            Assert.AreEqual(1467 + 920, HealthCalculator.Calculate(state));
            // Base Mana + Intellect * 15
            Assert.AreEqual(1720 + 900, ManaCalculator.Calculate(state));
        }

        [TestMethod]
        public void Troll()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Troll;

            Assert.AreEqual(56, StrengthCalculator.Calculate(state));
            Assert.AreEqual(127, AgilityCalculator.Calculate(state));
            Assert.AreEqual(91, StaminaCalculator.Calculate(state));
            Assert.AreEqual(61, IntellectCalculator.Calculate(state));
            Assert.AreEqual(71, SpiritCalculator.Calculate(state));
            // Base Health + Stamina * 10
            Assert.AreEqual(1467 + 910, HealthCalculator.Calculate(state));
            // Base Mana + Intellect * 15
            Assert.AreEqual(1720 + 915, ManaCalculator.Calculate(state));
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void NoRace()
        {
            var state = new SimulationState();

            var agility = AgilityCalculator.Calculate(state);
        }
    }
}
