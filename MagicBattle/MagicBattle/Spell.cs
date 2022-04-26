using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class Spell
    {
        public Spell(string spellName, SpellType spellType, SpellDifficulty spellDifficulty,
            string SpellEffect)
        {
            Name = spellName;
            Type = spellType;
            Difficulty = spellDifficulty;
            Effect = SpellEffect;
        }

        SpellType Type = SpellType.Unknown;
        public enum     SpellType       
        {
            Unknown,
            Quas,
            Wex,
            Exort
        }

        SpellDifficulty Difficulty = SpellDifficulty.Unknown;
        public enum   SpellDifficulty 
        {
            Unknown = 0,
            Easy = 1,
            Normal = 2,
            Hard = 3
        }

        public int Damage => (int)Difficulty * 10;
        public string Name { get; set; } = "Unknown Spell";
        public string Effect { get; set; } = "Some effect";

        public override string ToString()
        {
            return $"{Name}, Damage: {Damage}, Type: {Type}, Difficulty: {Difficulty}, Effect: {Effect}";
        }

    }
}
