using System.Linq;

namespace HunterSim
{
    public class FireResistanceCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<FireResistanceCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetStatTotal(x => x.FireResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 25;
            }

            return resist;
        }
    }
}
