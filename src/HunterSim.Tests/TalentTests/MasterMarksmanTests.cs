using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class MasterMarksmanTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            BaseStatCalculator.ClearMocks();
        }

        [TestMethod]
        public void MasterMarksman()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.MasterMarksman, 5);

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(100.0));

            Assert.AreEqual(110.0, RangedAttackPowerCalculator.Calculate(state), 0.00001);
        }
    }
}
