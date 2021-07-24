namespace HunterSim
{
    public class MeleeAttackPowerCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state) => Calculate<MeleeAttackPowerCalculator>(state);

        protected override double InstanceCalculate(SimulationState state)
        {
            var meleeAP = state.Config.Gear.GetStatTotal(x => x.AttackPower);
            meleeAP += state.Config.Gear.GetStatTotal(x => x.MeleeAttackPower);
            meleeAP += StrengthCalculator.Calculate(state);
            meleeAP += AgilityCalculator.Calculate(state);

            if (state.Config.Buffs.Contains(Buff.ImprovedHuntersMark))
            {
                meleeAP += 110;
            }
            else if (state.Config.Talents.ContainsKey(Talent.ImprovedHuntersMark))
            {
                meleeAP += 110 * (0.2 * state.Config.Talents[Talent.ImprovedHuntersMark]);
            }

            if (state.Config.Talents.ContainsKey(Talent.TrueshotAura) || state.Config.Buffs.Contains(Buff.TrueshotAura))
            {
                meleeAP += 125;
            }

            if (state.Config.Buffs.Contains(Buff.BattleShout))
            {
                meleeAP += 305;
            }

            if (state.Config.Buffs.Contains(Buff.ImprovedBattleShout))
            {
                // Warrior talent Commanding Presence (at 5/5) gives a 25% bonus to battle shout buff
                meleeAP += 381;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfMight))
            {
                meleeAP += 220;
            }

            if (state.Config.Talents.ContainsKey(Talent.SurvivalInstincts))
            {
                meleeAP *= 1 + (0.02 * state.Config.Talents[Talent.SurvivalInstincts]);
            }

            return meleeAP;
        }
    }
}
