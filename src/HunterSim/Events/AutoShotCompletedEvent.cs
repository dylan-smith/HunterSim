namespace HunterSim
{
    public class AutoShotCompletedEvent : EventInfo
    {
        public AutoShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            var bossDefense = state.Config.BossSettings.Defense;
            var rangedWeaponSkill = state.Config.PlayerSettings.WeaponSkill[state.Config.Gear.Ranged.WeaponType];
            double missChance;
            double autoShotDamage;
            DamageTypes damageType;

            if (bossDefense - rangedWeaponSkill > 10)
            {
                missChance = 0.07 + ((bossDefense - rangedWeaponSkill - 10) * 0.004);
            }
            else
            {
                missChance = 0.05 + ((bossDefense - rangedWeaponSkill) * 0.001);
            }

            // Assuming crit uses a 2-roll system as per this article:
            // https://wowwiki-archive.fandom.com/wiki/Attack_table#Ranged_attacks
            var critChance = 0.05;

            var missRoll = RandomGenerator.Roll();

            if (missRoll <= missChance)
            {
                autoShotDamage = 0.0;
                damageType = DamageTypes.Miss;
            }
            else
            {
                var critRoll = RandomGenerator.Roll();
                autoShotDamage = state.Config.Gear.Ranged.MaxDamage;
                damageType = DamageTypes.Hit;

                if (critRoll <= critChance)
                {
                    autoShotDamage *= 2;
                    damageType = DamageTypes.Crit;
                }
            }

            state.DamageEvents.Add(new DamageEvent(base.Timestamp, autoShotDamage, damageType, missChance, critChance, 1.0 - critChance));
            AutoShot.OnCooldown = false;
        }
    }
}
