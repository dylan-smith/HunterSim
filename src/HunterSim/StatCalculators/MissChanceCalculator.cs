using System;
using System.Linq;

namespace HunterSim
{
    public class MissChanceCalculator : BaseStatCalculator
    {
        public static double Calculate(GearItem weapon, SimulationState state)
        {
            return Calculate<MissChanceCalculator>(weapon, state);
        }

        protected override double InstanceCalculate(GearItem weapon, SimulationState state)
        {
            var bossDefense = state.Config.BossSettings.Defense;
            var weaponSkill = WeaponSkillCalculator.Calculate(weapon, state);
            double missChance;

            if (bossDefense - weaponSkill > 10)
            {
                missChance = 0.07 + ((bossDefense - weaponSkill - 10) * 0.004);
            }
            else
            {
                missChance = 0.05 + ((bossDefense - weaponSkill) * 0.001);
            }

            missChance -= state.Config.Gear.GetAllGear().Sum(x => x.Hit);
            missChance -= state.Config.Gear.GetAllEnchants().Sum(x => x.Hit);

            if (state.Config.Buffs.Contains(Buff.DarkDesire))
            {
                missChance -= 0.02;
            }

            if (state.Config.Buffs.Contains(Buff.FireToastedBun))
            {
                missChance -= 0.02;
            }

            if (state.Config.Talents.ContainsKey(Talent.Surefooted))
            {
                missChance -= state.Config.Talents[Talent.Surefooted] * 0.01;
            }

            missChance = Math.Max(missChance, 0.0);

            return missChance;
        }
    }
}
