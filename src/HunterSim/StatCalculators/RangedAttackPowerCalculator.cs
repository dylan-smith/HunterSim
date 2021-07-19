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
            var rangedAP = state.Config.Gear.GetStatTotal(x => x.AttackPower);
            rangedAP += state.Config.Gear.GetStatTotal(x => x.RangedAttackPower);
            rangedAP += AgilityCalculator.Calculate(state);
            
            if (state.Config.Buffs.Contains(Buff.HuntersMark) || state.Config.Buffs.Contains(Buff.ImprovedHuntersMark))
            {
                rangedAP += 440;
            }

            if (state.Config.Talents.ContainsKey(Talent.TrueshotAura) || state.Config.Buffs.Contains(Buff.TrueshotAura))
            {
                rangedAP += 125;
            }

            if (state.Auras.Contains(Aura.AspectOfTheHawk))
            {
                rangedAP += 155;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfMight))
            {
                rangedAP += 220;
            }

            // TODO: Orc Bloodfury

            return rangedAP;
        }
    }
}
