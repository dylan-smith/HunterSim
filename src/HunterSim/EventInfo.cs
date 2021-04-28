using System;
using System.Collections.Generic;
using System.Text;

namespace HunterSim
{
    public abstract class EventInfo
    {
        public double Timestamp { get; set; }

        public EventInfo(double timestamp)
        {
            Timestamp = timestamp;
        }

        public abstract void ProcessEvent(IList<DamageEvent> damageEvents);
    }
}
