using System.Collections.Generic;
using System;
namespace MagicBattle
{
    public class Magician : Human
    {
        private List<Spell> _spells = new List<Spell>();
        public int BasePower => Intelligence * 2;
        private int _experience = 0;

        private const int RequiredLevelModifier = 100;

        public int Level { get; private set; } = 1;

        public Rarity Rarity { get; private set; }

        public int Power => (int)Rarity * 2 + Level * 10 + _spells.Count * 10 + BasePower * 3;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public int RemainingExp => RequiredExp - _experience;

        public Magician()
            : base(25, "John")
        {
            Level = 1;
            Rarity = Rarity.Common;
        }

        public Magician(int age, int level, string name, Rarity rarity)
            : base(age, name)
        {
            Level = level;
            Rarity = rarity;
        }

        public void LearnSpell()
        {
            _spells.Add(new Spell("Blast", Spell.SpellType.Exort, Spell.SpellDifficulty.Normal, "FIRE"));
            _spells.Add(new Spell("Icefall", Spell.SpellType.Quas, Spell.SpellDifficulty.Hard, "ICE"));

            foreach (Spell part in _spells)
            {
                Console.WriteLine(part.ToString());
            }
        }

        public void GainExperience(int experience)
        {
            _experience += experience;

            if (_experience >= RemainingExp)
            {
                Level++;
                Intelligence++;
                _experience = _experience - RemainingExp;
            }
        }

        public override string ToString()
        {
            var baseData = base.ToString();
            return $"{baseData}. {Rarity} Magician {Level} lvl. has {Power} power score with {_spells.Count} spells";
        }

        public static Magician operator +(Magician m1, Magician m2)
        {
            Magician newMagician = new Magician(m1.Age + m2.Age, m1.Level + m2.Level, "ULTRAXXX", Rarity.Legendary);
            return newMagician;
        }
    }
}
