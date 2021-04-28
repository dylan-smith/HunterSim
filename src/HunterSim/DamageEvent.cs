namespace HunterSim
{
    public class DamageEvent
    {
        public readonly double Timestamp;
        public readonly double Damage;

        public DamageEvent(double timestamp, double damage)
        {
            Timestamp = timestamp;
            Damage = damage;
        }
    }
}
