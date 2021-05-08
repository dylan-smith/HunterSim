namespace HunterSim
{
    static class SimulationWarnings
    {
        public const string TooManyFoodBuffs = "You can only have one food buff active at a time";
        public const string TooManyTalentPoints = "You have more than the max talent points for your level";
        public const string MissingTalentPoints = "You have not used all the talent points available for your level";
        public const string MissingGear = "One or more gear slots have no item selected";
        public const string PlayerNotMaxLevel = "The player level is below max level, this simulator likely will not produce correct results";
        public const string TooManyBlastedLandsBuffs = "You can only have one blasted lands buff active at a time";
        public const string BlastedLandsAndZanzaPotDoNotStack = "Blasted Lands buffs and Zanza Potions do not stack, you can only use one at a time";
        public const string MongooseAndAgilityElixirsDoNotStack = "Elixir of the Mongoose and Elixir of Agility do not stack, only Mongoose will count";
        public const string JujuMightAndWinterfallFirewaterDoNotStack = "Juju Might and Winterfall Firewater do not stack, only Juju Might will count";
        public const string JujuPowerAndElixirOfGiantsDoNotStack = "Juju Power and Elixir of Giants do not stack, only Juju Power will count";
        public const string BattleShoutAndEnhancedBattleShoutDoNotStack = "Battle Shout and Enhanced Battle Shout do not stack, you should pick one or the other";
    }
}
