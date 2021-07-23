using System.Linq;

namespace HunterSim
{
    public class ImprovedAspectOfTheHawkProcEvent : EventInfo
    {
        public ImprovedAspectOfTheHawkProcEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            if (state.Auras.Contains(Aura.ImprovedAspectOfTheHawk))
            {
                state.Auras.Remove(Aura.ImprovedAspectOfTheHawk);
                state.Events.Where(x => x.GetType() == typeof(ImprovedAspectOfTheHawkExpiredEvent)).ForEach(x => state.Events.Remove(x));
            }

            state.Auras.Add(Aura.ImprovedAspectOfTheHawk);
            state.Events.Add(new ImprovedAspectOfTheHawkExpiredEvent(Timestamp + 12));
        }
    }
}
