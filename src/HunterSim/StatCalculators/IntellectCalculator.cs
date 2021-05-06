using System;

namespace HunterSim
{
    public static class IntellectCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var intellect = state.Config.PlayerSettings.Intellect;

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                intellect += 15;
            }

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                intellect += 12;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                intellect *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                intellect *= 1.15;
            }

            return intellect;
        }
    }
}
