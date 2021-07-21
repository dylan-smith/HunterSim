namespace HunterSim
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

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                agility *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.GraceOfAirTotem))
            {
                agility += 77;
            }

            if (state.Config.Talents.ContainsKey(Talent.LightningReflexes))
            {
                agility *= 1 + (state.Config.Talents[Talent.LightningReflexes] * 0.03);
            }

            return agility;
        }
    }
}
