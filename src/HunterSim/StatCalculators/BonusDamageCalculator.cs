using System.Linq;

namespace HunterSim
{
    public static class BonusDamageCalculator
    {
        public static double Calculate(GearItem weapon, SimulationState state)
        {
            var bonusDamage = state.Config.Gear.GetAllGear().Sum(x => x.BonusDamage);
            bonusDamage += state.Config.Gear.GetAllGear().Sum(x => x.BonusDPS) * weapon.Speed;

            return bonusDamage;
        }
    }
}
