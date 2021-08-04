﻿namespace HunterSim
{
    public class AgilityCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<AgilityCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var agility = state.Config.PlayerSettings.Agility;
            agility += state.Config.Gear.GetStatTotal(x => x.Agility);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                agility += 14;
            }

            if (state.Config.Buffs.Contains(Buff.ImprovedMarkOfTheWild))
            {
                agility += 14 * 1.35;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                agility *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.GraceOfAirTotem))
            {
                agility += 77;
            }

            if (state.Config.Buffs.Contains(Buff.ImprovedGraceOfAirTotem))
            {
                agility += 77 * 1.15;
            }

            if (state.Config.Buffs.Contains(Buff.GrilledMudfish))
            {
                agility += 20;
            }

            if (state.Config.Buffs.Contains(Buff.ElixirOfMajorAgility))
            {
                agility += 35;
            }

            if (state.Config.Buffs.Contains(Buff.ScrollOfAgilityV))
            {
                agility += 20;
            }

            if (state.Config.Talents.ContainsKey(Talent.LightningReflexes))
            {
                agility *= 1 + (state.Config.Talents[Talent.LightningReflexes] * 0.03);
            }

            if (state.Config.Talents.ContainsKey(Talent.CombatExperience))
            {
                agility *= 1 + (0.01 * state.Config.Talents[Talent.CombatExperience]);
            }

            return agility;
        }
    }
}
