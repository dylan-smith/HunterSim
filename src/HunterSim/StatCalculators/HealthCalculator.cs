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

            if (state.Config.Talents.ContainsKey(Talent.Survivalist))
            {
                health *= 1 + (state.Config.Talents[Talent.Survivalist] * 0.02);
            }

            return health;
        }
    }
}
