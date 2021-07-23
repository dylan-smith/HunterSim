﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HunterSim.Tests.ProcTests
{
    [TestClass]
    public class ImprovedAspectOfTheHawkTests
    {
        [TestMethod]
        public void ImprovedAspectOfTheHawkProcOnHit()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.AspectOfTheHawk);

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0) { DamageEvent = new DamageEvent(2.0, 0.0, DamageType.Hit, 0.0, 0.0, 0.0) };
            EventPublisher.PublishEvent(e, state);

            Assert.AreEqual(1, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)));
            Assert.AreEqual(2.0, state.Events.First(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)).Timestamp);
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkDoesNotProcOnMiss()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.AspectOfTheHawk);

            var e = new AutoShotCompletedEvent(2.0) { DamageEvent = new DamageEvent(2.0, 0.0, DamageType.Miss, 0.0, 0.0, 0.0) };
            EventPublisher.PublishEvent(e, state);

            Assert.AreEqual(0, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)));
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkProcOnCrit()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.AspectOfTheHawk);

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0) { DamageEvent = new DamageEvent(2.0, 0.0, DamageType.Crit, 0.0, 0.0, 0.0) };
            EventPublisher.PublishEvent(e, state);

            Assert.AreEqual(1, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)));
            Assert.AreEqual(2.0, state.Events.First(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)).Timestamp);
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkProcChance()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.AspectOfTheHawk);

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.11);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0) { DamageEvent = new DamageEvent(2.0, 0.0, DamageType.Crit, 0.0, 0.0, 0.0) };
            EventPublisher.PublishEvent(e, state);

            Assert.AreEqual(0, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)));
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkOnlyProcsIfAspectIsActive()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0) { DamageEvent = new DamageEvent(2.0, 0.0, DamageType.Hit, 0.0, 0.0, 0.0) };
            EventPublisher.PublishEvent(e, state);

            Assert.AreEqual(0, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProcEvent)));
        }
    }
}
