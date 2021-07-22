using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class AuraTests
    {
        [TestMethod]
        public void AspectOfTheHawk()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Auras.Add(Aura.AspectOfTheHawk);

            // 148 base agi + 155 talent
            Assert.AreEqual(148 + 155, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void AspectOfTheMonkey()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Auras.Add(Aura.AspectOfTheMonkey);

            // 148 base agi / 25 + 8%
            Assert.AreEqual(0.0592 * 1.08, DodgeCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawk()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.ImprovedAspectOfTheHawk);

            Assert.AreEqual(0.15, RangedHasteCalculator.Calculate(state), 0.0001);
        }
    }
}
