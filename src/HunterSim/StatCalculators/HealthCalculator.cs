using System;

namespace HunterSim
{
    public static class HealthCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var health = state.Config.PlayerSettings.Health;
            health += StaminaCalculator.Calculate(state) * 10;

            if (state.Config.Buffs.Contains(Buff.WarchiefsBlessing))
            {
                health += 300;
            }

            return health;
        }
    }
}
