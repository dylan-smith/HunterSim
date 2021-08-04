namespace HunterSim
{
    public class RangedAttackPowerCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<RangedAttackPowerCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var rangedAP = state.Config.Gear.GetStatTotal(x => x.AttackPower);
            rangedAP += state.Config.Gear.GetStatTotal(x => x.RangedAttackPower);
            rangedAP += AgilityCalculator.Calculate(state);

            // TODO: should probably have an AttackPowerCalculator that both rangedap/meleeap call

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

            if (state.Config.Buffs.Contains(Buff.ImprovedBlessingOfMight))
            {
                rangedAP += 264;
            }

            if (state.Config.Talents.ContainsKey(Talent.CarefulAim))
            {
                var intellect = IntellectCalculator.Calculate(state);
                rangedAP += intellect * (0.15 * state.Config.Talents[Talent.CarefulAim]);
            }

            if (state.Auras.Contains(Aura.ExposeWeakness))
            {
                rangedAP += ExposeWeakness.AttackPower;
            }

            if (state.Config.Talents.ContainsKey(Talent.MasterMarksman))
            {
                rangedAP *= 1 + (0.02 * state.Config.Talents[Talent.MasterMarksman]);
            }

            if (state.Config.Talents.ContainsKey(Talent.SurvivalInstincts))
            {
                rangedAP *= 1 + (0.02 * state.Config.Talents[Talent.SurvivalInstincts]);
            }

            // TODO: Orc Bloodfury

            return rangedAP;
        }
    }
}
