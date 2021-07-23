using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class LightningReflexesTests
    {
        [TestMethod]
        public void LightningReflexes()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.LightningReflexes, 5);

            // 121 base agi + 15% talent
            Assert.AreEqual(121 * 1.15, AgilityCalculator.Calculate(state), 0.001);
        }
    }
}
