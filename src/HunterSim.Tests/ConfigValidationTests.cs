using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class ConfigValidationTests
    {
        [TestMethod]
        public void ValidationPasses()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(0, state.Errors.Count);
            Assert.AreEqual(0, state.Warnings.Count);
        }

        [TestMethod]
        public void TooManyFoodBuffs()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Buffs.Add(Buff.BlessedSunfruit);
            state.Config.Buffs.Add(Buff.SmokedDesertDumplings);

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(1, state.Warnings.Count);
            Assert.AreEqual(SimulationWarnings.TooManyFoodBuffs, state.Warnings[0]);
        }

        [TestMethod]
        public void MissingGear()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Gear.Neck = null;

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(1, state.Warnings.Count);
            Assert.AreEqual(SimulationWarnings.MissingGear, state.Warnings[0]);
        }
    }
}
