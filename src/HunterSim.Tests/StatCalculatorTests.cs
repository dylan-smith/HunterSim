using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterSim.Tests
{
    [TestClass]
    public class StatCalculatorTests
    {
        [TestMethod]
        public void StrengthCalculatorWithGemsAndSocketBonus()
        {
            var gear = new GearItem();
            gear.Strength = 7;

            var gem1 = new GearItem();
            gem1.Strength = 3;
            gem1.Agility = 27;
            gem1.Color = GemColor.Red;

            var gem2 = new GearItem();
            gem2.Strength = 6;
            gem2.Defense = 12;
            gem2.Color = GemColor.Blue;

            gear.Sockets.Add(new Socket() { Color = SocketColor.Red, Gem = gem1 });
            gear.Sockets.Add(new Socket() { Color = SocketColor.Blue, Gem = gem2 });

            var bonus = new GearItem();
            bonus.Agility = 11;
            bonus.Strength = 33;

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
