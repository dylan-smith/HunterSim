using System.Linq;

namespace HunterSim
{
    public static class FireResistanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.FireResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.FireResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
