using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests.GearSetTests
{
    [TestClass]
    public class BeastLordArmorTests
    {
        [TestMethod]
        public void NoSetBonus()
        {
            var config = new SimulationConfig();

            var sim = new Simulation(config);

            sim.Initialize();

            Assert.IsTrue(!sim.State.Auras.Contains(Aura.TrapCooldown));
            Assert.IsTrue(!sim.State.Auras.Contains(Aura.ImprovedKillCommand));
        }

        [TestMethod]
        public void TwoPieces()
        {
            var config = new SimulationConfig();

            config.Gear.Head = GearItemFactory.LoadHead("Beast Lord Helm");
            config.Gear.Shoulder = GearItemFactory.LoadShoulder("Beast Lord Mantle");
            config.Gear.Hands = GearItemFactory.LoadHands("Beast Lord Handguards");

            var sim = new Simulation(config);

            sim.Initialize();

            Assert.IsTrue(sim.State.Auras.Contains(Aura.TrapCooldown));
            Assert.IsTrue(!sim.State.Auras.Contains(Aura.ImprovedKillCommand));
        }

        [TestMethod]
        public void FourPieces()
        {
            var config = new SimulationConfig();

            config.Gear.Head = GearItemFactory.LoadHead("Beast Lord Helm");
            config.Gear.Shoulder = GearItemFactory.LoadShoulder("Beast Lord Mantle");
            config.Gear.Hands = GearItemFactory.LoadHands("Beast Lord Handguards");
            config.Gear.Chest = GearItemFactory.LoadChest("Beast Lord Cuirass");

            var sim = new Simulation(config);

            sim.Initialize();

            Assert.IsTrue(sim.State.Auras.Contains(Aura.TrapCooldown));
            Assert.IsTrue(sim.State.Auras.Contains(Aura.ImprovedKillCommand));
        }
    }
}
