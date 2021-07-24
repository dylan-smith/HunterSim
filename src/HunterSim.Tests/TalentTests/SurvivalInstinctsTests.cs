using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class SurvivalInstinctsTests
    {
        [TestMethod]
        public void SurvivalInstincts()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.SurvivalInstincts, 2);

            Assert.AreEqual(Constants.DRAENEI_AGI * 1.04, RangedAttackPowerCalculator.Calculate(state), 0.00001);
            Assert.AreEqual((Constants.DRAENEI_STR + Constants.DRAENEI_AGI) * 1.04, MeleeAttackPowerCalculator.Calculate(state), 0.00001);
        }
    }
}
