using System;
using System.Collections.Generic;
using System.Linq;

namespace HunterSim
{
    public class GearItem
    {
        // TODO: Gems
        public GearType GearType { get; set; }
        public string Name { get; set; }
        public double MinDamage { get; set; } // Weapons
        public double MaxDamage { get; set; } // Weapons
        public double Speed { get; set; } // Weapons
        public double Armor { get; set; }
        public double TotalArmor { get { return GetStatWithSockets(x => x.Armor); } }
        public double Strength { get; set; }
        public double TotalStrength { get { return GetStatWithSockets(x => x.Strength); } }
        public double Stamina { get; set; }
        public double TotalStamina { get { return GetStatWithSockets(x => x.Stamina); } }
        public double Agility { get; set; }
        public double TotalAgility { get { return GetStatWithSockets(x => x.Agility); } }
        public double Intellect { get; set; }
        public double TotalIntellect { get { return GetStatWithSockets(x => x.Intellect); } }
        public double Spirit { get; set; }
        public double TotalSpirit { get { return GetStatWithSockets(x => x.Spirit); } }
        public double AttackPower { get; set; }
        public double TotalAttackPower { get { return GetStatWithSockets(x => x.AttackPower); } }
        public double RangedAttackPower { get; set; }
        public double TotalRangedAttackPower { get { return GetStatWithSockets(x => x.RangedAttackPower); } }
        public double MeleeAttackPower { get; set; }
        public double TotalMeleeAttackPower { get { return GetStatWithSockets(x => x.MeleeAttackPower); } }
        public double CritRating { get; set; }
        public double TotalCritRating { get { return GetStatWithSockets(x => x.CritRating); } }
        public double HitRating { get; set; }
        public double TotalHitRating { get { return GetStatWithSockets(x => x.HitRating); } }
        public double DodgeRating { get; set; }
        public double TotalDodgeRating { get { return GetStatWithSockets(x => x.DodgeRating); } }
        public double HasteRating { get; set; }
        public double TotalHasteRating { get { return GetStatWithSockets(x => x.HasteRating); } }
        public double MP5 { get; set; }
        public double TotalMP5 { get { return GetStatWithSockets(x => x.MP5); } }
        public double Defense { get; set; }
        public double TotalDefense { get { return GetStatWithSockets(x => x.Defense); } }
        public double FireResistance { get; set; }
        public double TotalFireResistance { get { return GetStatWithSockets(x => x.FireResistance); } }
        public double FrostResistance { get; set; }
        public double TotalFrostResistance { get { return GetStatWithSockets(x => x.FrostResistance); } }
        public double ArcaneResistance { get; set; }
        public double TotalArcaneResistance { get { return GetStatWithSockets(x => x.ArcaneResistance); } }
        public double NatureResistance { get; set; }
        public double TotalNatureResistance { get { return GetStatWithSockets(x => x.NatureResistance); } }
        public double ShadowResistance { get; set; }
        public double TotalShadowResistance { get { return GetStatWithSockets(x => x.ShadowResistance); } }
        public double ThreatDecrease { get; set; }
        public double TotalThreatDecrease { get { return GetStatWithSockets(x => x.ThreatDecrease); } }
        public double Stealth { get; set; }
        public double TotalStealth { get { return GetStatWithSockets(x => x.Stealth); } }
        public double BonusDPS { get; set; } // Ammo
        public double TotalBonusDPS { get { return GetStatWithSockets(x => x.BonusDPS); } }
        public double BonusDamage { get; set; } // E.g. Might of Cenarius
        public double TotalBonusDamage { get { return GetStatWithSockets(x => x.BonusDamage); } }
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

            result += Sockets.Where(x => x.Gem != null).Sum(x => statFunc(x.Gem));

            if (SocketBonus != null && IsSocketBonusActive())
            {
                result += statFunc(SocketBonus);
            }

            return result;
        }

        // TODO: Need meta gem activation logic too
    }
}