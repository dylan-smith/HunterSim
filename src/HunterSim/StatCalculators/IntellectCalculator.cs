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

            return intellect;
        }
    }
}
