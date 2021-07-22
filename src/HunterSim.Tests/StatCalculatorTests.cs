using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class StatCalculatorTests
    {
        [TestMethod]
        public void StrengthCalculatorWithGemsAndSocketBonus()
        {
            var gear = new GearItem
            {
                Strength = 7
            };

            var gem1 = new GearItem
            {
                Strength = 3,
                Agility = 27,
                Color = GemColor.Red
            };

            var gem2 = new GearItem
            {
                Strength = 6,
                Defense = 12,
                Color = GemColor.Blue
            };

            gear.Sockets.Add(new Socket() { Color = SocketColor.Red, Gem = gem1 });
            gear.Sockets.Add(new Socket() { Color = SocketColor.Blue, Gem = gem2 });

            var bonus = new GearItem
            {
                Agility = 11,
                Strength = 33
            };

            gear.SocketBonus = bonus;

            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Gear.Head = gear;

            // 65 base strength + 49 from gear
            Assert.AreEqual(114, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void DodgeCalculatorBaseStats()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;

            // 148 base agi / 25
            Assert.AreEqual(0.0592, DodgeCalculator.Calculate(state), 0.000001);
        }

        [TestMethod]
        public void CritCalculatorBaseStats()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;

            // 148 base agi / 25
            Assert.AreEqual(0.0, RangedCritCalculator.Calculate(state), 0.000001);
        }

        // TODO: Tests for all calculators that need to convert between rating and %
        // TODO: Should probably have a test for each calculator for base stats
        // TODO: Test for enchants
    }
}