using System.Linq;

namespace HunterSim
{
    public class ExposeWeaknessAppliedEvent : EventInfo
    {
        public ExposeWeaknessAppliedEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            if (!state.Auras.Add(Aura.ExposeWeakness))
            {
                var fadeEvent = state.Events.Single(e => e is ExposeWeaknessFadesEvent);
                state.Events.Remove(fadeEvent);
            }

            state.Events.Add(new ExposeWeaknessFadesEvent(Timestamp + 7.0));
        }
    }
}
