using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zadanie.Models
{
    /// <summary>
    /// Klasa z danymi postaci.
    /// </summary>
    public class CharacterViewModel
    {
        public string CharacterClass { get; set; }
        public string CharacterRawClass { get; set; }
        public decimal Knowledge { get; set; }
        public decimal LifeEnergy { get; set; }
        public string SkinType { get; set; }
        public string Photo { get; set; }

        public CharacterViewModel(string characterClass, string characterRawClass, decimal knowledge, decimal lifeEnergy, string skinType, string photo)
        {
            CharacterClass = characterClass;
            CharacterRawClass = characterRawClass;
            Knowledge = knowledge;
            LifeEnergy = lifeEnergy;
            SkinType = skinType;
            Photo = photo;
        }
    }
}
