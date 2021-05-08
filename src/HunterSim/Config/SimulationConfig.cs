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

            //if (!ValidateTooManyTalentPoints())
            //{
            //    warnings.Add(SimulationWarnings.TooManyTalentPoints);
            //}

            if (!ValidateNotEnoughTalentPoints())
            {
                warnings.Add(SimulationWarnings.MissingTalentPoints);
            }

            return (warnings, errors);
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

            if (Buffs.Contains(Buff.SmokedDesertDumplings))
            {
                foodBuffCount++;
            }

            if (Buffs.Contains(Buff.BlessedSunfruit))
            {
                foodBuffCount++;
            }

            if (Buffs.Contains(Buff.GrilledSquid))
            {
                foodBuffCount++;
            }

            // TODO: What else counts as a food buff? Does Dragonbreath Chili? Fire Toasted Bun?

            return foodBuffCount <= 1;
        }
    }
}
