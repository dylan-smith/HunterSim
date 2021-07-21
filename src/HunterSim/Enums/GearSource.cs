using System;

namespace HunterSim
{
    public enum GearSource
    {
        Dungeon,
        Gruul,
        Magtheridon,
        Karazhan,
        Badges,
        Crafted,
        Reputation,
        AuctionHouse,
        Vendor,
        Heroic
    }

    public static class GearSourceExtensions
    {
        public static GearSource ToGearSource(this string value)
        {
            return value switch
            {
                "dungeon" => GearSource.Dungeon,
                "gruul" => GearSource.Gruul,
                "magtheridon" => GearSource.Magtheridon,
                "karazhan" => GearSource.Karazhan,
                "badges" => GearSource.Badges,
                "crafted" => GearSource.Crafted,
                "rep" => GearSource.Reputation,
                "ah" => GearSource.AuctionHouse,
                "vendor" => GearSource.Vendor,
                "heroic" => GearSource.Heroic,
                _ => throw new ArgumentException($"Unrecognized gear source {value}"),
            };
        }
    }
}
