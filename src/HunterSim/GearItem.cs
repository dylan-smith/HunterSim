using System.Collections.Generic;

namespace HunterSim
{
    public class GearItem
    {
        public string Name { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double Speed { get; set; }
        public double Strength { get; set; }
        public double Stamina { get; set; }
        public double Agility { get; set; }
        public double Intellect { get; set; }
        public double Spirit { get; set; }
        public double AttackPower { get; set; }
        public double Crit { get; set; }
        public double Hit { get; set; }
        public WeaponType WeaponType { get; set; }
        public IDictionary<WeaponType, int> WeaponSkill = new Dictionary<WeaponType, int>();
    }
}