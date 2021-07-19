using System.Linq;

namespace HunterSim
{
    public class StrengthCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<StrengthCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var strength = state.Config.PlayerSettings.Strength;

            strength += state.Config.Gear.GetAllGear().Sum(x => x.TotalStrength);
            strength += state.Config.Gear.GetAllEnchants().Sum(x => x.TotalStrength);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                strength += 14;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                strength *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.StrengthOfEarthTotem))
            {
                strength += 86;
            }

            return strength;
        }
    }
}
