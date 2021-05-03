namespace HunterSim
{
    public static class MovementSpeedCalculator
    {
        public static double Calculate(SimulationState state)
        {
            var movementSpeed = 1.0;

            if (state.Config.Buffs.Contains(Buff.SpiritOfZandalar))
            {
                movementSpeed *= 1.10;
            }

            return movementSpeed;
        }
    }
}
