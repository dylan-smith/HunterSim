namespace HunterSim
{
    public static class SpellCritCalculator
    {
        public static double Calculate(SimulationState state)
        {
            // Hunters don't use spell crit, even abilities considered spells like Arcane Shot use ranged crit
            // https://classic.wowhead.com/guide=10453/classic-spell-power-hunter-the-little-arcane-shot-that-could
            var spellCrit = 0.0;

            if (state.Config.Buffs.Contains(Buff.RallyingCryOfTheDragonSlayer))
            {
                spellCrit += 0.1;
            }

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                spellCrit += 0.05;
            }

            if (state.Config.Buffs.Contains(Buff.SlipkiksSavvy))
            {
                spellCrit += 0.03;
            }

            return spellCrit;
        }
    }
}
