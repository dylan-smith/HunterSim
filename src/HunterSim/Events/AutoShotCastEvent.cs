using System.Linq;

namespace HunterSim
{
    public class AutoShotCastEvent : EventInfo
    {
        public AutoShotCastEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            // TODO: Haste
            var autoShotSpeed = state.Config.Gear.Ranged.Speed;
            state.Events.Add(new AutoShotCompletedEvent(Timestamp + 0.5));
            state.Auras.Add(Aura.AutoShotOnCooldown);
            state.Events.Add(new AutoShotCooldownCompletedEvent(Timestamp + autoShotSpeed));
        }
    }
}
