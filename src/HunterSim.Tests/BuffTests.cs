using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class BuffTests
    {
        [TestMethod]
        public void OnyBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.RallyingCryOfTheDragonSlayer);

            // 0% base crit + 10% buff
            Assert.AreEqual(0.1, SpellCritCalculator.Calculate(state), 0.01);
            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, MeleeCritCalculator.Calculate(state), 0.001);
            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
            // 121 base agi * 1 + 57 base str + 140 buff
            Assert.AreEqual(121 + 57 + 140, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 140 buff
            Assert.AreEqual(242 + 140, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ZGBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SpiritOfZandalar);

            Assert.AreEqual(1.10, MovementSpeedCalculator.Calculate(state));
            // 121 base agi + 15% buff
            Assert.AreEqual(121 * 1.15, AgilityCalculator.Calculate(state), 0.001);
            // 57 base str + 15% buff
            Assert.AreEqual(57 * 1.15, StrengthCalculator.Calculate(state), 0.001);
            // 93 base sta + 15% buff
            Assert.AreEqual(93 * 1.15, StaminaCalculator.Calculate(state), 0.001);
            // 64 base int + 15% buff
            Assert.AreEqual(64 * 1.15, IntellectCalculator.Calculate(state), 0.001);
            // 69 base spi + 15% buff
            Assert.AreEqual(69 * 1.15, SpiritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void SongflowerBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SongflowerSerenade);

            // 5% base crit + 5% buff + 15 buff agi
            Assert.AreEqual(0.05 + 0.05 + 0.0028, MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 5% buff + 15 buff agi
            Assert.AreEqual(0.05 + 0.05 + 0.0028, RangedCritCalculator.Calculate(state), 0.0001);
            // 0% base crit + 5% buff
            Assert.AreEqual(0.05, SpellCritCalculator.Calculate(state), 0.01);

            // 121 base agi + 15 buff
            Assert.AreEqual(121 + 15, AgilityCalculator.Calculate(state), 0.001);
            // 57 base str + 15 buff
            Assert.AreEqual(57 + 15, StrengthCalculator.Calculate(state), 0.001);
            // 93 base sta + 15 buff
            Assert.AreEqual(93 + 15, StaminaCalculator.Calculate(state), 0.001);
            // 64 base int + 15 buff
            Assert.AreEqual(64 + 15, IntellectCalculator.Calculate(state), 0.001);
            // 69 base spi + 15 buff
            Assert.AreEqual(69 + 15, SpiritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void WarchiefsBlessingBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.WarchiefsBlessing);

            // 1467 base health + 93 sta + 300 buff
            Assert.AreEqual(1467 + 930 + 300, HealthCalculator.Calculate(state));
            Assert.AreEqual(0.15, HasteCalculator.Calculate(state), 0.01);
            Assert.AreEqual(10, MP5Calculator.Calculate(state));
        }

        [TestMethod]
        public void FengusFerocity()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.FengusFerocity);

            // 121 base agi * 1 + 57 base str + 200 buff
            Assert.AreEqual(121 + 57 + 200, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 200 buff
            Assert.AreEqual(242 + 200, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void MoldarsMoxie()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.MoldarsMoxie);

            // 93 base sta + 15% buff
            Assert.AreEqual(93 * 1.15, StaminaCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void SlipkiksSavvy()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SlipkiksSavvy);

            Assert.AreEqual(0.03, SpellCritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void DarkFortuneOfDamage()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SaygesDarkFortuneOfDamage);

            Assert.AreEqual(1.1, DamageMultiplierCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void BattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.BattleShout);

            // 121 base agi * 1 + 57 base str + 290 buff
            Assert.AreEqual(121 + 57 + 290, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void EnhancedBattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.EnhancedBattleShout);

            // 121 base agi * 1 + 57 base str + 320 buff
            Assert.AreEqual(121 + 57 + 320, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAura()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 121 base agi * 1 + 57 base str + 100 buff
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 buff
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            // 121 base agi * 1 + 57 base str + 100 buff
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 buff
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 121 base agi * 1 + 57 base str + 100 buff
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 buff
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }
    }
}
