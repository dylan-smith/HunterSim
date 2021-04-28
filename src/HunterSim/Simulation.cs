using System.Collections.Generic;
using System.Linq;

namespace HunterSim
{
    public class Simulation
    {
        private readonly SimulationState _state = new SimulationState();

        public Simulation(SimulationConfig config)
        {
            _state.Config = config;
        }

        public SimulationState Run()
        {
            _state.Events.Add(new StartFightEvent(_state.CurrentTime));

            while (_state.Events.Any())
            {
                var nextEvent = GetNextEvent();

                if (nextEvent.Timestamp <= _state.Config.SimulationSettings.FightLength)
                {
                    _state.CurrentTime = nextEvent.Timestamp;
                    ProcessEvent(nextEvent);
                }
                else
                {
                    _state.Events.Clear();
                }
            }

            return _state;
        }

        private void ProcessEvent(EventInfo nextEvent)
        {
            _state.Events.Remove(nextEvent);
            nextEvent.ProcessEvent(_state);

            if (!AutoShot.OnCooldown)
            {
                AutoShot.Use(_state);
            }
        }

        private EventInfo GetNextEvent()
        {
            return _state.Events.OrderBy(e => e.Timestamp).First();
        }
    }
}
