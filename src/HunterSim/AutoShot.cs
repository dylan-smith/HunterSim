using System;
using System.Collections.Generic;

namespace HunterSim
{
    public static class AutoShot
    {
        public static bool OnCooldown { get; set; }
        private static readonly double _autoShotCooldown = 2.8;

        public static void Use(double timestamp, IList<EventInfo> events)
        {
            events.Add(new AutoShotCompletedEvent(timestamp + _autoShotCooldown));
            OnCooldown = true;
        }
    }
}
