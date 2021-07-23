using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class GraceOfAirTotemTests
    {
        [TestMethod]
        public void GraceOfAirTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.GraceOfAirTotem);

            // 148 base agi + 77 buff
            Assert.AreEqual(148 + 77, AgilityCalculator.Calculate(state));
        }

        // TODO: Improved Grace of Air
    }
}
