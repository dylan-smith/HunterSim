using System;
using System.Linq;

namespace HunterSim
{
    public static class MeleeAttackPowerCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var meleeAP = state.Config.Gear.GetAllGear().Sum(x => x.AttackPower);
            meleeAP += state.Config.Gear.GetAllEnchants().Sum(x => x.AttackPower);
            meleeAP += state.Config.Gear.GetAllGear().Sum(x => x.MeleeAttackPower);
            meleeAP += state.Config.Gear.GetAllEnchants().Sum(x => x.MeleeAttackPower);
            meleeAP += AgilityCalculator.Calculate(state);
            meleeAP += StrengthCalculator.Calculate(state);

            if (state.Config.Buffs.Contains(Buff.RallyingCryOfTheDragonSlayer))
            {
                meleeAP += 140;
            }

            if (state.Config.Buffs.Contains(Buff.FengusFerocity))
            {
                meleeAP += 200;
            }

            if (state.Config.Buffs.Contains(Buff.TrueshotAura))
            {
                meleeAP += 50;
            }

            if (state.Config.Buffs.Contains(Buff.JujuMight))
            {
                meleeAP += 40;
            }

            if (state.Config.Talents.ContainsKey(Talent.SurvivalInstincts))
            {
                meleeAP *= 1 + (state.Config.Talents[Talent.SurvivalInstincts] * 0.02);
            }

            if (state.Auras.Contains(Aura.ExposeWeakness))
            {
                meleeAP += AgilityCalculator.Calculate(state) * 0.25;
            }

            return meleeAP;
        }
    }
}
