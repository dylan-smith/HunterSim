namespace HunterSim
{
    public class DefaultConfig: SimulationConfig
    {
        public DefaultConfig()
        {
            SimulationSettings.FightLength = 60.0;

            Gear.Head = GearItemFactory.LoadHead("Cryptstalker Headpiece");
            Gear.Neck = GearItemFactory.LoadNeck("Prestor's Talisman of Connivery");
            Gear.Shoulder = GearItemFactory.LoadShoulder("Cryptstalker Spaulders");
            Gear.Back = GearItemFactory.LoadBack("Cloak of the Fallen God");
            Gear.Chest = GearItemFactory.LoadChest("Cryptstalker Tunic");
            Gear.Wrist = GearItemFactory.LoadWrist("Cryptstalker Wristguards");
            Gear.MainHand = GearItemFactory.LoadMainHand("Hatchet of Sundered Bone");
            Gear.OffHand = GearItemFactory.LoadOffHand("Kingsfall");
            Gear.Hands = GearItemFactory.LoadHands("General's Chain Gloves");
            Gear.Waist = GearItemFactory.LoadWaist("Cryptstalker Girdle");
            Gear.Legs = GearItemFactory.LoadLegs("Cryptstalker Legguards");
            Gear.Feet = GearItemFactory.LoadFeet("Cryptstalker Boots");
            Gear.Finger1 = GearItemFactory.LoadFinger("Ring of the Cryptstalker");
            Gear.Finger2 = GearItemFactory.LoadFinger("Band of Reanimation");
            Gear.Trinket1 = GearItemFactory.LoadTrinket("Slayer's Crest");
            Gear.Trinket2 = GearItemFactory.LoadTrinket("Drake Fang Talisman");
            Gear.Ranged = GearItemFactory.LoadRanged("Nerubian Slavemaker");
            Gear.Ammo = GearItemFactory.LoadAmmo("Thorium Headed Arrow");
            Gear.Quiver = GearItemFactory.LoadQuiver("Ancient Sinew Wrapped Lamina");

            PlayerSettings.Race = Race.NightElf;

            BossSettings.Level = 63;
            PlayerSettings.Level = 60;

            // TODO: Buffs
            // TODO: Talents
        }
    }
}
