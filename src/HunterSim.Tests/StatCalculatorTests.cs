﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HunterSim.Tests
{
    [TestClass]
    public class StatCalculatorTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            BaseStatCalculator.ClearMocks();
        }

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

            gear.Sockets.Add(new Socket(SocketColor.Red) { Gem = gem1 });
            gear.Sockets.Add(new Socket(SocketColor.Blue) { Gem = gem2 });

            var bonus = new GearItem
            {
                Agility = 11,
                Strength = 33
            };

            gear.SocketBonus = bonus;

            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Gear.Head = gear;

            Assert.AreEqual(Constants.DRAENEI_STR + 49, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void DodgeCalculatorBaseStats()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;

            Assert.AreEqual(Constants.DRAENEI_AGI / 2500, DodgeCalculator.Calculate(state), 0.000001);
        }

        [TestMethod]
        public void CritCalculatorBaseStats()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;

            Assert.AreEqual(0.0, RangedCritCalculator.Calculate(state), 0.000001);
            Assert.AreEqual(0.0, MeleeCritCalculator.Calculate(state), 0.000001);
        }

        [TestMethod]
        public void CritCalculatorSuppressionAmount()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(Constants.AGI_FOR_ZERO_CRIT));
            Assert.AreEqual(0.0, RangedCritCalculator.Calculate(state));
            Assert.AreEqual(0.0, MeleeCritCalculator.Calculate(state));

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(Constants.AGI_FOR_ZERO_CRIT + 1));
            Assert.IsTrue(RangedCritCalculator.Calculate(state) > 0.0);
            Assert.IsTrue(MeleeCritCalculator.Calculate(state) > 0.0);
        }

        [TestMethod]
        public void CritCalculatorAgilityToCrit()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(Constants.AGI_FOR_ZERO_CRIT + 80));

            // https://tbc.wowhead.com/guides/classic-the-burning-crusade-stats-overview
            Assert.AreEqual(0.02, RangedCritCalculator.Calculate(state), 0.00001);
            Assert.AreEqual(0.02, MeleeCritCalculator.Calculate(state), 0.00001);
        }

        [TestMethod]
        public void CritCalculatorRatingToCrit()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(Constants.AGI_FOR_ZERO_CRIT));

            state.Config.Gear.Head = new GearItem() { CritRating = 44.16 };

            // https://tbc.wowhead.com/guides/classic-the-burning-crusade-stats-overview
            Assert.AreEqual(0.02, RangedCritCalculator.Calculate(state), 0.00001);
            Assert.AreEqual(0.02, MeleeCritCalculator.Calculate(state), 0.00001);
        }

        [TestMethod]
        public void RangedHasteCalculatorRatingToPercent()
        {
            var state = new SimulationState();

            state.Config.Gear.Head = new GearItem() { HasteRating = 300 };

            // https://tbc.wowhead.com/guides/classic-the-burning-crusade-stats-overview
            Assert.AreEqual(1.1899, RangedHasteCalculator.Calculate(state), 0.0001);
            Assert.AreEqual(1.1899, MeleeHasteCalculator.Calculate(state), 0.0001);
        }

        [TestMethod]
        public void DefaultConfigStats()
        {
            var state = new SimulationState
            {
                Config = new DefaultConfig()
            };

            state.Validate();

            Assert.AreEqual(227, StrengthCalculator.Calculate(state));
            Assert.AreEqual(1075, AgilityCalculator.Calculate(state));
            Assert.AreEqual(446, StaminaCalculator.Calculate(state));
            Assert.AreEqual(275, IntellectCalculator.Calculate(state));
            Assert.AreEqual(141, SpiritCalculator.Calculate(state));
            Assert.AreEqual(2533, MeleeAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(2484, RangedAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(124, RangedCritCalculator.Calculate(state));
            Assert.AreEqual(97, MP5Calculator.Calculate(state));
        }

        // TODO: Tests for all calculators that need to convert between rating and %
        // TODO: Should probably have a test for each calculator for base stats
        // TODO: Test for enchants
    }
}