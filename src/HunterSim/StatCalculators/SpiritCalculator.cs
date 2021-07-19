using System;

namespace HunterSim
{
    public class SpiritCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<SpiritCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var spirit = state.Config.PlayerSettings.Spirit;

            // TODO: Get from gear and enchants

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                spirit += 14;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                spirit *= 1.1;
            }

            return spirit;
        }
    }
}
