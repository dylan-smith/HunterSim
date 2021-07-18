using System.Linq;

namespace HunterSim
{
    public class FrostResistanceCalculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<FrostResistanceCalculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var resist = state.Config.Gear.GetAllGear().Sum(x => x.FrostResistance);
            resist += state.Config.Gear.GetAllEnchants().Sum(x => x.FrostResistance);

            if (state.Config.Buffs.Contains(Buff.MarkOfTheWild))
            {
                resist += 25;
            }

            return resist;
        }
    }
}
