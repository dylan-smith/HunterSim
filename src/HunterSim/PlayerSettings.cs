using System;
using System.Collections.Generic;

namespace HunterSim
{
    public class PlayerSettings
    {
        public IDictionary<WeaponType, int> WeaponSkill = new Dictionary<WeaponType, int>();

        public PlayerSettings()
        {
            var weaponTypes = (WeaponType[])Enum.GetValues(typeof(WeaponType));
            
            foreach (var weaponType in weaponTypes)
            {
                WeaponSkill.Add(weaponType, 300);
            }
        }
    }
}