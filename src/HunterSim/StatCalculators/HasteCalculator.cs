using System.Linq;

namespace HunterSim
{
    public static class HasteCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var haste = state.Config.Gear.GetAllGear().Sum(x => x.Haste);
            haste += state.Config.Gear.GetAllEnchants().Sum(x => x.Haste);
            
            if (state.Config.Buffs.Contains(Buff.WarchiefsBlessing))
            {
                haste += 0.15;
            }

            return haste;
        }
    }
}
