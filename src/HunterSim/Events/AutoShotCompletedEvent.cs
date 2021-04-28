namespace HunterSim
{
    public class AutoShotCompletedEvent : EventInfo
    {
        public AutoShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            var autoShotDamage = 0.0;

            var bossDefense = state.Config.BossSettings.Defense;
            var rangedWeaponSkill = state.Config.PlayerSettings.WeaponSkill[state.Config.Gear.Ranged.WeaponType];
            double missChance;

            if (bossDefense - rangedWeaponSkill > 10)
            {
                missChance = 7 + ((bossDefense - rangedWeaponSkill - 10) * 0.4);
            }
            else
            {
                missChance = 5 + ((bossDefense - rangedWeaponSkill) * 0.1);
            }

            missChance /= 100;

            var missRoll = RandomGenerator.Roll();

            if (missRoll > missChance)
            {
                autoShotDamage = state.Config.Gear.Ranged.MaxDamage;
            }

            state.DamageEvents.Add(new DamageEvent(base.Timestamp, autoShotDamage));
            AutoShot.OnCooldown = false;
        }
    }
}
