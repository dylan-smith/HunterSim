namespace HunterSim
{
    public class StrengthCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<StrengthCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var strength = state.Config.PlayerSettings.Strength;
            strength += state.Config.Gear.GetStatTotal(x => x.Strength);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                strength += 14;
            }

            if (state.Config.Buffs.Contains(Buff.ImprovedMarkOfTheWild))
            {
                strength += 14 * 1.35;
            }

            if (state.Config.Buffs.Contains(Buff.StrengthOfEarthTotem))
            {
                strength += 86;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                strength *= 1.1;
            }

            return strength;
        }
    }
}
