using System.Linq;

namespace HunterSim
{
    public static class RangedAttackPowerCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var rangedAP = state.Config.Gear.GetAllGear().Sum(x => x.AttackPower);
            rangedAP += state.Config.Gear.GetAllEnchants().Sum(x => x.AttackPower);
            rangedAP += state.Config.Gear.GetAllGear().Sum(x => x.RangedAttackPower);
            rangedAP += state.Config.Gear.GetAllEnchants().Sum(x => x.RangedAttackPower);
            rangedAP += AgilityCalculator.Calculate(state) * 2;
            
            if (state.Config.Buffs.Contains(Buff.RallyingCryOfTheDragonSlayer))
            {
                rangedAP += 140;
            }

            if (state.Config.Buffs.Contains(Buff.FengusFerocity))
            {
                rangedAP += 200;
            }

            if (state.Config.Buffs.Contains(Buff.TrueshotAura))
            {
                rangedAP += 50;
            }

            if (state.Config.Buffs.Contains(Buff.JujuMight))
            {
                rangedAP += 40;
            }

            if (state.Config.Talents.ContainsKey(Talent.SurvivalInstincts))
            {
                rangedAP *= 1 + (state.Config.Talents[Talent.SurvivalInstincts] * 0.02);
            }

            if (state.Auras.Contains(Aura.ExposeWeakness))
            {
                rangedAP += AgilityCalculator.Calculate(state) * 0.25;
            }

            return rangedAP;
        }
    }
}
