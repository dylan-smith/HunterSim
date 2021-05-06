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

        [TestMethod]
        public void LeaderOfThePack()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.LeaderOfThePack);

            // 5% base crit + 3% buff
            Assert.AreEqual(0.05 + 0.03, MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 3% buff
            Assert.AreEqual(0.05 + 0.03, RangedCritCalculator.Calculate(state), 0.0001);
        }

        [TestMethod]
        public void MarkOfTheWild()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.MarkOfTheWild);

            Assert.AreEqual(285, ArmorCalculator.Calculate(state));

            // 121 base agi + 12 buff
            Assert.AreEqual(121 + 12, AgilityCalculator.Calculate(state), 0.001);
            // 57 base str + 12 buff
            Assert.AreEqual(57 + 12, StrengthCalculator.Calculate(state), 0.001);
            // 93 base sta + 12 buff
            Assert.AreEqual(93 + 12, StaminaCalculator.Calculate(state), 0.001);
            // 64 base int + 12 buff
            Assert.AreEqual(64 + 12, IntellectCalculator.Calculate(state), 0.001);
            // 69 base spi + 12 buff
            Assert.AreEqual(69 + 12, SpiritCalculator.Calculate(state), 0.001);

            Assert.AreEqual(20, ArcaneResistanceCalculator.Calculate(state));
            Assert.AreEqual(20, FireResistanceCalculator.Calculate(state));
            Assert.AreEqual(20, FrostResistanceCalculator.Calculate(state));
            Assert.AreEqual(20, NatureResistanceCalculator.Calculate(state));
            Assert.AreEqual(20, ShadowResistanceCalculator.Calculate(state));
        }

        [TestMethod]
        public void BlessingOfKings()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.BlessingOfKings);

            // 121 base agi + 10% buff
            Assert.AreEqual(121 * 1.1, AgilityCalculator.Calculate(state), 0.001);
            // 57 base str + 10% buff
            Assert.AreEqual(57 * 1.1, StrengthCalculator.Calculate(state), 0.001);
            // 93 base sta + 10% buff
            Assert.AreEqual(93 * 1.1, StaminaCalculator.Calculate(state), 0.001);
            // 64 base int + 10% buff
            Assert.AreEqual(64 * 1.1, IntellectCalculator.Calculate(state), 0.001);
            // 69 base spi + 10% buff
            Assert.AreEqual(69 * 1.1, SpiritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void BlessingOfMight()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.BlessingOfMight);

            // 121 base agi * 1 + 57 base str + 185 buff
            Assert.AreEqual(121 + 57 + 185, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void GraceOfAirTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.GraceOfAirTotem);

            // 121 base agi + 77 buff
            Assert.AreEqual(121 + 77, AgilityCalculator.Calculate(state));
        }

        [TestMethod]
        public void StrengthOfEarthTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.StrengthOfEarthTotem);

            // 57 base str + 77 buff
            Assert.AreEqual(57 + 77, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void ROIDS()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ROIDS);

            // 57 base str + 25 buff
            Assert.AreEqual(57 + 25, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void GroundScorpokAssay()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.GroundScorpokAssay);

            // 121 base agi + 25 buff
            Assert.AreEqual(121 + 25, AgilityCalculator.Calculate(state));
        }

        [TestMethod]
        public void ElixirOfTheMongoose()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ElixirOfTheMongoose);

            // 121 base agi + 25 buff
            Assert.AreEqual(121 + 25, AgilityCalculator.Calculate(state));

            // 5% base crit + 2% buff + 25 agi
            Assert.AreEqual(0.05 + 0.02 + (25.0 / 5300), MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 2% buff + 25 agi
            Assert.AreEqual(0.05 + 0.02 + (25.0 / 5300), RangedCritCalculator.Calculate(state), 0.0001);
        }

        [TestMethod]
        public void ElixirOfGreaterAgility()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ElixirOfGreaterAgility);

            // 121 base agi + 25 buff
            Assert.AreEqual(121 + 25, AgilityCalculator.Calculate(state));
        }

        [TestMethod]
        public void ElixirOfMongooseAndGreaterAgility()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ElixirOfGreaterAgility);
            state.Config.Buffs.Add(Buff.ElixirOfTheMongoose);

            // 121 base agi + 25 buff
            Assert.AreEqual(121 + 25, AgilityCalculator.Calculate(state));

            // 5% base crit + 2% buff + 25 agi
            Assert.AreEqual(0.05 + 0.02 + (25.0 / 5300), MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 2% buff + 25 agi
            Assert.AreEqual(0.05 + 0.02 + (25.0 / 5300), RangedCritCalculator.Calculate(state), 0.0001);
        }

        [TestMethod]
        public void JujuPower()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.JujuPower);

            // 57 base str + 30 buff
            Assert.AreEqual(57 + 30, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void ElixirOfGiants()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ElixirOfGiants);

            // 57 base str + 25 buff
            Assert.AreEqual(57 + 25, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void ElixirOfGiantsAndJujuPower()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.ElixirOfGiants);
            state.Config.Buffs.Add(Buff.JujuPower);

            // 57 base str + 30 buff
            Assert.AreEqual(57 + 30, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void JujuMight()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.JujuMight);

            // 121 base agi * 1 + 57 base str + 40 buff
            Assert.AreEqual(121 + 57 + 40, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 40 buff
            Assert.AreEqual(242 + 40, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void WinterfallFirewater()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.WinterfallFirewater);

            // 121 base agi * 1 + 57 base str + 35 buff
            Assert.AreEqual(121 + 57 + 35, MeleeAttackPowerCalculator.Calculate(state));
            // Firewater is melee ap only, check to make sure ranged ap didn't change
            Assert.AreEqual(242, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void JujuMightAndWinterfallFirewater()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.JujuMight);
            state.Config.Buffs.Add(Buff.WinterfallFirewater);

            // 121 base agi * 1 + 57 base str + 40 buff
            Assert.AreEqual(121 + 57 + 40, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 40 buff
            Assert.AreEqual(242 + 40, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void SmokedDesertDumplings()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.SmokedDesertDumplings);

            // 57 base str + 20 buff
            Assert.AreEqual(57 + 20, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void GrilledSquid()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.GrilledSquid);

            // 121 base agi + 10 buff
            Assert.AreEqual(121 + 10, AgilityCalculator.Calculate(state));
        }

        // TODO: Can only have one food buff active at a time

        [TestMethod]
        public void BlessedSunfruit()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.BlessedSunfruit);

            // 57 base str + 10 buff
            Assert.AreEqual(57 + 10, StrengthCalculator.Calculate(state));
        }

        [TestMethod]
        public void BoglingRoot()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.Buffs.Add(Buff.BoglingRoot);
            var weapon = new GearItem
            {
                GearType = GearType.Ranged
            };

            Assert.AreEqual(1, BonusDamageCalculator.Calculate(weapon, state));
        }

        [TestMethod]
        public void DarkDesire()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Dwarf;
            state.Config.PlayerSettings.Level = 60;
            state.Config.BossSettings.Level = 63;
            state.Config.Buffs.Add(Buff.DarkDesire);

            Assert.AreEqual(0.07, MissChanceCalculator.Calculate(WeaponType.Bow, state));
        }
    }
}
