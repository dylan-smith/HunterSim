using System;

namespace HunterSim
{
    public static class ManaCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var mana = state.Config.PlayerSettings.Mana;
            mana += IntellectCalculator.Calculate(state) * 15;

            return mana;
        }
    }
}
