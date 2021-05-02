namespace HunterSim
{
    public class AutoShotCoodownCompleted : EventInfo
    {
        public AutoShotCoodownCompleted(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            state.Auras.Remove(Aura.AutoShotOnCooldown);
        }
    }
}
