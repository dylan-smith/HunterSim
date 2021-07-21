namespace HunterSim
{
    public class ArcaneResistanceCalculator: BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<ArcaneResistanceCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetStatTotal(x => x.ArcaneResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 25;
            }

            return resist;
        }
    }
}
