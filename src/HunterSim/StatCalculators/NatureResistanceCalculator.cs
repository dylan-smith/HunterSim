namespace HunterSim
{
    public class NatureResistanceCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<NatureResistanceCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetStatTotal(x => x.NatureResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 25;
            }

            return resist;
        }
    }
}
