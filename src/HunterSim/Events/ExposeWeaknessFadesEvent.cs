namespace HunterSim
{
    public class ExposeWeaknessFadesEvent : EventInfo
    {
        public ExposeWeaknessFadesEvent(double timestamp) : base(timestamp)
        { }

        public override void ProcessEvent(SimulationState state)
        {
            state.Auras.Remove(Aura.ExposeWeakness);
        }
    }
}
