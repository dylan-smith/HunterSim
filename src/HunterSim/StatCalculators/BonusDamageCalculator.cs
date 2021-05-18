﻿using System.Linq;

namespace HunterSim
{
    public class BonusDamageCalculator : BaseStatCalculator
    {
        public static double Calculate(GearItem weapon, SimulationState state)
        {
            return Calculate<BonusDamageCalculator>(weapon, state);
        }

        protected override double InstanceCalculate(GearItem weapon, SimulationState state)
        {
            // TODO: Sniper Scope bonus dmg only applies to damage from the ranged weapon
            var bonusDamage = state.Config.Gear.GetAllGear().Sum(x => x.BonusDamage);
            bonusDamage += state.Config.Gear.GetAllGear().Sum(x => x.BonusDPS) * weapon.Speed;

            bonusDamage += state.Config.Gear.GetAllEnchants().Sum(x => x.BonusDamage);
            bonusDamage += state.Config.Gear.GetAllEnchants().Sum(x => x.BonusDPS) * weapon.Speed;

            if (state.Config.Buffs.Contains(Buff.BoglingRoot))
            {
                bonusDamage += 1;
            }

            return bonusDamage;
        }
    }
}
