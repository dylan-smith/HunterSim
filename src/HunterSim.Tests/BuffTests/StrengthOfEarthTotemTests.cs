using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class StrengthOfEarthTotemTests
    {
        [TestMethod]
        public void StrengthOfEarthTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.StrengthOfEarthTotem);

            // 65 base str + 86 buff
            Assert.AreEqual(65 + 86, StrengthCalculator.Calculate(state));
        }

        // TODO: Improved Strength of Earth
    }
}
