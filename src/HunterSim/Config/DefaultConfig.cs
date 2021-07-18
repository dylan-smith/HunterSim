namespace HunterSim
{
    public class DefaultConfig: SimulationConfig
    {
        public DefaultConfig()
        {
            SimulationSettings.FightLength = 60.0;

            Gear.Head = GearItemFactory.LoadHead("Beast Lord Helm");
            Gear.Head.Enchant = GearItemFactory.LoadHeadEnchant("Falcon's Call");
            Gear.Neck = GearItemFactory.LoadNeck("Jagged Bark Pendant");
            Gear.Shoulder = GearItemFactory.LoadShoulder("Beast Lord Mantle");
            Gear.Shoulder.Enchant = GearItemFactory.LoadShoulderEnchant("Might of the Scourge");
            Gear.Back = GearItemFactory.LoadBack("Blood Knight War Cloak");
            Gear.Back.Enchant = GearItemFactory.LoadBackEnchant("Lesser Agility");
            Gear.Chest = GearItemFactory.LoadChest("Beast Lord Cuirass");
            Gear.Chest.Enchant = GearItemFactory.LoadChestEnchant("Greater Stats");
            Gear.Wrist = GearItemFactory.LoadWrist("Felstalker Bracers");
            Gear.Wrist.Enchant = GearItemFactory.LoadWristEnchant("Minor Agility");
            Gear.MainHand = GearItemFactory.LoadMainHand("Big Bad Wolf's Paw");
            Gear.MainHand.Enchant = GearItemFactory.LoadOneHandEnchant("Agility");
            Gear.OffHand = GearItemFactory.LoadOffHand("Stellaris");
            Gear.OffHand.Enchant = GearItemFactory.LoadOneHandEnchant("Agility");
            Gear.Hands = GearItemFactory.LoadHands("Beast Lord Handguards");
            Gear.Hands.Enchant = GearItemFactory.LoadHandEnchant("Superior Agility");
            Gear.Waist = GearItemFactory.LoadWaist("Girdle of the Prowler");
            Gear.Legs = GearItemFactory.LoadLegs("Skulker's Greaves");
            Gear.Legs.Enchant = GearItemFactory.LoadLegEnchant("Falcon's Call");
            Gear.Feet = GearItemFactory.LoadFeet("The Master's Treads");
            Gear.Feet.Enchant = GearItemFactory.LoadFeetEnchant("Greater Agility");
            Gear.Finger1 = GearItemFactory.LoadFinger("Ring of the Recalcitrant");
            Gear.Finger2 = GearItemFactory.LoadFinger("Garona's Signet Ring");
            Gear.Trinket1 = GearItemFactory.LoadTrinket("Bloodlust Brooch");
            Gear.Trinket2 = GearItemFactory.LoadTrinket("Abacus of Violent Odds");
            Gear.Ranged = GearItemFactory.LoadRanged("Wrathtide Longbow");
            Gear.Ranged.Enchant = GearItemFactory.LoadRangedEnchant("Sniper Scope");
            Gear.Ammo = GearItemFactory.LoadAmmo("Warden's Arrow");
            Gear.Quiver = GearItemFactory.LoadQuiver("Worg Hide Quiver");

            BossSettings.Level = 73;
            BossSettings.BossType = BossType.Demon;

            PlayerSettings.Race = Race.NightElf;
            PlayerSettings.Level = 70;

            // Marksmanship (20)
            Talents.Add(Talent.LethalShots, 5);
            Talents.Add(Talent.ImprovedHuntersMark, 5);
            Talents.Add(Talent.GoForTheThroat, 2);
            Talents.Add(Talent.AimedShot, 1);
            Talents.Add(Talent.RapidKilling, 2);
            Talents.Add(Talent.MortalShots, 5);

            // Survival (41)
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
            Talents.Add(Talent.Readiness, 1);
        }
    }
}
