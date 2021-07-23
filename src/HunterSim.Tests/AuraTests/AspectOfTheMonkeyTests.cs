using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.AuraTests
{
    [TestClass]
    public class AspectOfTheMonkeyTests
    {
        [TestMethod]
        public void AspectOfTheMonkey()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Auras.Add(Aura.AspectOfTheMonkey);

            // 148 base agi / 25 + 8%
            Assert.AreEqual(0.0592 * 1.08, DodgeCalculator.Calculate(state));
        }
    }
}
