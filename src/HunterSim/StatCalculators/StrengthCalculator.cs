using System;

namespace HunterSim
{
    public static class StrengthCalculator
    {
        public static double Calculate(SimulationState state)
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
