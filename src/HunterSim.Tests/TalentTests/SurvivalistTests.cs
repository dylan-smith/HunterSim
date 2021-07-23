﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class SurvivalistTests
    {
        [TestMethod]
        public void Survivalist()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.Survivalist, 5);

            // Base Health + Stamina * 10 * 1.1
            Assert.AreEqual((1467 + 930) * 1.1, HealthCalculator.Calculate(state));
        }
    }
}
