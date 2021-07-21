namespace HunterSim
{
    public class RangedHasteCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<RangedHasteCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var haste = state.Config.Gear.GetStatTotal(x => x.HasteRating);
            
            if (state.Auras.Contains(Aura.ImprovedAspectOfTheHawk))
            {
                haste += 0.03 * state.Config.Talents[Talent.ImprovedAspectOfTheHawk];
            }

            return haste;
        }
    }
}
