﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.Buffs
{
    [TestClass]
    public class ImprovedBlessingOfMightTests
    {
        [TestMethod]
        public void ImprovedBlessingOfMight()
        {
            var state = new SimulationState();
            state.Config.Buffs.Add(Buff.ImprovedBlessingOfMight);

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), new FakeStatCalculator(0.0));
            BaseStatCalculator.InjectMock(typeof(StrengthCalculator), new FakeStatCalculator(0.0));

            Assert.AreEqual(264, RangedAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(264, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
