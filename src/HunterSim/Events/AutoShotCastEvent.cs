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
            // TODO: I don't think this is how auto-shot works, it should be a one-time 0.5s cast time, then immediate dmg, followed by weapon cooldown
            var autoShotSpeed = state.Config.Gear.Ranged.Speed;
            state.Events.Add(new AutoShotCompletedEvent(Timestamp + autoShotSpeed));
            state.Auras.Add(Aura.AutoShotOnCooldown);

        }
    }
}
