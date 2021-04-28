﻿namespace HunterSim
{
    public class DefaultConfig: SimulationConfig
    {
        public DefaultConfig()
        {
            base.SimulationSettings.FightLength = 60.0;

            base.Gear.Ranged = new GearItem();
            base.Gear.Ranged.MaxDamage = 93.3;
            base.Gear.Ranged.Speed = 2.8;
            base.Gear.Ranged.WeaponType = WeaponType.Gun;

            base.PlayerSettings.Race = Race.NightElf;

            base.BossSettings.Level = 63;
            base.PlayerSettings.Level = 60;
        }
    }
}
