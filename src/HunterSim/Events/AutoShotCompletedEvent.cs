using System;
using System.Collections.Generic;

namespace HunterSim
{
    public class AutoShotCompletedEvent : EventInfo
    {
        public AutoShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            var autoShotDamage = 0.0;

            var bossDefense = 315;
            var playerWeaponSkill = 300;
            double missChance;

            if (bossDefense - playerWeaponSkill > 10)
            {
                missChance = 7 + ((bossDefense - playerWeaponSkill - 10) * 0.4);
            }
            else
            {
                missChance = 5 + ((bossDefense - playerWeaponSkill) * 0.1);
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
