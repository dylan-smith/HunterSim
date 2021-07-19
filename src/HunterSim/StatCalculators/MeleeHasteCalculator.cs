using System.Linq;

namespace HunterSim
{
    public class MeleeHasteCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<MeleeHasteCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var haste = state.Config.Gear.GetStatTotal(x => x.HasteRating);
            
            return haste;
        }
    }
}
