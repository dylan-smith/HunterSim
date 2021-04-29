namespace HunterSim
{
    public class BossSettings
    {
        public int Level { get; set; }
        public BossType BossType { get; set; }

        public int Defense
        {
            get
            {
                return Level * 5;
            }
        }
    }
}