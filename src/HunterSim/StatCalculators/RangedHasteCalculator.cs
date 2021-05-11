using System.Linq;

namespace HunterSim
{
    public static class RangedHasteCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var haste = state.Config.Gear.GetAllGear().Sum(x => x.Haste);
            haste += state.Config.Gear.GetAllEnchants().Sum(x => x.Haste);
            
            if (state.Config.Buffs.Contains(Buff.WarchiefsBlessing))
            {
                haste += 0.15;
            }

            if (state.Auras.Contains(Aura.ImprovedAspectOfTheHawk))
            {
                haste += 0.30;
            }

            return haste;
        }
    }
}
