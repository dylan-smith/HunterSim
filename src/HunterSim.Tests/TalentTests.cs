using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class TalentTests
    {
        // Beast Mastery Talents

        [TestMethod]
        public void ImprovedAspectOfTheHawk()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Auras.Add(Aura.AspectOfTheHawk);
            state.Auras.Add(Aura.ImprovedAspectOfTheHawk);

            // 148 base agi + 155 talent
            Assert.AreEqual(148 + 155, RangedAttackPowerCalculator.Calculate(state));
            Assert.AreEqual(0.15, RangedHasteCalculator.Calculate(state), 0.0001);
        }

        // TODO: Test the proc and the 5% chance for improved aspect of the hawk once we have rotations modelled (could probably do now with just auto-shot, assuming hawk is the default aspect)

        // TODO: Test Unleashed Fury once we have pet damage modelled
        // TODO: Test Ferocity once we have pet damage modelled
        // TODO: Test Bestial Discipline once we have pet focus modelled
        // TODO: Test Frenzy once we have pet damage modelled
        // TODO: Test Bestial Wrath ability once we have pet rotations modelled

        [TestMethod]
        public void PathfindingCheetah()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.Pathfinding, 2);
            state.Auras.Add(Aura.AspectOfTheCheetah);

            Assert.AreEqual(1.36, MovementSpeedCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void PathfindingPack()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.Pathfinding, 2);
            state.Auras.Add(Aura.AspectOfThePack);

            Assert.AreEqual(1.36, MovementSpeedCalculator.Calculate(state), 0.001);
        }

        // Marksmanship Talents

        [TestMethod]
        public void ImprovedHuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.HuntersMark);
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 5);

            // 121 base agi * 2 + 110 hunters mark * 15% improved
            Assert.AreEqual(242 + (110 * 1.15), RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedHuntersMarkTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 3);
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);

            // 121 base agi * 2 + 110 hunters mark * 15% improved
            Assert.AreEqual(242 + (110 * 1.15), RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void LethalShots()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.LethalShots, 5);

            // 5% base crit + 5% buff
            Assert.AreEqual(0.05 + 0.05, RangedCritCalculator.Calculate(state), 0.001);
        }

        // TODO: Test Efficiency once we have mana usage modelled
        // TODO: Test for Aimed Shot once we have rotations modelled
        // TODO: Test for Improved Arcane Shot once we have rotations modelled
        // TODO: Test for Improved Serpent Sting once we have rotations modelled
        // TODO: Test for Scatter Shot once we have rotations modelled
        // TODO: Test for Barrage once we have rotations modelled

        [TestMethod]
        public void MortalShots()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.MortalShots, 5);

            // Mortal shots only increases the BONUS crit damage by 30%, so overall damage is multiplied by 15%
            Assert.AreEqual(1.15, RangedCritDamageMultiplierCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void RangedWeaponSpecialization()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.RangedWeaponSpecialization, 5);

            Assert.AreEqual(1.05, DamageMultiplierCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void TrueShotAura()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            // 121 base agi * 1 + 57 base str + 100 talent
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 talent
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 121 base agi * 1 + 57 base str + 100 talent
            Assert.AreEqual(121 + 57 + 100, MeleeAttackPowerCalculator.Calculate(state));
            // 121 base agi * 2 + 100 talent
            Assert.AreEqual(242 + 100, RangedAttackPowerCalculator.Calculate(state));
        }

        // Survival

        // TODO: Test for Savage Strikes once we have Raptor Strike and/or Mongoose Bite modelled
        // TODO: Test for Wyvern Sting when we model rotations that include it

        [TestMethod]
        public void MonsterSlayingBeast()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.BossSettings.BossType = BossType.Beast;
            state.Config.Talents.Add(Talent.MonsterSlaying, 3);

            Assert.AreEqual(1.03, DamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, RangedCritDamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, MeleeCritDamageMultiplierCalculator.Calculate(state));
        }

        [TestMethod]
        public void MonsterSlayingGiant()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.BossSettings.BossType = BossType.Giant;
            state.Config.Talents.Add(Talent.MonsterSlaying, 3);

            Assert.AreEqual(1.03, DamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, RangedCritDamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, MeleeCritDamageMultiplierCalculator.Calculate(state));
        }

        [TestMethod]
        public void MonsterSlayingDragonkin()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.BossSettings.BossType = BossType.Dragonkin;
            state.Config.Talents.Add(Talent.MonsterSlaying, 3);

            Assert.AreEqual(1.03, DamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, RangedCritDamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, MeleeCritDamageMultiplierCalculator.Calculate(state));
        }

        [TestMethod]
        public void HumanoidSlaying()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.BossSettings.BossType = BossType.Humanoid;
            state.Config.Talents.Add(Talent.HumanoidSlaying, 3);

            Assert.AreEqual(1.03, DamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, RangedCritDamageMultiplierCalculator.Calculate(state));
            Assert.AreEqual(1.03, MeleeCritDamageMultiplierCalculator.Calculate(state));
        }

        [TestMethod]
        public void Survivalist()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.Survivalist, 5);

            // Base Health + Stamina * 10 * 1.1
            Assert.AreEqual((1467 + 930) * 1.1, HealthCalculator.Calculate(state));
        }

        [TestMethod]
        public void Surefooted()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.PlayerSettings.Level = 60;
            state.Config.BossSettings.Level = 63;
            state.Config.Talents.Add(Talent.Surefooted, 3);

            // 9% base chance to miss - 3% from talent
            Assert.AreEqual(0.06, MissChanceCalculator.Calculate(new GearItem() { WeaponType = WeaponType.Bow }, state), 0.001);
        }

        [TestMethod]
        public void KillerInstinct()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.KillerInstinct, 3);

            // 5% base crit + 3% talent
            Assert.AreEqual(0.05 + 0.03, MeleeCritCalculator.Calculate(state), 0.0001);
            // 5% base crit + 3% buff
            Assert.AreEqual(0.05 + 0.03, RangedCritCalculator.Calculate(state), 0.0001);
            // 0% base crit + 3% buff
            Assert.AreEqual(0.03, SpellCritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void LightningReflexes()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.LightningReflexes, 5);

            // 121 base agi + 15% talent
            Assert.AreEqual(121 * 1.15, AgilityCalculator.Calculate(state), 0.001);
        }
    }
}
