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

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                strength += 12;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                strength *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.StrengthOfEarthTotem))
            {
                strength += 77;
            }

            if (state.Config.Buffs.Contains(Buff.ROIDS))
            {
                strength += 25;
            }

            if (state.Config.Buffs.Contains(Buff.JujuPower))
            {
                strength += 30;
            }
            else
            {
                if (state.Config.Buffs.Contains(Buff.ElixirOfGiants))
                {
                    strength += 25;
                }
            }

            if (state.Config.Buffs.Contains(Buff.SmokedDesertDumplings))
            {
                strength += 20;
            }

            if (state.Config.Buffs.Contains(Buff.BlessedSunfruit))
            {
                strength += 10;
            }

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                strength += 15;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                strength *= 1.15;
            }

            return strength;
        }
    }
}
