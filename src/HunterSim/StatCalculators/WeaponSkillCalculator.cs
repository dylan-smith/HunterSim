﻿namespace HunterSim
{
    public static class WeaponSkillCalculator
    {
        public static int Calculate(WeaponType weaponType, SimulationState state)
        {
            var skill = 300;

            foreach (var gear in state.Config.Gear.GetAllGear())
            {
                if (gear.WeaponSkill.ContainsKey(weaponType))
                {
                    skill += gear.WeaponSkill[weaponType];
                }
            }
            
            // This is probably useless code, no enchants give weapon skill AFAIK
            foreach (var enchant in state.Config.Gear.GetAllEnchants())
            {
                if (enchant.WeaponSkill.ContainsKey(weaponType))
                {
                    skill += enchant.WeaponSkill[weaponType];
                }
            }

            if (weaponType == WeaponType.Gun && state.Config.PlayerSettings.Race == Race.Dwarf)
            {
                skill += 5;
            }

            if ((weaponType == WeaponType.OneHandedAxe || weaponType == WeaponType.TwoHandedAxe) && state.Config.PlayerSettings.Race == Race.Orc)
            {
                skill += 5;
            }

            if ((weaponType == WeaponType.Bow || weaponType == WeaponType.Thrown) && state.Config.PlayerSettings.Race == Race.Troll)
            {
                skill += 5;
            }

            return skill;
        }
    }
}
