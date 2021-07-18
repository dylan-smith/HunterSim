﻿using System.Linq;

namespace HunterSim
{
    public class RangedHasteCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<RangedHasteCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var haste = state.Config.Gear.GetAllGear().Sum(x => x.Haste);
            haste += state.Config.Gear.GetAllEnchants().Sum(x => x.Haste);
            
            if (state.Auras.Contains(Aura.ImprovedAspectOfTheHawk))
            {
                haste += 0.30;
            }

            return haste;
        }
    }
}
