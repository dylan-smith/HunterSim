using System;

namespace HunterSim
{
    public static class SpiritCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var spirit = state.Config.PlayerSettings.Spirit;

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                spirit += 15;
            }

            return spirit;
        }
    }
}
