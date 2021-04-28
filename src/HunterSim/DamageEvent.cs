namespace HunterSim
{
    public class DamageEvent
    {
        public readonly double Timestamp;
        public readonly double Damage;
        public readonly DamageType DamageType;
        public readonly double MissChance;
        public readonly double CritChance;
        public readonly double HitChance;

        public DamageEvent(double timestamp, double damage, DamageType damageType, double missChance, double critChance, double hitChance)
        {
            Timestamp = timestamp;
            Damage = damage;
            DamageType = damageType;
            MissChance = missChance;
            CritChance = critChance;
            HitChance = hitChance;
        }
    }
}
