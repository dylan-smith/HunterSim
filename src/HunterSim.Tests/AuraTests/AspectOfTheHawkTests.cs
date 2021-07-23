using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.AuraTests
{
    [TestClass]
    public class AspectOfTheHawkTests
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
    }
}
