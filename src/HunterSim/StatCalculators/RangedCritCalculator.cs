using System.Linq;

namespace HunterSim
{
    public static class RangedCritCalculator
    {
        public static double Calculate(SimulationState state)
        {
            
            var critChance = 0.05;
            critChance += state.Config.Gear.GetAllGear().Sum(x => x.Crit);
            critChance += state.Config.Gear.GetAllEnchants().Sum(x => x.Crit);
            critChance += AgilityCalculator.Calculate(state) / 5300; // 53 Agi = 0.01 crit

            // Apparantly the 5% base crit is due to the base agi, we need to subtract it out so we don't double-count it
            // https://vanilla-wow-archive.fandom.com/wiki/Critical_strike
            critChance -= state.Config.PlayerSettings.Agility / 5300;

            if (state.Config.Buffs.Contains(Buff.RallyingCryOfTheDragonSlayer))
            {
                critChance += 0.05;
            }

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                critChance += 0.05;
            }

            if (state.Config.Buffs.Contains(Buff.LeaderOfThePack))
            {
                critChance += 0.03;
            }

            if (state.Config.Buffs.Contains(Buff.ElixirOfTheMongoose))
            {
                critChance += 0.02;
            }

            if (state.Config.Buffs.Contains(Buff.FireFestivalFury))
            {
                critChance += 0.03;
            }

            if (state.Config.Talents.ContainsKey(Talent.KillerInstinct))
            {
                critChance += state.Config.Talents[Talent.KillerInstinct] * 0.01;
            }

            return critChance;
        }
    }
}
