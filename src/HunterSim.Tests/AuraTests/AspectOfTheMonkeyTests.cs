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

            Assert.AreEqual(Constants.DRAENEI_AGI / 2500 * 1.08, DodgeCalculator.Calculate(state));
        }
    }
}
