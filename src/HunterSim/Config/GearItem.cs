using System.Collections.Generic;

namespace HunterSim
{
    public class GearItem
    {
        public GearType GearType { get; set; }
        public string Name { get; set; }
        public double MinDamage { get; set; } // Weapons
        public double MaxDamage { get; set; } // Weapons
        public double Speed { get; set; } // Weapons
        public double Armor { get; set; }
        public double Strength { get; set; }
        public double Stamina { get; set; }
        public double Agility { get; set; }
        public double Intellect { get; set; }
        public double Spirit { get; set; }
        public double AttackPower { get; set; }
        public double Crit { get; set; }
        public double Hit { get; set; }
        public double Dodge { get; set; }
        public double Haste { get; set; }
        public double MP5 { get; set; }
        public double Defense { get; set; }
        public double BonusDPS { get; set; } // Ammo
        public double BonusDamage { get; set; } // E.g. Might of Cenarius
        public WeaponType WeaponType { get; set; }
        public IDictionary<WeaponType, int> WeaponSkill = new Dictionary<WeaponType, int>();
    }
}