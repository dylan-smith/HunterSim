using System.Linq;

namespace HunterSim
{
    public static class ArcaneResistanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.ArcaneResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.ArcaneResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
