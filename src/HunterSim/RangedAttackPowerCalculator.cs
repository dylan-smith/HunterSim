using System.Linq;

namespace HunterSim
{
    public static class RangedAttackPowerCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var rangedAP = state.Config.Gear.GetAllGear().Sum(x => x.AttackPower + (x.Agility * 2));
            
            return rangedAP;
        }
    }
}
