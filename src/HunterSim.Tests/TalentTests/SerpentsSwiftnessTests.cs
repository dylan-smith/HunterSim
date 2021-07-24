﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class SerpentsSwiftnessTests
    {
        [TestMethod]
        public void SerpentsSwiftness()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.SerpentsSwiftness, 5);

            Assert.AreEqual(0.2, RangedHasteCalculator.Calculate(state), 0.00001);
        }

        // TODO: test pet haste increase
    }
}
