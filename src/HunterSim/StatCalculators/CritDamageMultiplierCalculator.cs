﻿namespace HunterSim
{
    public static class CritDamageMultiplierCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var bossType = state.Config.BossSettings.BossType;

            if (state.Config.Talents.ContainsKey(Talent.MonsterSlaying))
            {
                if (bossType == BossType.Beast || bossType == BossType.Giant || bossType == BossType.Dragonkin)
                {
                    return 1 + (0.01 * state.Config.Talents[Talent.MonsterSlaying]);
                }
            }

            if (state.Config.Talents.ContainsKey(Talent.HumanoidSlaying))
            {
                if (bossType == BossType.Humanoid)
                {
                    return 1 + (0.01 * state.Config.Talents[Talent.HumanoidSlaying]);
                }
            }

            return 1.0;
        }
    }
}
