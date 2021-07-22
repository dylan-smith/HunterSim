namespace HunterSim
{
    public class ImprovedAspectOfTheHawkExpired : EventInfo
    {
        public ImprovedAspectOfTheHawkExpired(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            state.Auras.Remove(Aura.ImprovedAspectOfTheHawk);
        }
    }
}
