using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class LethalShotsTests
    {
        [TestMethod]
        public void LethalShots()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.LethalShots, 5);

            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
        }
    }
}
