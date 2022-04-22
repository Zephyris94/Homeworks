using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    internal class Spell
    {
        private const int MaxSpellPower = 1000;
        public static int SpellID { get; private set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MagicSchool Type { get; set; } = MagicSchool.None;
        public SpellDifficulty Difficulty { get; set; } = SpellDifficulty.Basic;
        public int ManaCost { get; set; } = 1;
        public int Cooldown { get; set; } = 1;
        public int Duration { get; set; } = 1;
        public int Range { get; set; } = 1;
        public int Power { get; set; } = 1;

        public Spell()
        {
            SpellID++;
        }


        public string SpellInfo()
        {
            return $"Spell name {Name}.\nSpell description {Description}.\nSpell power {Power}";
        }
    }
}
