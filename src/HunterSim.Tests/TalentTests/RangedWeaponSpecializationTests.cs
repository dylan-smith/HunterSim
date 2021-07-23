using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class RangedWeaponSpecializationTests
    {
        [TestMethod]
        public void RangedWeaponSpecialization()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.RangedWeaponSpecialization, 5);

            Assert.AreEqual(1.05, DamageMultiplierCalculator.Calculate(state), 0.001);
        }
    }
}
