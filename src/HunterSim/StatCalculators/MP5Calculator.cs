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

            if (state.Config.Buffs.Contains(Buff.EssenceOfTheRed))
            {
                mp5 += 2500;
            }

            return mp5;
        }
    }
}
