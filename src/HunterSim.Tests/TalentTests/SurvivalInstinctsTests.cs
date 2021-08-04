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

            // 148 * 1.04
            Assert.AreEqual(153, RangedAttackPowerCalculator.Calculate(state));
            // (65 + 148) * 1.04
            Assert.AreEqual(221, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
