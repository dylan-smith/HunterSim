﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.TalentTests
{
    [TestClass]
    public class FocusedFireTests
    {
        [TestMethod]
        public void FocusedFire()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.FocusedFire, 2);

            Assert.AreEqual(1.02, DamageMultiplierCalculator.Calculate(state), 0.00001);
        }

        // TODO: test for the increased crit on Kill Command once we have Kill Command implemented
    }
}
