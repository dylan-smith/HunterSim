using System.Collections.Generic;

namespace HunterSim
{
    public static class AutoShot
    {
        public static bool OnCooldown { get; set; } = false;

        public static void Use(SimulationState state)
        {
            // TODO: Haste
            var autoShotSpeed = state.Config.Gear.Ranged.Speed;
            state.Events.Add(new AutoShotCompletedEvent(state.CurrentTime + autoShotSpeed));
            OnCooldown = true;
        }
    }
}
