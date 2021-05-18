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

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                stamina += 12;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                stamina *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                stamina += 15;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                stamina *= 1.15;
            }

            if (state.Config.Buffs.Contains(Buff.MoldarsMoxie))
            {
                stamina *= 1.15;
            }

            return stamina;
        }
    }
}
