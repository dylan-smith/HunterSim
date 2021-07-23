using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class KillerInstinctTests
    {
        [TestMethod]
        public void KillerInstinct()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.KillerInstinct, 3);

            // 5% base crit + 3% talent
            Assert.AreEqual(0.05 + 0.03, MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 3% buff
            Assert.AreEqual(0.05 + 0.03, RangedCritCalculator.Calculate(state), 0.0001);
            // 0% base crit + 3% buff
            Assert.AreEqual(0.03, SpellCritCalculator.Calculate(state), 0.001);
        }
    }
}
