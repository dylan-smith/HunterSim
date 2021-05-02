using System.Linq;

namespace HunterSim
{
    public static class CritChanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var critChance = 0.05;
            critChance += state.Config.Gear.GetAllGear().Sum(x => x.Crit);
            critChance += state.Config.Gear.GetAllEnchants().Sum(x => x.Crit);
            critChance += AgilityCalculator.Calculate(state) / 5300; // 53 Agi = 0.01 crit

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

            if (state.Config.Talents.ContainsKey(Talent.KillerInstinct))
            {
                critChance += state.Config.Talents[Talent.KillerInstinct] * 0.01;
            }

            return critChance;
        }
    }
}
