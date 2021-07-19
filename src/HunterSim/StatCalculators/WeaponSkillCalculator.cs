namespace HunterSim
{
    public class WeaponSkillCalculator : BaseStatCalculator
    {
        public static double Calculate(GearItem weapon, SimulationState state)
        {
            return Calculate<WeaponSkillCalculator>(weapon, state);
        }

        protected override double InstanceCalculate(GearItem weapon, SimulationState state)
        {
            // TODO: Is weapon skill completely gone in TBC?
            var skill = state.Config.PlayerSettings.Level * 5;
            var weaponType = weapon.WeaponType;

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
