using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HunterSim.Tests
{
    [TestClass]
    public class TalentTests
    {
        // Beast Mastery Talents
        [TestMethod]
        public void ImprovedAspectOfTheHawkProcOnHit()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Config.Gear.Ranged = new GearItem
            {
                Speed = 2.9,
                WeaponType = WeaponType.Bow,
                MinDamage = 100,
                MaxDamage = 200,
            };

            InjectZeroMocks();

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.AutoShotMiss, 1.0);
            fakeRolls.SetRolls(RollType.AutoShotCrit, 1.0);
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0);
            e.ProcessEvent(state);

            Assert.AreEqual(1, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)));
            Assert.AreEqual(2.0, state.Events.First(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)).Timestamp);
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkDoesNotProcOnMiss()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Config.Gear.Ranged = new GearItem
            {
                Speed = 2.9,
                WeaponType = WeaponType.Bow,
                MinDamage = 100,
                MaxDamage = 200,
            };

            InjectZeroMocks();

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.AutoShotMiss, 0.0);
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0);
            e.ProcessEvent(state);

            Assert.AreEqual(0, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)));
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkProcOnCrit()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Config.Gear.Ranged = new GearItem
            {
                Speed = 2.9,
                WeaponType = WeaponType.Bow,
                MinDamage = 100,
                MaxDamage = 200,
            };

            InjectZeroMocks();

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.AutoShotMiss, 1.0);
            fakeRolls.SetRolls(RollType.AutoShotCrit, 0.0);
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.1);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0);
            e.ProcessEvent(state);

            Assert.AreEqual(1, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)));
            Assert.AreEqual(2.0, state.Events.First(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)).Timestamp);
        }

        [TestMethod]
        public void ImprovedAspectOfTheHawkProcChance()
        {
            var state = new SimulationState();
            state.Config.Talents.Add(Talent.ImprovedAspectOfTheHawk, 5);
            state.Config.Gear.Ranged = new GearItem
            {
                Speed = 2.9,
                WeaponType = WeaponType.Bow,
                MinDamage = 100,
                MaxDamage = 200,
            };

            InjectZeroMocks();

            var fakeRolls = new FakeRandomGenerator();
            fakeRolls.SetRolls(RollType.AutoShotMiss, 1.0);
            fakeRolls.SetRolls(RollType.AutoShotCrit, 1.0);
            fakeRolls.SetRolls(RollType.ImprovedAspectOfTheHawkProc, 0.11);
            RandomGenerator.InjectMock(fakeRolls);

            var e = new AutoShotCompletedEvent(2.0);
            e.ProcessEvent(state);

            Assert.AreEqual(0, state.Events.Count(x => x.GetType() == typeof(ImprovedAspectOfTheHawkProc)));
        }

        // TODO: Tests for the IAotH Events

        [TestMethod]
        public void EnduranceTraining()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.EnduranceTraining, 5);

            // 3488 base health + 107 stam + 5% talent
            Assert.AreEqual((3488 + 1070) * 1.05, HealthCalculator.Calculate(state));
            // TODO: Test pet health increase
        }

        // TODO: Test the proc and the 10% chance for improved aspect of the hawk once we have rotations modelled (could probably do now with just auto-shot, assuming hawk is the default aspect)
        // TODO: Focused Fire (need to know if pet is active, and have kill command modelled)




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

            Assert.AreEqual(1.38, MovementSpeedCalculator.Calculate(state), 0.00001);
        }

        [TestMethod]
        public void PathfindingPack()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.Pathfinding, 1);
            state.Auras.Add(Aura.AspectOfThePack);

            Assert.AreEqual(1.34, MovementSpeedCalculator.Calculate(state), 0.001);
        }

        // Marksmanship Talents

        [TestMethod]
        public void ImprovedHuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.HuntersMark);
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 3);

            // 148 base agi + 440 hunters mark
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 * 60% improved hunters mark
            Assert.AreEqual(65 + (110 * 0.6), MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedHuntersMarkTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 3);
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);

            // 148 base agi + 440 hunters mark
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 improved hunters mark
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
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

        // TODO: move this somewhere so we can reuse it between test classes and not copy-paste
        private void InjectZeroMocks()
        {
            var zeroMock = new FakeStatCalculator(0.0);

            BaseStatCalculator.InjectMock(typeof(AgilityCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(ArcaneResistanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(ArmorCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(BonusDamageCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(DamageMultiplierCalculator), new FakeStatCalculator(1.0));
            BaseStatCalculator.InjectMock(typeof(FireResistanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(FrostResistanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(HealthCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(IntellectCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(ManaCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MeleeAttackPowerCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MeleeCritCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MeleeCritDamageMultiplierCalculator), new FakeStatCalculator(1.0));
            BaseStatCalculator.InjectMock(typeof(MeleeHasteCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MissChanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MovementSpeedCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(MP5Calculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(NatureResistanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(RangedAttackPowerCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(RangedCritCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(RangedCritDamageMultiplierCalculator), new FakeStatCalculator(1.0));
            BaseStatCalculator.InjectMock(typeof(RangedHasteCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(ShadowResistanceCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(SpellCritCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(SpiritCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(StaminaCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(StrengthCalculator), zeroMock);
            BaseStatCalculator.InjectMock(typeof(WeaponSkillCalculator), new FakeStatCalculator(300));
        }
    }
}
