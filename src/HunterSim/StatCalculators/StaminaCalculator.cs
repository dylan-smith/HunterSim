using System;

namespace HunterSim
{
    public static class StaminaCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var stamina = state.Config.PlayerSettings.Stamina;

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                stamina += 15;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                stamina *= 1.15;
            }

            return stamina;
        }
    }
}
