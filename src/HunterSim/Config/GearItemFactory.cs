using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using YamlDotNet.Serialization;

namespace HunterSim
{
    public class GearItemFactory
    {
        private static IEnumerable<GearItem> _allGear;
        private static IEnumerable<GearItem> _equippableMainHand;
        private static IEnumerable<GearItem> _equippableOffHand;
        private static IEnumerable<GearItem> _allEnchants;
        private static IEnumerable<GearItem> _twoHandEnchants;

        private static IDictionary<GearType, IEnumerable<GearItem>> _gearByType;
        private static IDictionary<GearType, IEnumerable<GearItem>> _enchantsByType;

        // TODO: Gear Set bonuses

        public static IEnumerable<GearItem> AllGear
        {
            get
            {
                if (_allGear == null)
                {
                    LoadAllGear();
                }

                return _allGear;
            }
        }

        public static IEnumerable<GearItem> AllEquippableMainHands
        {
            get
            {
                if (_equippableMainHand == null)
                {
                    LoadAllGear();
                }

                return _equippableMainHand;
            }
        }

        public static IEnumerable<GearItem> AllEquippableOffHands
        {
            get
            {
                if (_equippableOffHand == null)
                {
                    LoadAllGear();
                }

                return _equippableOffHand;
            }
        }

        public static IEnumerable<GearItem> AllEnchants
        {
            get
            {
                if (_allEnchants == null)
                {
                    LoadAllGear();
                }

                return _allEnchants;
            }
        }

        public static IEnumerable<GearItem> AllTwoHandEnchants
        {
            get
            {
                if (_twoHandEnchants == null)
                {
                    LoadAllGear();
                }

                return _twoHandEnchants;
            }
        }

        public static IEnumerable<GearItem> AllAmmo
        {
            get
            {
                return GetGearByType(GearType.Ammo);
            }
        }

        public static IEnumerable<GearItem> AllBack
        {
            get
            {
                return GetGearByType(GearType.Back);
            }
        }

        public static IEnumerable<GearItem> AllChest
        {
            get
            {
                return GetGearByType(GearType.Chest);
            }
        }

        public static IEnumerable<GearItem> AllFeet
        {
            get
            {
                return GetGearByType(GearType.Feet);
            }
        }

        public static IEnumerable<GearItem> AllFinger
        {
            get
            {
                return GetGearByType(GearType.Finger);
            }
        }

        public static IEnumerable<GearItem> AllHands
        {
            get
            {
                return GetGearByType(GearType.Hands);
            }
        }

        public static IEnumerable<GearItem> AllHead
        {
            get
            {
                return GetGearByType(GearType.Head);
            }
        }

        public static IEnumerable<GearItem> AllLegs
        {
            get
            {
                return GetGearByType(GearType.Legs);
            }
        }

        public static IEnumerable<GearItem> AllMainHand
        {
            get
            {
                return GetGearByType(GearType.MainHand);
            }
        }

        public static IEnumerable<GearItem> AllNeck
        {
            get
            {
                return GetGearByType(GearType.Neck);
            }
        }

        public static IEnumerable<GearItem> AllOffHand
        {
            get
            {
                return GetGearByType(GearType.OffHand);
            }
        }

        public static IEnumerable<GearItem> AllQuiver
        {
            get
            {
                return GetGearByType(GearType.Quiver);
            }
        }

        public static IEnumerable<GearItem> AllRanged
        {
            get
            {
                return GetGearByType(GearType.Ranged);
            }
        }

        public static IEnumerable<GearItem> AllShoulder
        {
            get
            {
                return GetGearByType(GearType.Shoulder);
            }
        }

        public static IEnumerable<GearItem> AllTrinket
        {
            get
            {
                return GetGearByType(GearType.Trinket);
            }
        }

        public static IEnumerable<GearItem> AllWaist
        {
            get
            {
                return GetGearByType(GearType.Waist);
            }
        }

