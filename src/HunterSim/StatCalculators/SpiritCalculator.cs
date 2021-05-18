﻿using System;

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

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                spirit += 12;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                spirit *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                spirit += 15;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                spirit *= 1.15;
            }

            return spirit;
        }
    }
}
