namespace HunterSim
{
    public class StaminaCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<StaminaCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var stamina = state.Config.PlayerSettings.Stamina;
            stamina += state.Config.Gear.GetStatTotal(x => x.Stamina);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                stamina += 14;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                stamina *= 1.1;
            }

            return stamina;
        }
    }
}
