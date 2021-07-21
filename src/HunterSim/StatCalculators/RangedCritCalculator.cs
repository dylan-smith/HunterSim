using System;

namespace HunterSim
{
    public class RangedCritCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<RangedCritCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            // base crit for hunters is oddly -1.53%
            // TODO: Include link
            var critChance = -0.0153;
            critChance += GetCritSuppressionBasedOnBossLevel(state);
            critChance += GetCritSuppressionAura();
            critChance += state.Config.Gear.GetStatTotal(x => x.CritRating);
            critChance += AgilityCalculator.Calculate(state) / 4000; // 40 Agi = 0.01 crit

            if (state.Config.Buffs.Contains(Buff.LeaderOfThePack))
            {
                critChance += 0.05;
            }

            if (state.Config.Talents.ContainsKey(Talent.LethalShots))
            {
                critChance += state.Config.Talents[Talent.LethalShots] * 0.01;
            }

            if (state.Config.Talents.ContainsKey(Talent.KillerInstinct))
            {
                critChance += state.Config.Talents[Talent.KillerInstinct] * 0.01;
            }

            // TODO: Trolls get 1% crit with bow racial

            critChance = Math.Max(critChance, 0);
            critChance = Math.Min(critChance, 1.0);

            return critChance;
        }

        // https://classic.wowhead.com/news/berserker-stance-and-modifiers-to-critical-strike-clarifications-293749
        private double GetCritSuppressionAura() => -0.018;

        // TODO: Include link to details
        private double GetCritSuppressionBasedOnBossLevel(SimulationState state) => -0.01 * (state.Config.BossSettings.Level - state.Config.PlayerSettings.Level);
    }
}
