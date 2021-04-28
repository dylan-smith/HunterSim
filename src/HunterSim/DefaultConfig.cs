namespace HunterSim
{
    public class DefaultConfig: SimulationConfig
    {
        public DefaultConfig()
        {
            base.SimulationSettings = new SimulationSettings();
            base.SimulationSettings.FightLength = 60.0;
        }
    }
}
