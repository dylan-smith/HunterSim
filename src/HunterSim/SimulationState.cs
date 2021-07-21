using System.Collections.Generic;
using System.Linq;

namespace HunterSim
{
    public class SimulationState
    {
        public readonly IList<EventInfo> Events = new List<EventInfo>();
        public readonly IList<EventInfo> ProcessedEvents = new List<EventInfo>();
        public double CurrentTime = 0.0;
        public readonly ISet<Aura> Auras = new HashSet<Aura>();
        public SimulationConfig Config { get; set; } = new SimulationConfig();
        public readonly IList<string> Warnings = new List<string>();
        public readonly IList<string> Errors = new List<string>();

        public IEnumerable<DamageEvent> DamageEvents => ProcessedEvents.Where(e => e is DamageEvent).Cast<DamageEvent>();

        public bool Validate()
        {
            var (warnings, errors) = Config.Validate();

            Warnings.AddRange(warnings);
            Errors.AddRange(errors);

            return !Errors.Any();
        }
    }
}
