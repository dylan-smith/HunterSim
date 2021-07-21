using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using YamlDotNet.Core.Events;
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

        public static GearItem LoadGearItem(string yaml, GearType gearType)
        {
            ValidateYamlAgainstSchema(yaml);

            using var yamlReader = new StringReader(yaml);
            var yamlStream = new YamlStream();
            yamlStream.Load(yamlReader);

            var rootNode = (YamlMappingNode)yamlStream.Documents[0].RootNode;
            
            return LoadGearItem(rootNode, gearType);
        }

        private static void ValidateYamlAgainstSchema(string yaml)
        {
            if (string.IsNullOrWhiteSpace(yaml))
            {
                throw new Exception("Empty YAML file");
            }

            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var schemaPath = Path.Join(assemblyPath, "Config", "GearItem-Schema.json");
            var schemaJson = File.ReadAllText(schemaPath);
            var schema = JSchema.Load(new JsonTextReader(new StringReader(schemaJson)));

            var deserializer = new DeserializerBuilder()
                                   .WithNodeTypeResolver(new InferTypeFromValue())
                                   .Build();
            var data = deserializer.Deserialize(new StringReader(yaml));

            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            var serializer = new JsonSerializer();
            serializer.Serialize(sw, data);

            JObject.Parse(sb.ToString()).Validate(schema);
        }

        private class InferTypeFromValue : INodeTypeResolver
        {
            public bool Resolve(NodeEvent nodeEvent, ref Type currentType)
            {
                if (nodeEvent is Scalar scalar)
                {
                    if (int.TryParse(scalar.Value, out _))
                    {
                        currentType = typeof(int);
                        return true;
                    }

                    if (decimal.TryParse(scalar.Value, out _))
                    {
                        currentType = typeof(decimal);
                        return true;
                    }

                    if (bool.TryParse(scalar.Value, out _))
                    {
                        currentType = typeof(bool);
                        return true;
                    }
                }

                return false;
            }
        }

        private static GearItem LoadGearItem(YamlMappingNode yamlNode, GearType gearType)
        {
            var result = new GearItem
            {
                GearType = gearType
            };

            foreach (var statItem in yamlNode.Children)
            {
                var statName = ((YamlScalarNode)statItem.Key).Value;

                if (statName.EndsWith("-skill"))
                {
                    var weaponType = statName.ShaveRight("-skill");
                    result.WeaponSkill.Add(weaponType.ToWeaponType(), int.Parse(((YamlScalarNode)statItem.Value).Value));

                    continue;
                }

                if (statName == "threat")
                {
                    result.ThreatDecrease = (0.0 - double.Parse(((YamlScalarNode)statItem.Value).Value)) / 100.0;
                    continue;
                }

                if (statName == "sockets")
                {
                    var socketsNode = (YamlMappingNode)statItem.Value;

                    foreach (var socketItem in socketsNode.Children)
                    {
                        var socketName = ((YamlScalarNode)socketItem.Key).Value;

                        if (socketName == "bonus")
                        {
                            var bonusNode = (YamlMappingNode)socketItem.Value;
                            result.SocketBonus = LoadGearItem(bonusNode, GearType.SocketBonus);
                            continue;
                        }

                        var socketColor = socketName.ToSocketColor();
                        var socketCount = int.Parse(((YamlScalarNode)socketItem.Value).Value);

                        for (var i = 0; i < socketCount; i++)
                        {
                            result.Sockets.Add(new Socket() { Color = socketColor });
                        }
                    }

                    continue;
                }

                var prop = result.GetType().GetProperties().Single(p => p.GetCustomAttributes<YamlProperty>().Any(a => a.PropertyName == statName));
                
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(result, ((YamlScalarNode)statItem.Value).Value);
                }

                if (prop.PropertyType == typeof(double))
                {
                    prop.SetValue(result, double.Parse(((YamlScalarNode)statItem.Value).Value));
                }

                if (prop.PropertyType == typeof(int))
                {
                    prop.SetValue(result, int.Parse(((YamlScalarNode)statItem.Value).Value));
                }

                if (prop.PropertyType == typeof(WeaponType))
                {
                    var typeValue = ((YamlScalarNode)statItem.Value).Value;
                    prop.SetValue(result, typeValue.ToWeaponType());
                }

                // TODO: in schema specify allowed values for type, source, phase, color, etc
            }

            return result;
        }
    }
}
