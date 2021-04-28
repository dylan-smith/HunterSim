﻿using System.Collections.Generic;

namespace HunterSim
{
    public class AutoShotCompletedEvent : EventInfo
    {
        private readonly double _autoShotDamage = 93.3;

        public AutoShotCompletedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(IList<DamageEvent> damageEvents)
        {
            damageEvents.Add(new DamageEvent(base.Timestamp, _autoShotDamage));
            AutoShot.OnCooldown = false;
        }
    }
}
