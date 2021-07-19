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
            var armor = state.Config.Gear.GetStatTotal(x => x.Armor);

            armor += AgilityCalculator.Calculate(state) * 2;

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                armor += 340;
            }

            return armor;
        }
    }
}
