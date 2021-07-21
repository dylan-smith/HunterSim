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

        // TODO: Test for enchants
    }
}
