namespace HunterSim
{
    public static class MP5Calculator
    {
        public static double Calculate(SimulationState state)
        {
            var mp5 = 0.0;

            if (state.Config.Buffs.Contains(Buff.WarchiefsBlessing))
            {
                mp5 += 10;
            }

            return mp5;
        }
    }
}
