using System;

namespace HunterSim
{
    public class PlayerSettings
    {
        public Race Race { get; set; }
        public int Level { get; set; }

        // TODO: Calc stat values modified by level (can't find a good source of info)

        public double Strength
        {
            get
            {
                switch (Race)
                {
                    case Race.Dwarf:
                        return 57.0;
                    case Race.NightElf:
                        return 52.0;
                    case Race.Orc:
                        return 58.0;
                    case Race.Tauren:
                        return 60.0;
                    case Race.Troll:
                        return 56.0;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Race not set");
                }
            }
        }

        public double Agility
        {
            get
            {
                switch (Race)
                {
                    case Race.Dwarf:
                        return 121.0;
                    case Race.NightElf:
                        return 130.0;
                    case Race.Orc:
                        return 122.0;
                    case Race.Tauren:
                        return 120.0;
                    case Race.Troll:
                        return 127.0;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Race not set");
                }
            }
        }

        public double Stamina
        {
            get
            {
                switch (Race)
                {
                    case Race.Dwarf:
                        return 93.0;
                    case Race.NightElf:
                        return 89.0;
                    case Race.Orc:
                        return 92.0;
                    case Race.Tauren:
                        return 92.0;
                    case Race.Troll:
                        return 91.0;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Race not set");
                }
            }
        }

        public double Intellect
        {
            get
            {
                switch (Race)
                {
                    case Race.Dwarf:
                        return 64.0;
                    case Race.NightElf:
                        return 65.0;
                    case Race.Orc:
                        return 62.0;
                    case Race.Tauren:
                        return 60.0;
                    case Race.Troll:
                        return 61.0;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Race not set");
                }
            }
        }

        public double Spirit
        {
            get
            {
                switch (Race)
                {
                    case Race.Dwarf:
                        return 69.0;
                    case Race.NightElf:
                        return 70.0;
                    case Race.Orc:
                        return 73.0;
                    case Race.Tauren:
                        return 72.0;
                    case Race.Troll:
                        return 71.0;
                    default:
                        // TODO: Richer exceptions
                        throw new Exception("Race not set");
                }
            }
        }

        public double Health
        {
            get
            {
                return 1467.0;
            }
        }

        public double Mana
        {
            get
            {
                return 1720.0;
            }
        }
    }
}