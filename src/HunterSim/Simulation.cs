using System;
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
            // TODO: Start MP5 events
            // TODO: Start Spirit events
            // TODO: Raid DPS
            // TODO: Generate Report/Analysis
            // TODO: Pet DPS

            while (true)
            {
                ExecuteRotation();
                var nextEvent = GetNextEvent();

                _state.CurrentTime = nextEvent.Timestamp;

                if (_state.CurrentTime > _state.Config.SimulationSettings.FightLength)
                {
                    return _state;
                }

                while (nextEvent != null && nextEvent.Timestamp == _state.CurrentTime)
                {
                    _state.Events.Remove(nextEvent);
                    nextEvent.ProcessEvent(_state);
                    _state.ProcessedEvents.Add(nextEvent);

                    nextEvent = GetNextEvent();
                }
            }

            throw new Exception("This should never happen");
        }

        private void ExecuteRotation()
        {
            if (!_state.Auras.Contains(Aura.AutoShotOnCooldown))
            {
                _state.Events.Add(new AutoShotCastEvent(_state.CurrentTime));
            }
        }

        private EventInfo GetNextEvent()
        {
            return _state.Events.OrderBy(e => e.Timestamp).FirstOrDefault();
        }
    }
}
