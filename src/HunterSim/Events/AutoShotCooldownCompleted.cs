namespace HunterSim
{
    public class AutoShotCooldownCompleted : EventInfo
    {
        public AutoShotCooldownCompleted(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            state.Auras.Remove(Aura.AutoShotOnCooldown);
        }
    }
}
