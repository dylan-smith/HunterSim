using System.Linq;

namespace HunterSim
{
    public class ArmorCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<ArmorCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var armor = state.Config.Gear.GetAllGear().Sum(x => x.Armor);
            armor += state.Config.Gear.GetAllEnchants().Sum(x => x.Armor);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                armor += 285;
            }

            return armor;
        }
    }
}
