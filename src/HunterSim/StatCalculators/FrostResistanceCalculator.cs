using System.Linq;

namespace HunterSim
{
    public static class FrostResistanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.FrostResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.FrostResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
