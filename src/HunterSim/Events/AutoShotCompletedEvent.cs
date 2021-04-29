using System.Linq;

namespace HunterSim
{
    public class AutoShotCompletedEvent : EventInfo
    {
        public AutoShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            double autoShotDamage;
            DamageType damageType;

            var missChance = MissChanceCalculator.Calculate(state.Config.Gear.Ranged.WeaponType, state);
            var critChance = CritChanceCalculator.Calculate(state);

            var missRoll = RandomGenerator.Roll();

            if (missRoll <= missChance)
            {
                autoShotDamage = 0.0;
                damageType = DamageType.Miss;
            }
            else
            {
                var bonusDamage = state.Config.Gear.GetAllGear().Sum(x => x.BonusDamage);
                var bonusDPS = state.Config.Gear.GetAllGear().Sum(x => x.BonusDPS);
                var rangedAP = RangedAttackPowerCalculator.Calculate(state);
                
                autoShotDamage = (state.Config.Gear.Ranged.MinDamage + state.Config.Gear.Ranged.MaxDamage) / 2;
                autoShotDamage += bonusDamage;
                autoShotDamage += bonusDPS * state.Config.Gear.Ranged.Speed;
                autoShotDamage += rangedAP / 14.0;
                
                damageType = DamageType.Hit;

                // Assuming crit uses a 2-roll system as per this article:
                // https://wowwiki-archive.fandom.com/wiki/Attack_table#Ranged_attacks
                var critRoll = RandomGenerator.Roll();

                if (critRoll <= critChance)
                {
                    // TODO: is bonus damage (scope) and bonus dps (ammo) doubled when you crit? This assumes yes
                    autoShotDamage *= 2;
                    damageType = DamageType.Crit;
                }
            }

            // TODO: If we do these calcs earlier we can do just one roll instead of 2
            critChance *= (1 - missChance);
            var hitChance = 1 - missChance - critChance;

            state.DamageEvents.Add(new DamageEvent(base.Timestamp, autoShotDamage, damageType, missChance, critChance, hitChance));
            AutoShot.OnCooldown = false;
        }
    }
}
