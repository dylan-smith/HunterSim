namespace HunterSim
{
    public class DodgeCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<DodgeCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            // TODO: I think hunters might start with a base dodge that's negative (https://wowwiki-archive.fandom.com/wiki/Dodge)
            var dodgeRating = state.Config.Gear.GetStatTotal(x => x.DodgeRating);

            // https://www.reddit.com/r/burningcrusade/comments/ka0tb6/tbc_combat_rating_haste_hit_etc_conversions_at/
            var dodge = dodgeRating / 1890.0;

            // https://tbc.wowhead.com/guides/classic-the-burning-crusade-stats-overview
            dodge += AgilityCalculator.Calculate(state) / 2500.0;

            if (state.Auras.Contains(Aura.AspectOfTheMonkey))
            {
                dodge *= 1.08;
            }

            return dodge;
        }
    }
}
