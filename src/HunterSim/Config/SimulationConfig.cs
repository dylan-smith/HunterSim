using System.Collections.Generic;
using System.Linq;

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

        public (IEnumerable<string> Warnings, IEnumerable<string> Errors) Validate()
        {
            var warnings = new List<string>();
            var errors = new List<string>();

            if (!ValidateFoodBuffs())
            {
                warnings.Add(SimulationWarnings.TooManyFoodBuffs);
            }

            if (!ValidateRace())
            {
                errors.Add(SimulationErrors.NoRaceSelected);
            }

            if (!ValidateTooManyTalentPoints())
            {
                warnings.Add(SimulationWarnings.TooManyTalentPoints);
            }

            if (!ValidateNotEnoughTalentPoints())
            {
                warnings.Add(SimulationWarnings.MissingTalentPoints);
            }

            if (!ValidateAllGearSelected())
            {
                warnings.Add(SimulationWarnings.MissingGear);
            }

            if (!ValidatePlayerMaxLevel())
            {
                warnings.Add(SimulationWarnings.PlayerNotMaxLevel);
            }

            if (!ValidateMissingRangedWeapon())
            {
                errors.Add(SimulationErrors.MissingRangedWeapon);
            }

            return (warnings, errors);
        }

        private bool ValidateMissingRangedWeapon()
        {
            return Gear.Ranged != null;
        }

        private bool ValidatePlayerMaxLevel()
        {
            return PlayerSettings.Level == 70;
        }

        private bool ValidateAllGearSelected()
        {
            return Gear.GetAllGear().Count() == 19;
        }

        private bool ValidateTooManyTalentPoints()
        {
            var points = PlayerSettings.Level - 9;

            return Talents.Values.Sum() <= points;
        }

        private bool ValidateNotEnoughTalentPoints()
        {
            var points = PlayerSettings.Level - 9;

            return Talents.Values.Sum() >= points;
        }

        private bool ValidateRace()
        {
            return PlayerSettings.Race != Race.NotSet;
        }

        private bool ValidateFoodBuffs()
        {
            var foodBuffCount = 0;

            // TODO: Add various food buffs

            return foodBuffCount <= 1;
        }
    }
}