        public static IEnumerable<GearItem> AllWrist
        {
            get
            {
                return GetGearByType(GearType.Wrist);
            }
        }

        public static IEnumerable<GearItem> AllBackEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Back);
            }
        }

        public static IEnumerable<GearItem> AllChestEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Chest);
            }
        }

        public static IEnumerable<GearItem> AllFeetEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Feet);
            }
        }

        public static IEnumerable<GearItem> AllHandEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Hands);
            }
        }

        public static IEnumerable<GearItem> AllHeadEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Head);
            }
        }

        public static IEnumerable<GearItem> AllLegEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Legs);
            }
        }

        public static IEnumerable<GearItem> AllOneHandEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.OneHand);
            }
        }

        public static IEnumerable<GearItem> AllRangedEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Ranged);
            }
        }

        public static IEnumerable<GearItem> AllShoulderEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Shoulder);
            }
        }

        public static IEnumerable<GearItem> AllWristEnchants
        {
            get
            {
                return GetEnchantsByType(GearType.Wrist);
            }
        }

        public static GearItem Load(string itemName)
        {
            return AllGear.Single(x => x.Name == itemName);
        }

        public static GearItem LoadAmmo(string itemName)
        {
            return AllAmmo.Single(x => x.Name == itemName);
        }

        public static GearItem LoadBack(string itemName)
        {
            return AllBack.Single(x => x.Name == itemName);
        }

        public static GearItem LoadChest(string itemName)
        {
            return AllChest.Single(x => x.Name == itemName);
        }

        public static GearItem LoadFeet(string itemName)
        {
            return AllFeet.Single(x => x.Name == itemName);
        }

        public static GearItem LoadFinger(string itemName)
        {
            return AllFinger.Single(x => x.Name == itemName);
        }

        public static GearItem LoadHands(string itemName)
        {
            return AllHands.Single(x => x.Name == itemName);
        }

        public static GearItem LoadHead(string itemName)
        {
            return AllHead.Single(x => x.Name == itemName);
        }

        public static GearItem LoadLegs(string itemName)
        {
            return AllLegs.Single(x => x.Name == itemName);
        }

        public static GearItem LoadMainHand(string itemName)
        {
            return AllEquippableMainHands.Single(x => x.Name == itemName);
        }

        public static GearItem LoadNeck(string itemName)
        {
            return AllNeck.Single(x => x.Name == itemName);
        }

        public static GearItem LoadOffHand(string itemName)
        {
            return AllEquippableOffHands.Single(x => x.Name == itemName);
        }

        public static GearItem LoadQuiver(string itemName)
        {
            return AllQuiver.Single(x => x.Name == itemName);
        }

        public static GearItem LoadRanged(string itemName)
        {
            return AllRanged.Single(x => x.Name == itemName);
        }

        public static GearItem LoadShoulder(string itemName)
        {
            return AllShoulder.Single(x => x.Name == itemName);
        }

        public static GearItem LoadTrinket(string itemName)
        {
            return AllTrinket.Single(x => x.Name == itemName);
        }

        public static GearItem LoadWaist(string itemName)
        {
            return AllWaist.Single(x => x.Name == itemName);
        }

        public static GearItem LoadWrist(string itemName)
        {
            return AllWrist.Single(x => x.Name == itemName);
        }

        public static GearItem LoadEnchant(string enchantName)
        {
            return AllEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadBackEnchant(string enchantName)
        {
            return AllBackEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadChestEnchant(string enchantName)
        {
            return AllChestEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadFeetEnchant(string enchantName)
        {
            return AllFeetEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadHandEnchant(string enchantName)
        {
            return AllHandEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadHeadEnchant(string enchantName)
        {
            return AllHeadEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadLegEnchant(string enchantName)
        {
            return AllLegEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadOneHandEnchant(string enchantName)
        {
            return AllOneHandEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadTwoHandEnchant(string enchantName)
        {
            return AllTwoHandEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadRangedEnchant(string enchantName)
        {
            return AllRangedEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadShoulderEnchant(string enchantName)
        {
            return AllShoulderEnchants.Single(x => x.Name == enchantName);
        }

        public static GearItem LoadWristEnchant(string enchantName)
        {
            return AllWristEnchants.Single(x => x.Name == enchantName);
        }

        private static IEnumerable<GearItem> GetGearByType(GearType gearType)
        {
            if (_allGear == null)
            {
                LoadAllGear();
            }

            return _gearByType[gearType];
        }

        private static IEnumerable<GearItem> GetEnchantsByType(GearType enchantType)
        {
            if (_allEnchants == null)
            {
                LoadAllGear();
            }

            return _enchantsByType[enchantType];
        }

        private static void LoadAllGear()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var gearPath = Path.Join(assemblyPath, "Gear");
            var enchantsPath = Path.Join(assemblyPath, "Enchants");

            _gearByType = new Dictionary<GearType, IEnumerable<GearItem>>();
            _allGear = new List<GearItem>();
            _enchantsByType = new Dictionary<GearType, IEnumerable<GearItem>>();
            _allEnchants = new List<GearItem>();

            foreach (var gearType in Enum.GetValues(typeof(GearType)).Cast<GearType>())
            {
                var gear = LoadAllFromDir(gearPath, gearType);
                _gearByType.Add(gearType, gear);
                _allGear = _allGear.Union(gear);

                var enchants = LoadAllFromDir(enchantsPath, gearType);
                _enchantsByType.Add(gearType, enchants);
                _allEnchants = _allEnchants.Union(enchants);
            }

            _allGear = _allGear.ToList();
            _allEnchants = _allEnchants.ToList();

            _equippableMainHand = _gearByType[GearType.MainHand].Union(_gearByType[GearType.OneHand]).ToList();
            _equippableOffHand = _gearByType[GearType.OffHand].Union(_gearByType[GearType.OneHand]).ToList();

            _twoHandEnchants = _enchantsByType[GearType.TwoHand].Union(_enchantsByType[GearType.OneHand]).ToList();
        }

        private static IEnumerable<GearItem> LoadAllFromDir(string gearPath, GearType gearType)
        {
            var path = Path.Join(gearPath, gearType.ToString());

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.yml");

                foreach (var file in files)
                {
                    yield return LoadGearItemFromFile(file, gearType);
                }
            }
        }

        private static GearItem LoadGearItemFromFile(string path, GearType gearType)
        {
            var deserializer = new Deserializer();
            var fileContents = File.ReadAllText(path);
            var dict = deserializer.Deserialize<Dictionary<string, string>>(fileContents);

            var result = new GearItem();
            result.GearType = gearType;

            // TODO: Do a bunch of validation here
            // TODO: Can probably use WithAttributeOverride feature in yaml deserializer to make this code simpler

            if (dict.ContainsKey("name"))
            {
                result.Name = dict["name"];
                dict.Remove("name");
            }

            if (dict.ContainsKey("mindmg"))
            {
                result.MinDamage = double.Parse(dict["mindmg"]);
                dict.Remove("mindmg");
            }

            if (dict.ContainsKey("maxdmg"))
            {
                result.MaxDamage = double.Parse(dict["maxdmg"]);
                dict.Remove("maxdmg");
            }

            if (dict.ContainsKey("speed"))
            {
                result.Speed = double.Parse(dict["speed"]);
                dict.Remove("speed");
            }

            if (dict.ContainsKey("armor"))
            {
                result.Armor = double.Parse(dict["armor"]);
                dict.Remove("armor");
            }

            if (dict.ContainsKey("strength"))
            {
                result.Strength = double.Parse(dict["strength"]);
                dict.Remove("strength");
            }

            if (dict.ContainsKey("stamina"))
            {
                result.Stamina = double.Parse(dict["stamina"]);
                dict.Remove("stamina");
            }

            if (dict.ContainsKey("agility"))
            {
                result.Agility = double.Parse(dict["agility"]);
                dict.Remove("agility");
            }

            if (dict.ContainsKey("intellect"))
            {
                result.Intellect = double.Parse(dict["intellect"]);
                dict.Remove("intellect");
            }

            if (dict.ContainsKey("spirit"))
            {
                result.Spirit = double.Parse(dict["spirit"]);
                dict.Remove("spirit");
            }

            if (dict.ContainsKey("ap"))
            {
                result.AttackPower = double.Parse(dict["ap"]);
                dict.Remove("ap");
            }

            if (dict.ContainsKey("rap"))
            {
                result.RangedAttackPower = double.Parse(dict["rap"]);
                dict.Remove("rap");
            }

            if (dict.ContainsKey("crit"))
            {
                result.Crit = double.Parse(dict["crit"]) / 100;
                dict.Remove("crit");
            }

            if (dict.ContainsKey("hit"))
            {
                result.Hit = double.Parse(dict["hit"]) / 100;
                dict.Remove("hit");
            }

            if (dict.ContainsKey("dodge"))
            {
                result.Dodge = double.Parse(dict["dodge"]) / 100;
                dict.Remove("dodge");
            }

            if (dict.ContainsKey("haste"))
            {
                result.Haste = double.Parse(dict["haste"]) / 100;
                dict.Remove("haste");
            }

            if (dict.ContainsKey("mp5"))
            {
                result.MP5 = double.Parse(dict["mp5"]);
                dict.Remove("mp5");
            }

            if (dict.ContainsKey("defense"))
            {
                result.Defense = double.Parse(dict["defense"]);
                dict.Remove("defense");
            }

            if (dict.ContainsKey("fireresist"))
            {
                result.FireResistance = double.Parse(dict["fireresist"]);
                dict.Remove("fireresist");
            }

            if (dict.ContainsKey("frostresist"))
            {
                result.FrostResistance = double.Parse(dict["frostresist"]);
                dict.Remove("frostresist");
            }

            if (dict.ContainsKey("arcaneresist"))
            {
                result.ArcaneResistance = double.Parse(dict["arcaneresist"]);
                dict.Remove("arcaneresist");
            }

            if (dict.ContainsKey("natureresist"))
            {
                result.NatureResistance = double.Parse(dict["natureresist"]);
                dict.Remove("natureresist");
            }

            if (dict.ContainsKey("shadowresist"))
            {
                result.ShadowResistance = double.Parse(dict["shadowresist"]);
                dict.Remove("shadowresist");
            }

            if (dict.ContainsKey("threat"))
            {
                result.ThreatDecrease = (0 - double.Parse(dict["threat"])) / 100;
                dict.Remove("threat");
            }

            if (dict.ContainsKey("bonusdps"))
            {
                result.BonusDPS = double.Parse(dict["bonusdps"]);
                dict.Remove("bonusdps");
            }

            if (dict.ContainsKey("bonusdmg"))
            {
                result.BonusDamage = double.Parse(dict["bonusdmg"]);
                dict.Remove("bonusdmg");
            }

            if (dict.ContainsKey("type"))
            {
                switch (dict["type"])
                {
                    case "bow":
                        result.WeaponType = WeaponType.Bow;
                        break;
                    case "crossbow":
                        result.WeaponType = WeaponType.Crossbow;
                        break;
                    case "dagger":
                        result.WeaponType = WeaponType.Dagger;
                        break;
                    case "fist":
                        result.WeaponType = WeaponType.Fist;
                        break;
                    case "gun":
                        result.WeaponType = WeaponType.Gun;
                        break;
                    case "axe":
                        result.WeaponType = WeaponType.OneHandedAxe;
                        break;
                    case "mace":
                        result.WeaponType = WeaponType.OneHandedMace;
                        break;
                    case "sword":
                        result.WeaponType = WeaponType.OneHandedSword;
                        break;
                    case "polearm":
                        result.WeaponType = WeaponType.Polearm;
                        break;
                    case "staff":
                        result.WeaponType = WeaponType.Staff;
                        break;
                    case "thrown":
                        result.WeaponType = WeaponType.Thrown;
                        break;
                    case "two-handed-axe":
                        result.WeaponType = WeaponType.TwoHandedAxe;
                        break;
                    case "two-handed-mace":
                        result.WeaponType = WeaponType.TwoHandedMace;
                        break;
                    case "two-handed-sword":
                        result.WeaponType = WeaponType.TwoHandedSword;
                        break;
                    case "wand":
                        result.WeaponType = WeaponType.Wand;
                        break;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Unrecognized weapon type");
                }

                dict.Remove("type");
            }

            if (dict.ContainsKey("bow-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Bow, int.Parse(dict["bow-skill"]));
                dict.Remove("bow-skill");
            }

            if (dict.ContainsKey("crossbow-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Crossbow, int.Parse(dict["crossbow-skill"]));
                dict.Remove("crossbow-skill");
            }

            if (dict.ContainsKey("dagger-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Dagger, int.Parse(dict["dagger-skill"]));
                dict.Remove("dagger-skill");
            }

            if (dict.ContainsKey("fist-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Fist, int.Parse(dict["fist-skill"]));
                dict.Remove("fist-skill");
            }

            if (dict.ContainsKey("gun-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Gun, int.Parse(dict["gun-skill"]));
                dict.Remove("gun-skill");
            }

            if (dict.ContainsKey("axe-skill"))
            {
                result.WeaponSkill.Add(WeaponType.OneHandedAxe, int.Parse(dict["axe-skill"]));
                dict.Remove("axe-skill");
            }

            if (dict.ContainsKey("mace-skill"))
            {
                result.WeaponSkill.Add(WeaponType.OneHandedSword, int.Parse(dict["mace-skill"]));
                dict.Remove("mace-skill");
            }

            if (dict.ContainsKey("sword-skill"))
            {
                result.WeaponSkill.Add(WeaponType.OneHandedSword, int.Parse(dict["sword-skill"]));
                dict.Remove("sword-skill");
            }

            if (dict.ContainsKey("polearm-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Polearm, int.Parse(dict["polearm-skill"]));
                dict.Remove("polearm-skill");
            }

            if (dict.ContainsKey("staff-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Staff, int.Parse(dict["staff-skill"]));
                dict.Remove("staff-skill");
            }

            if (dict.ContainsKey("thrown-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Thrown, int.Parse(dict["thrown-skill"]));
                dict.Remove("thrown-skill");
            }

            if (dict.ContainsKey("two-handed-axe-skill"))
            {
                result.WeaponSkill.Add(WeaponType.TwoHandedAxe, int.Parse(dict["two-handed-axe-skill"]));
                dict.Remove("two-handed-axe-skill");
            }

            if (dict.ContainsKey("two-handed-mace-skill"))
            {
                result.WeaponSkill.Add(WeaponType.TwoHandedMace, int.Parse(dict["two-handed-mace-skill"]));
                dict.Remove("two-handed-mace-skill");
            }

            if (dict.ContainsKey("two-handed-sword-skill"))
            {
                result.WeaponSkill.Add(WeaponType.TwoHandedSword, int.Parse(dict["two-handed-sword-skill"]));
                dict.Remove("two-handed-sword-skill");
            }

            if (dict.ContainsKey("wand-skill"))
            {
                result.WeaponSkill.Add(WeaponType.Wand, int.Parse(dict["wand-skill"]));
                dict.Remove("wand-skill");
            }

            if (dict.ContainsKey("wowhead"))
            {
                dict.Remove("wowhead");
            }

            if (dict.ContainsKey("phase"))
            {
                dict.Remove("phase");
            }

            if (dict.ContainsKey("source"))
            {
                dict.Remove("source");
            }

            if (dict.Count > 0)
            {
                // TODO: Richer exceptions
                throw new Exception("Unrecognized attributes in YAML");
            }

            return result;
        }
    }
}
