using System.Linq;

namespace HunterSim
{
    public class ShadowResistanceCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<ShadowResistanceCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetStatTotal(x => x.ShadowResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 25;
            }

            return resist;
        }
    }
}
