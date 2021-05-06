namespace HunterSim
{
    public class DamageEvent : EventInfo
    {
        public readonly double Damage;
        public readonly DamageType DamageType;
        public readonly double MissChance;
        public readonly double CritChance;
        public readonly double HitChance;

        public DamageEvent(double timestamp, double damage, DamageType damageType, double missChance, double critChance, double hitChance) : base(timestamp)
        {
            Damage = damage;
            DamageType = damageType;
            MissChance = missChance;
            CritChance = critChance;
            HitChance = hitChance;
        }

        public override void ProcessEvent(SimulationState state)
        {
            // TODO: Might make sense to have separate HitEvent, MissEvent, CritEvents
            if (DamageType == DamageType.Crit)
            {
                // TODO: This should only trigger off RANGED crits
                state.Events.Add(new ExposeWeaknessAppliedEvent(Timestamp));
            }

            // TODO: Windfury proc
        }

        public override string ToString()
        {
            return $"[{Timestamp.ToString("F1")}] {DamageType} for {Damage.ToString("F2")} [Miss: {MissChance.ToString("F3")}, Crit: {CritChance.ToString("F3")}, Hit: {HitChance.ToString("F3")}]";
        }
    }
}
