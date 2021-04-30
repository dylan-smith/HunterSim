namespace HunterSim
{
    public abstract class EventInfo
    {
        public double Timestamp { get; set; }

        public EventInfo(double timestamp)
        {
            Timestamp = timestamp;
        }

        public abstract void ProcessEvent(SimulationState state);

        public override string ToString()
        {
            return $"[{Timestamp.ToString("F1")}] {this.GetType().Name}";
        }
    }
}
