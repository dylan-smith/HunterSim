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

            BossSettings.Level = 63;
            BossSettings.BossType = BossType.Humanoid;

            PlayerSettings.Race = Race.NightElf;
            PlayerSettings.Level = 60;

            // TODO: Buffs
            // TODO: Consumes

            // Survival Talents
            Talents.Add(Talent.MonsterSlaying, 3);
            Talents.Add(Talent.HumanoidSlaying, 3);
            Talents.Add(Talent.HawkEye, 3);
            Talents.Add(Talent.SavageStrikes, 2);
            Talents.Add(Talent.CleverTraps, 2);
            Talents.Add(Talent.Survivalist, 2);
            Talents.Add(Talent.Surefooted, 3);
            Talents.Add(Talent.ImprovedFeignDeath, 2);
            Talents.Add(Talent.SurvivalInstincts, 2);
            Talents.Add(Talent.KillerInstinct, 3);
            Talents.Add(Talent.LightningReflexes, 5);
            Talents.Add(Talent.ThrillOfTheHunt, 2);
            Talents.Add(Talent.ExposeWeakness, 3);
            Talents.Add(Talent.MasterTactician, 5);
            // Marksmanship Talents
            Talents.Add(Talent.LethalShots, 5);
            Talents.Add(Talent.ImprovedHuntersMark, 5);
            Talents.Add(Talent.GoForTheThroat, 2);
            Talents.Add(Talent.AimedShot, 1);
            Talents.Add(Talent.RapidKilling, 2);
            Talents.Add(Talent.MortalShots, 5);
            Talents.Add(Talent.Barrage, 1);
        }
    }
}
