namespace HunterSim
{
    public static class SimulationWarnings
    {
        public const string TooManyFoodBuffs = "You can only have one food buff active at a time";
        public const string TooManyTalentPoints = "You have more than the max talent points for your level";
        public const string MissingTalentPoints = "You have not used all the talent points available for your level";
        public const string MissingGear = "One or more gear slots have no item selected";
        public const string PlayerNotMaxLevel = "The player level is below max level, this simulator likely will not produce correct results";
        public const string BattleShoutAndEnhancedBattleShoutDoNotStack = "Battle Shout and Enhanced Battle Shout do not stack, you should pick one or the other";
        // TODO: Check only battle/guardian elixir or flask active
        // TODO: Can't have Battle Shout and Improved Battle Shout at same time
        // TODO: You ran out of mana during the fight
    }
}
