namespace HunterSim.Events
{
    public class SteadyShotCompletedEvent : EventInfo
    {
        public CastCompletedEvent CastCompletedEvent { get; private set; }
        public DamageEvent DamageEvent { get; private set; }

        public SteadyShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            double shotDamage;
            DamageType damageType;

            var missChance = MissChanceCalculator.Calculate(state.Config.Gear.Ranged, state);
            var critChance = RangedCritCalculator.Calculate(state);

            var missRoll = RandomGenerator.Roll(RollType.AutoShotMiss);

            if (missRoll <= missChance)
            {
                shotDamage = 0.0;
                damageType = DamageType.Miss;
            }
            else
            {
                var rangedAP = RangedAttackPowerCalculator.Calculate(state);

                // TODO: Normalize weapon speed
                shotDamage = (state.Config.Gear.Ranged.MinDamage + state.Config.Gear.Ranged.MaxDamage) / 2;
                // does sniper scope, ammo bonus, etc apply to steady shots?
                shotDamage += RangedBonusDamageCalculator.Calculate(state.Config.Gear.Ranged, state);
                shotDamage += rangedAP * 0.2;
                shotDamage += 150;
                shotDamage *= RangedDamageMultiplierCalculator.Calculate(state);

                damageType = DamageType.Hit;

                // Assuming crit uses a 2-roll system as per this article:
                // https://wowwiki-archive.fandom.com/wiki/Attack_table#Ranged_attacks
                var critRoll = RandomGenerator.Roll(RollType.AutoShotCrit);

                if (critRoll <= critChance)
                {
                    // TODO: is bonus damage (scope) and bonus dps (ammo) doubled when you crit? This assumes yes
                    autoShotDamage *= 2;
                    autoShotDamage *= RangedCritDamageMultiplierCalculator.Calculate(state);
                    damageType = DamageType.Crit;
                }
            }

            // TODO: Boss armor reduction

            // TODO: If we do these calcs earlier we can do just one roll instead of 2
            critChance *= (1 - missChance);
            var hitChance = 1 - missChance - critChance;

            DamageEvent = new DamageEvent(Timestamp, autoShotDamage, damageType, missChance, critChance, hitChance);
            state.Events.Add(DamageEvent);


            CastCompletedEvent = new CastCompletedEvent(Timestamp);
            state.Events.Add(CastCompletedEvent);
        }
    }
}
