using System;

namespace HunterSim
{
    public static class StaminaCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var stamina = state.Config.PlayerSettings.Stamina;

            return stamina;
        }
    }
}
