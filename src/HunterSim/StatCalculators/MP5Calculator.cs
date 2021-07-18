namespace HunterSim
{
    public class MP5Calculator : BaseStatCalculator
    {
        public static double Calculate(SimulationState state)
        {
            return Calculate<MP5Calculator>(state);
        }

        protected override double InstanceCalculate(SimulationState state)
        {
            var mp5 = 0.0;

            // TODO: Does spirit affect this?

            return mp5;
        }
    }
}
