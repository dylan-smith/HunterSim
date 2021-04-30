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
