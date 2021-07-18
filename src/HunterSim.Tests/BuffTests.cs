using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HunterSim.Tests
{
    [TestClass]
    public class BuffTests
    {
        [TestMethod]
        public void BattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BattleShout);

            // 65 base str + 290 buff
            Assert.AreEqual(65 + 305, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void EnhancedBattleShout()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedBattleShout);

            // 65 base str + 381 buff
            Assert.AreEqual(65 + 381, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAura()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void TrueShotAuraFromTalentAndBuff()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Talents.Add(Talent.TrueshotAura, 1);
            state.Config.Buffs.Add(Buff.TrueshotAura);

            // 65 base str + 125 buff
            Assert.AreEqual(65 + 125, MeleeAttackPowerCalculator.Calculate(state));
            // 148 base agi + 125 buff
            Assert.AreEqual(148 + 125, RangedAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void LeaderOfThePack()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.PlayerSettings.Level = 70;
            state.Config.BossSettings.Level = 73;
            state.Config.Buffs.Add(Buff.LeaderOfThePack);

            // base crit is -1.53% and there's a 4.8% crit suppression on raid bosses
            var baseCrit = -0.0153 - 0.048;
            // 40 agi per 1% crit
            baseCrit += 148.0 / 4000.0;

            Assert.AreEqual(baseCrit + 0.05, MeleeCritCalculator.Calculate(state), 0.0001);
            Assert.AreEqual(baseCrit + 0.05, RangedCritCalculator.Calculate(state), 0.0001);
        }

        [TestMethod]
        public void MarkOfTheWild()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.MarkOfTheWild);

            // (148 agi + 14 agi) * 2 + 340 buff
            Assert.AreEqual(324 + 340, ArmorCalculator.Calculate(state));

            // 148 base agi + 14 buff
            Assert.AreEqual(148 + 14, AgilityCalculator.Calculate(state), 0.001);
            // 65 base str + 14 buff
            Assert.AreEqual(65 + 14, StrengthCalculator.Calculate(state), 0.001);
            // 107 base sta + 14 buff
            Assert.AreEqual(107 + 14, StaminaCalculator.Calculate(state), 0.001);
            // 78 base int + 14 buff
            Assert.AreEqual(78 + 14, IntellectCalculator.Calculate(state), 0.001);
            // 85 base spi + 14 buff
            Assert.AreEqual(85 + 14, SpiritCalculator.Calculate(state), 0.001);

            Assert.AreEqual(25, ArcaneResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, FireResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, FrostResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, NatureResistanceCalculator.Calculate(state));
            Assert.AreEqual(25, ShadowResistanceCalculator.Calculate(state));
        }

        [TestMethod]
        public void BlessingOfKings()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BlessingOfKings);

            // 148 base agi + 10% buff
            Assert.AreEqual(148 * 1.1, AgilityCalculator.Calculate(state), 0.001);
            // 65 base str + 10% buff
            Assert.AreEqual(65 * 1.1, StrengthCalculator.Calculate(state), 0.001);
            // 107 base sta + 10% buff
            Assert.AreEqual(107 * 1.1, StaminaCalculator.Calculate(state), 0.001);
            // 78 base int + 10% buff
            Assert.AreEqual(78 * 1.1, IntellectCalculator.Calculate(state), 0.001);
            // 85 base spi + 10% buff
            Assert.AreEqual(85 * 1.1, SpiritCalculator.Calculate(state), 0.001);
        }

        [TestMethod]
        public void BlessingOfMight()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.BlessingOfMight);

            // 148 base agi + 220 buff
            Assert.AreEqual(148 + 220, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 220 buff
            Assert.AreEqual(65 + 220, MeleeAttackPowerCalculator.Calculate(state));
        }

        // TODO: Improved Blessing of Might

        [TestMethod]
        public void GraceOfAirTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.GraceOfAirTotem);

            // 148 base agi + 77 buff
            Assert.AreEqual(148 + 77, AgilityCalculator.Calculate(state));
        }

        // TODO: Improved Grace of Air

        [TestMethod]
        public void StrengthOfEarthTotem()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.StrengthOfEarthTotem);

            // 65 base str + 86 buff
            Assert.AreEqual(65 + 86, StrengthCalculator.Calculate(state));
        }

        // TODO: Improved Strength of Earth

        [TestMethod]
        public void HuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.HuntersMark);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str (buff shouldn't affect melee ap)
            Assert.AreEqual(65, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedHuntersMark()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 buff
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
        }

        [TestMethod]
        public void ImprovedHuntersMarkBuffAndTalent()
        {
            var state = new SimulationState();
            state.Config.PlayerSettings.Race = Race.Draenei;
            state.Config.Buffs.Add(Buff.ImprovedHuntersMark);
            state.Config.Talents.Add(Talent.ImprovedHuntersMark, 5);

            // 148 base agi + 440 buff
            Assert.AreEqual(148 + 440, RangedAttackPowerCalculator.Calculate(state));
            // 65 base str + 110 buff
            Assert.AreEqual(65 + 110, MeleeAttackPowerCalculator.Calculate(state));
        }
    }
}
