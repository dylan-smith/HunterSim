using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HunterSim.Tests
{
    [TestClass]
    public class GearItemTests
    {
        [TestMethod]
        public void TotalStrength()
        {
            var gear = new GearItem();
            gear.Strength = 7;

            Assert.AreEqual(7, gear.TotalStrength);
        }

        [TestMethod]
        public void TotalStrengthWithEmptySockets()
        {
            var gear = new GearItem();
            gear.Strength = 7;
            gear.Sockets.Add(new Socket() { Color = SocketColor.Red });

            Assert.AreEqual(7, gear.TotalStrength);
        }

        [TestMethod]
        public void TotalStrengthWithGems()
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
            gem2.Color = GemColor.Red;

            gear.Sockets.Add(new Socket() { Color = SocketColor.Red, Gem = gem1 });
            gear.Sockets.Add(new Socket() { Color = SocketColor.Red, Gem = gem2 });

            Assert.AreEqual(16, gear.TotalStrength);
        }

        [TestMethod]
        public void TotalStrengthWithActiveSocketBonus()
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

            Assert.AreEqual(49, gear.TotalStrength);
        }

        [TestMethod]
        public void TotalStrengthWithInactiveSocketBonus()
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
            gem2.Color = GemColor.Yellow;

            gear.Sockets.Add(new Socket() { Color = SocketColor.Red, Gem = gem1 });
            gear.Sockets.Add(new Socket() { Color = SocketColor.Blue, Gem = gem2 });

            var bonus = new GearItem();
            bonus.Agility = 11;
            bonus.Strength = 33;

            gear.SocketBonus = bonus;

            Assert.AreEqual(16, gear.TotalStrength);
        }
    }
}
