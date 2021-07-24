using System;
using System.Linq;

namespace HunterSim
{
    public class Simulation
    {
        private readonly SimulationState _state = new SimulationState();

        public Simulation(SimulationConfig config) => _state.Config = config;

        public SimulationState Run()
        {
            // TODO: Start MP5 events
            // TODO: Start Spirit events
            // TODO: Raid DPS
            // TODO: Generate Report/Analysis
            // TODO: Pet DPS
            // TODO: Apply aspect of the hawk

            if (!_state.Validate())
            {
                return _state;
            }

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

                    EventPublisher.PublishEvent(nextEvent, _state);

                    nextEvent = GetNextEvent();
                }
            }

            throw new Exception("This should never happen");
        }

        private void ExecuteRotation()
        {
            // TODO: config setting for whether we are responsible for refreshing hunters mark
            // TODO: config setting for if/when we cast feign death
            // TODO: config settings for potion usage
            if (AutoShot.CanUse(_state))
            {
                AutoShot.Use(_state);
            }
        }

        private EventInfo GetNextEvent() => _state.Events.OrderBy(e => e.Timestamp).FirstOrDefault();
    }
}
