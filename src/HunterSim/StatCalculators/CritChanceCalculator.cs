using System.Linq;

namespace HunterSim
{
    public static class CritChanceCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var critChance = 0.05;
            critChance += state.Config.Gear.GetAllGear().Sum(x => x.Crit);
            critChance += state.Config.Gear.GetAllGear().Sum(x => x.Agility / 5300); // 53 Agi = 1% crit
            critChance += state.Config.PlayerSettings.Agility / 5300;

            return critChance;
        }
    }
}
