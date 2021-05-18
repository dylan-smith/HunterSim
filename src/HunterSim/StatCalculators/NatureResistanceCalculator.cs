using System.Linq;

namespace HunterSim
{
    public class NatureResistanceCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<NatureResistanceCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.NatureResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.NatureResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 20;
            }

            return resist;
        }
    }
}
