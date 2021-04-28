using System.Collections.Generic;

namespace HunterSim
{
    public class SimulationConfig
    {
        public IEnumerable<GearItem> Gear { get; set; }
        public IEnumerable<Buff> Buffs { get; set; }
        public PlayerSettings PlayerSettings { get; set; }
        public BossSettings BossSettings { get; set; }
        public SimulationSettings SimulationSettings { get; set; }
        public IEnumerable<Talent> Talents { get; set; }
    }
}
