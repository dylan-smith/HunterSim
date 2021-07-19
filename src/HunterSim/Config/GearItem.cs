using System;
using System.Collections.Generic;
using System.Linq;

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
        public double RangedAttackPower { get; set; }
        public double MeleeAttackPower { get; set; }
        public double CritRating { get; set; }
        public double HitRating { get; set; }
        public double DodgeRating { get; set; }
        public double HasteRating { get; set; }
        public double MP5 { get; set; }
        public double Defense { get; set; }
        public double FireResistance { get; set; }
        public double FrostResistance { get; set; }
        public double ArcaneResistance { get; set; }
        public double NatureResistance { get; set; }
        public double ShadowResistance { get; set; }
        public double ThreatDecrease { get; set; }
        public double Stealth { get; set; }
        public double BonusDPS { get; set; } // Ammo
        public double BonusDamage { get; set; } // E.g. Might of Cenarius
        public GemColor Color { get; set; } // used by gems
        public GearItem SocketBonus { get; set; }
        public WeaponType WeaponType { get; set; }
        public IDictionary<WeaponType, int> WeaponSkill = new Dictionary<WeaponType, int>();
        public GearItem Enchant { get; set; }
        public IList<Socket> Sockets = new List<Socket>();

        public bool IsSocketBonusActive()
        {
            return Sockets.All(x => x.IsColorMatch());
        }

        public double GetStatWithSockets(Func<GearItem, double> statFunc)
        {
            var result = statFunc(this);

            result += Sockets.Where(x => x.Gem != null && x.Gem.Color != GemColor.Meta).Sum(x => statFunc(x.Gem));

            if (SocketBonus != null && IsSocketBonusActive())
            {
                result += statFunc(SocketBonus);
            }

            return result;
        }
    }
}