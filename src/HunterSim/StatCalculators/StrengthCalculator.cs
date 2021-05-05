using System;

namespace HunterSim
{
    public static class StrengthCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var strength = state.Config.PlayerSettings.Strength;

            return strength;
        }
    }
}
