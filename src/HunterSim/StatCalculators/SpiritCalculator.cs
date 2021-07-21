namespace HunterSim
{
    public class SpiritCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<SpiritCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var spirit = state.Config.PlayerSettings.Spirit;
            spirit += state.Config.Gear.GetStatTotal(x => x.Spirit);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                spirit += 14;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                spirit *= 1.1;
            }

            return spirit;
        }
    }
}
