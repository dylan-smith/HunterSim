using System.Linq;

namespace HunterSim
{
    public static class BonusDamageCalculator
    {
        public static double Calculate(GearItem weapon, SimulationState state)
        {
            // TODO: Sniper Scope bonus dmg only applies to damage from the ranged weapon
            var bonusDamage = state.Config.Gear.GetAllGear().Sum(x => x.BonusDamage);
            bonusDamage += state.Config.Gear.GetAllGear().Sum(x => x.BonusDPS) * weapon.Speed;

            bonusDamage += state.Config.Gear.GetAllEnchants().Sum(x => x.BonusDamage);
            bonusDamage += state.Config.Gear.GetAllEnchants().Sum(x => x.BonusDPS) * weapon.Speed;

            return bonusDamage;
        }
    }
}
