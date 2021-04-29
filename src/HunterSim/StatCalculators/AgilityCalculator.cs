using System.Linq;

namespace HunterSim
{
    public static class AgilityCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var agility = state.Config.PlayerSettings.Agility;
            agility += state.Config.Gear.GetAllGear().Sum(x => x.Agility);
            
            if (state.Config.Talents.ContainsKey(Talent.LightningReflexes))
            {
                agility *= 1 + (state.Config.Talents[Talent.LightningReflexes] * 0.03);
            }

            return agility;
        }
    }
}
