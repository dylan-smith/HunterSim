using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.GearSetTests
{
    [TestClass]
    public class FelstalkerArmorTests
    {
        [TestMethod]
        public void NoSetBonus()
        {
            var config = new SimulationConfig();

            var sim = new Simulation(config);

            sim.Initialize();

            Assert.AreEqual(0, config.Gear.GetStatTotal(x => x.AttackPower));
        }

        [TestMethod]
        public void ThreePieces()
        {
            var config = new SimulationConfig();

            config.Gear.Waist = GearItemFactory.LoadWaist("Felstalker Belt");
            config.Gear.Wrist = GearItemFactory.LoadWrist("Felstalker Bracers");
            config.Gear.Chest = GearItemFactory.LoadChest("Felstalker Breastplate");

            var sim = new Simulation(config);

            sim.Initialize();

            Assert.AreEqual(20, config.Gear.GetStatTotal(x => x.HitRating));
        }
    }
}
