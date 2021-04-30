using System.Collections.Generic;

namespace HunterSim
{
    public class SimulationConfig
    {
        public readonly Gear Gear = new Gear();
        public readonly ISet<Buff> Buffs = new HashSet<Buff>();
        public readonly PlayerSettings PlayerSettings = new PlayerSettings();
        public readonly BossSettings BossSettings = new BossSettings();
        public readonly SimulationSettings SimulationSettings = new SimulationSettings();
        public readonly IDictionary<Talent, int> Talents = new Dictionary<Talent, int>();
    }
}
