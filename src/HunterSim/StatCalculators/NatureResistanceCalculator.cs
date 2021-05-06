using System.Linq;

namespace HunterSim
{
    public static class NatureResistanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.NatureResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.NatureResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
