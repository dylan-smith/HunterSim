namespace HunterSim
{
    public class ImprovedAspectOfTheHawk
    {
        public static void ProcessEvent(AutoShotCompletedEvent e, SimulationState state)
        {
            if (state.Config.Talents.ContainsKey(Talent.ImprovedAspectOfTheHawk))
            {
                var procChance = 0.1;

                var roll = RandomGenerator.Roll(RollType.ImprovedAspectOfTheHawkProc);

                if (roll <= procChance)
                {
                    state.Events.Add(new ImprovedAspectOfTheHawkProc(e.Timestamp));
                }
            }
        }
    }
}
