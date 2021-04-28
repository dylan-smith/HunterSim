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
                // Assuming crit uses a 2-roll system as per this article:
                // https://wowwiki-archive.fandom.com/wiki/Attack_table#Ranged_attacks
                var critRoll = RandomGenerator.Roll();
                autoShotDamage = state.Config.Gear.Ranged.MaxDamage + state.Config.Gear.Ammo.MaxDamage;
                damageType = DamageType.Hit;

                // TODO: Randomize damage across range

                if (critRoll <= critChance)
                {
                    autoShotDamage *= 2;
                    damageType = DamageType.Crit;
                }
            }

            state.DamageEvents.Add(new DamageEvent(base.Timestamp, autoShotDamage, damageType, missChance, critChance, 1.0 - critChance));
            AutoShot.OnCooldown = false;
        }
    }
}
