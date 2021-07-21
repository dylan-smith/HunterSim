namespace HunterSim
{
    public class IntellectCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<IntellectCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var intellect = state.Config.PlayerSettings.Intellect;
            intellect += state.Config.Gear.GetStatTotal(x => x.Intellect);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                intellect += 14;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                intellect *= 1.1;
            }

            return intellect;
        }
    }
}
