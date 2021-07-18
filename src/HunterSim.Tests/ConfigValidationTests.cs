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

        [TestMethod]
        public void NotMaxLevel()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Talents.Remove(Talent.TrueshotAura);

            state.Config.PlayerSettings.Level = 59;

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(1, state.Warnings.Count);
            Assert.AreEqual(SimulationWarnings.PlayerNotMaxLevel, state.Warnings[0]);
        }

        [TestMethod]
        public void MissingTalentPoints()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Talents.Remove(Talent.TrueshotAura);

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(1, state.Warnings.Count);
            Assert.AreEqual(SimulationWarnings.MissingTalentPoints, state.Warnings[0]);
        }

        [TestMethod]
        public void TooManyTalentPoints()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Talents[Talent.ImprovedHuntersMark] = 3;

            Assert.IsTrue(state.Validate());
            Assert.AreEqual(1, state.Warnings.Count);
            Assert.AreEqual(SimulationWarnings.TooManyTalentPoints, state.Warnings[0]);
        }

        [TestMethod]
        public void NoRaceSelected()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.PlayerSettings.Race = Race.NotSet;

            Assert.IsFalse(state.Validate());
            Assert.AreEqual(1, state.Errors.Count);
            Assert.AreEqual(SimulationErrors.NoRaceSelected, state.Errors[0]);
        }

        [TestMethod]
        public void MissingRangedWeapon()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Config.Gear.Ranged = null;

            Assert.IsFalse(state.Validate());
            Assert.AreEqual(1, state.Errors.Count);
            Assert.AreEqual(SimulationErrors.MissingRangedWeapon, state.Errors[0]);
        }
    }
}
