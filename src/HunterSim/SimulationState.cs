using System.Collections.Generic;

namespace HunterSim
{
    public class SimulationState
    {
        public readonly List<EventInfo> Events = new List<EventInfo>();
        public readonly List<DamageEvent> DamageEvents = new List<DamageEvent>();
        public double CurrentTime = 0.0;
    }
}
