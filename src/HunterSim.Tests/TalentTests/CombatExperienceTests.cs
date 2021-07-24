using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class CombatExperienceTests
    {
        [TestMethod]
        public void CombatExperience()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.CombatExperience, 2);

            Assert.AreEqual(Constants.DRAENEI_AGI * 1.02, AgilityCalculator.Calculate(state), 0.00001);
            Assert.AreEqual(Constants.DRAENEI_INT * 1.06, IntellectCalculator.Calculate(state), 0.00001);
        }

        // TODO: test for the increased crit on Kill Command once we have Kill Command implemented
    }
}
