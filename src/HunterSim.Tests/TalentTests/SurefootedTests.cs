using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class SurefootedTests
    {
        [TestMethod]
        public void Surefooted()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.PlayerSettings.Level = 60;
            state.Config.BossSettings.Level = 63;
            state.Config.Talents.Add(Talent.Surefooted, 3);

            // 9% base chance to miss - 3% from talent
            Assert.AreEqual(0.06, MissChanceCalculator.Calculate(new GearItem() { WeaponType = WeaponType.Bow }, state), 0.001);
        }
    }
}
