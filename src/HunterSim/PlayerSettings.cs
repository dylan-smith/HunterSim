using System;
using System.Collections.Generic;

namespace HunterSim
{
    public class PlayerSettings
    {
        public IDictionary<WeaponTypes, int> WeaponSkill = new Dictionary<WeaponTypes, int>();

        public PlayerSettings()
        {
            var weaponTypes = (WeaponTypes[])Enum.GetValues(typeof(WeaponTypes));
            
            foreach (var weaponType in weaponTypes)
            {
                WeaponSkill.Add(weaponType, 300);
            }
        }
    }
}