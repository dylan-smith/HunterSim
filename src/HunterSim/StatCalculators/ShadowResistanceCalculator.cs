using System.Linq;

namespace HunterSim
{
    public static class ShadowResistanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.ShadowResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.ShadowResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
