using System;

namespace HunterSim
{
    public static class HealthCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var health = state.Config.PlayerSettings.Health;
            health += StaminaCalculator.Calculate(state) * 10;

            return health;
        }
    }
}
