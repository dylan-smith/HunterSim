using System;

namespace HunterSim
{
    public static class SpiritCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var spirit = state.Config.PlayerSettings.Spirit;

            return spirit;
        }
    }
}
