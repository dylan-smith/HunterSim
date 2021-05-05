using System;

namespace HunterSim
{
    public static class IntellectCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var intellect = state.Config.PlayerSettings.Intellect;

            return intellect;
        }
    }
}
