using System.Linq;

namespace HunterSim
{
    public class AgilityCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<AgilityCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var agility = state.Config.PlayerSettings.Agility;
            agility += state.Config.Gear.GetAllGear().Sum(x => x.Agility);
            agility += state.Config.Gear.GetAllEnchants().Sum(x => x.Agility);

            if (state.Config.Buffs.Contains(Buff.SongflowerSerenade))
            {
                agility += 15;
            }

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                agility += 12;
            }

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                agility *= 1.15;
            }

            if (state.Config.Buffs.Contains(Buff.BlessingOfKings))
            {
                agility *= 1.1;
            }

            if (state.Config.Buffs.Contains(Buff.GraceOfAirTotem))
            {
                agility += 77;
            }

            if (state.Config.Buffs.Contains(Buff.GroundScorpokAssay))
            {
                agility += 25;
            }

            // Mongoose and Agi elixirs don't stack
            if (state.Config.Buffs.Contains(Buff.ElixirOfTheMongoose) || state.Config.Buffs.Contains(Buff.ElixirOfGreaterAgility))
            {
                agility += 25;
            }

            if (state.Config.Buffs.Contains(Buff.GrilledSquid))
            {
                agility += 10;
            }

            if (state.Config.Talents.ContainsKey(Talent.LightningReflexes))
            {
                agility *= 1 + (state.Config.Talents[Talent.LightningReflexes] * 0.03);
            }

            return agility;
        }
    }
}
