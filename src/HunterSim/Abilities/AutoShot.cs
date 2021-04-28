using System.Collections.Generic;

namespace HunterSim
{
    public static class AutoShot
    {
        public static bool OnCooldown { get; set; } = false;
        private static readonly double _autoShotCooldown = 2.8;

        public static void Use(SimulationState state)
        {
            state.Events.Add(new AutoShotCompletedEvent(state.CurrentTime + _autoShotCooldown));
            OnCooldown = true;
        }
    }
}
