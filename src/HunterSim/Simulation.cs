using System.Collections.Generic;
using System.Linq;

namespace HunterSim
{
    public class Simulation
    {
        private SimulationConfig _config;
        private List<EventInfo> _events;

        public Simulation(SimulationConfig config)
        {
            _config = config;
        }

        public double Run()
        {
            _events = new List<EventInfo>
            {
                new EventInfo(0.0)
            };

            var currentTime = 0.0;

            while (currentTime <= _config.FightLength && _events.Any())
            {
                var nextEvent = GetNextEvent();
                currentTime = nextEvent.Timestamp;
                ProcessEvent(nextEvent);
            }

            return 0.0;
        }

        private void ProcessEvent(EventInfo nextEvent)
        {
            _events.Remove(nextEvent);
        }

        private EventInfo GetNextEvent()
        {
            return _events.OrderBy(e => e.Timestamp).First();
        }
    }
}
