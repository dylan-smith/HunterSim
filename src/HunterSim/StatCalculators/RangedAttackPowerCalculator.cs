using System.Linq;

namespace HunterSim
{
    public class RangedAttackPowerCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<RangedAttackPowerCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
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

            if (state.Config.Buffs.Contains(Buff.HuntersMark) || state.Config.Buffs.Contains(Buff.ImprovedHuntersMark))
            {
                rangedAP += 110;

                if (state.Config.Buffs.Contains(Buff.ImprovedHuntersMark))
                {
                    rangedAP += 110 * 0.15;
                }
                else if (state.Config.Talents.ContainsKey(Talent.ImprovedHuntersMark))
                {
                    rangedAP += 110 * (0.03 * state.Config.Talents[Talent.ImprovedHuntersMark]);
                }

            }

            if (state.Config.Talents.ContainsKey(Talent.TrueshotAura) || state.Config.Buffs.Contains(Buff.TrueshotAura))
            {
                rangedAP += 100;
            }

            if (state.Config.Buffs.Contains(Buff.JujuMight))
            {
                rangedAP += 40;
            }

            if (state.Auras.Contains(Aura.AspectOfTheHawk))
            {
                rangedAP += 120;
            }

            return rangedAP;
        }
    }
}
