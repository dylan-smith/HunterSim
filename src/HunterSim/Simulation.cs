using System.Collections.Generic;
using System.Linq;

namespace HunterSim
{
    public class Simulation
    {
        private SimulationConfig _config;
        private List<EventInfo> _events = new List<EventInfo>();
        private List<DamageEvent> _damageEvents = new List<DamageEvent>();

        public Simulation(SimulationConfig config)
        {
            _config = config;
        }

        public double Run()
        {
            var currentTime = 0.0;
            _events.Add(new StartFightEvent(currentTime));

            while (_events.Any())
            {
                var nextEvent = GetNextEvent();

                if (nextEvent.Timestamp <= _config.SimulationSettings.FightLength)
                {
                    currentTime = nextEvent.Timestamp;
                    ProcessEvent(nextEvent);
                }
                else
                {
                    _events.Clear();
                }
            }

            return _damageEvents.Sum(x => x.Damage);
        }

        private void ProcessEvent(EventInfo nextEvent)
        {
            _events.Remove(nextEvent);
            nextEvent.ProcessEvent(_damageEvents);

            if (!AutoShot.OnCooldown)
            {
                AutoShot.Use(nextEvent.Timestamp, _events);
            }
        }

        private EventInfo GetNextEvent()
        {
            return _events.OrderBy(e => e.Timestamp).First();
        }
    }
}
