using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using YamlDotNet.RepresentationModel;
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
                    yield return LoadGearItem(File.ReadAllText(file), gearType);
                }
            }
        }

        private static GearItem LoadGearItem(string yaml, GearType gearType)
        {
            // TODO: Create a yaml schema and validate against it
            using var yamlReader = new StringReader(yaml);
            var yamlStream = new YamlStream();
            yamlStream.Load(yamlReader);

            var rootNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;

            return LoadGearItem(rootNode, gearType);
        }

        private static GearItem LoadGearItem(YamlMappingNode yamlNode, GearType gearType)
        {
            var result = new GearItem();
            result.GearType = gearType;

            foreach (var statItem in yamlNode.Children)
            {
                var statName = ((YamlScalarNode)statItem.Key).Value;

                // TODO: Use custom attributes on GearItem so we can do this mapping dynamically
                if (statName == "name")
                {
                    result.Name = ((YamlScalarNode)statItem.Value).Value;
                    continue;
                }

                if (statName == "mindmg")
                {
                    result.MinDamage = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "maxdmg")
                {
                    result.MaxDamage = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "speed")
                {
                    result.Speed = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "armor")
                {
                    result.Armor = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "strength")
                {
                    result.Strength = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "stamina")
                {
                    result.Stamina = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "agility")
                {
                    result.Agility = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "intellect")
                {
                    result.Intellect = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "spirit")
                {
                    result.Spirit = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "ap")
                {
                    result.AttackPower = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "rap")
                {
                    result.RangedAttackPower = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "map")
                {
                    result.MeleeAttackPower = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "crit")
                {
                    result.CritRating = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "hit")
                {
                    result.HitRating = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "dodge")
                {
                    result.DodgeRating = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "haste")
                {
                    result.HasteRating = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "mp5")
                {
                    result.MP5 = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "defense")
                {
                    result.Defense = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "fireresist")
                {
                    result.FireResistance = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "frostresist")
                {
                    result.FrostResistance = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "arcaneresist")
                {
                    result.ArcaneResistance = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "natureresist")
                {
                    result.NatureResistance = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "shadowresist")
                {
                    result.ShadowResistance = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "threat")
                {
                    result.ThreatDecrease = (0.0 - double.Parse(((YamlScalarNode)statItem.Value).Value)) / 100.0;
                    continue;
                }

                if (statName == "stealth")
                {
                    result.Stealth = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "bonusdps")
                {
                    result.BonusDPS = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "bonusdmg")
                {
                    result.BonusDamage = double.Parse(((YamlScalarNode)statItem.Value).Value);
                    continue;
                }

                if (statName == "type")
                {
                    var typeValue = ((YamlScalarNode)statItem.Value).Value;

                    // TODO: Should move this to the Enum class
                    switch (typeValue)
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

                    continue;
                }

                if (statName == "bow-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Bow, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "crossbow-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Crossbow, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "dagger-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Dagger, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "fist-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Fist, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "gun-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Gun, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "axe-skill")
                {
                    result.WeaponSkill.Add(WeaponType.OneHandedAxe, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "mace-skill")
                {
                    result.WeaponSkill.Add(WeaponType.OneHandedMace, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "sword-skill")
                {
                    result.WeaponSkill.Add(WeaponType.OneHandedSword, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "polearm-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Polearm, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "staff-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Staff, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "thrown-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Thrown, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "two-handed-axe-skill")
                {
                    result.WeaponSkill.Add(WeaponType.TwoHandedAxe, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "two-handed-mace-skill")
                {
                    result.WeaponSkill.Add(WeaponType.TwoHandedMace, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "two-handed-sword-skill")
                {
                    result.WeaponSkill.Add(WeaponType.TwoHandedSword, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "wand-skill")
                {
                    result.WeaponSkill.Add(WeaponType.Wand, int.Parse(((YamlScalarNode)statItem.Value).Value));
                    continue;
                }

                if (statName == "wowhead")
                {
                    // TODO
                    continue;
                }

                if (statName == "phase")
                {
                    // TODO
                    continue;
                }

                if (statName == "source")
                {
                    // TODO
                    continue;
                }

                if (statName == "sockets")
                {
                    var socketsNode = (YamlMappingNode)statItem.Value;

                    foreach (var socketItem in socketsNode.Children)
                    {
                        var socketName = ((YamlScalarNode)socketItem.Key).Value;

                        // TODO: Can probably simplify these ifs by having the SocketColor enum have a FromString
                        if (socketName == "red")
                        {
                            var socketCount = int.Parse(((YamlScalarNode)socketItem.Value).Value);

                            for (var i = 0; i < socketCount; i++)
                            {
                                result.Sockets.Add(new Socket() { Color = SocketColor.Red });
                            }

                            continue;
                        }

                        if (socketName == "blue")
                        {
                            var socketCount = int.Parse(((YamlScalarNode)socketItem.Value).Value);

                            for (var i = 0; i < socketCount; i++)
                            {
                                result.Sockets.Add(new Socket() { Color = SocketColor.Blue });
                            }

                            continue;
                        }

                        if (socketName == "yellow")
                        {
                            var socketCount = int.Parse(((YamlScalarNode)socketItem.Value).Value);

                            for (var i = 0; i < socketCount; i++)
                            {
                                result.Sockets.Add(new Socket() { Color = SocketColor.Yellow });
                            }

                            continue;
                        }

                        if (socketName == "meta")
                        {
                            var socketCount = int.Parse(((YamlScalarNode)socketItem.Value).Value);

                            for (var i = 0; i < socketCount; i++)
                            {
                                result.Sockets.Add(new Socket() { Color = SocketColor.Meta });
                            }

                            continue;
                        }

                        if (socketName == "bonus")
                        {
                            var bonusNode = (YamlMappingNode)socketItem.Value;

                            result.SocketBonus = LoadGearItem(bonusNode, GearType.SocketBonus);
                            continue;
                        }

                        throw new Exception($"Unrecognized attribute in YAML ({socketName})");
                    }

                    continue;
                }

                throw new Exception($"Unrecognized attribute in YAML ({statName})");
            }

            return result;
        }
    }
}
