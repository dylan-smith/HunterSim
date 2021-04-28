using System.Collections.Generic;

namespace HunterSim
{
    public class StartFightEvent : EventInfo
    {
        public StartFightEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
        }
    }
}
