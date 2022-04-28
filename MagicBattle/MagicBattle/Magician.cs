using System.Collections.Generic;
using MagicBattle.Spells;

namespace MagicBattle
{
    public class Magician : Human
    {
        private List<Spell> _spells = new List<Spell>();
        private int _basePower = 0;
        private int _experience = 0;

        private const int RequiredLevelModifier = 1000;

        public Magician()
            : base()
        {
        }

        public Magician(int age, int level, string name, Rarity rarity)
            : base(age, name)
        {
            Level = level;
            Rarity = rarity;
        }


        public int Level { get; private set; }

        public Rarity Rarity { get; private set; }

        public int Power => (int) Rarity * 2 + Level * 10 + _spells.Count * 10 + _basePower*3;

        public int RemainingExp => RequiredExp - _experience;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public void LearnSpell(Spell spell)
        {
            _spells.Add(spell);
        }

        public void RenameCharacter(string newName)
        {
            Name = newName;
        }

        public void GainExperience(int experience)
        {
            _experience += experience;

            if (_experience > RemainingExp)
            {
                Level++;
                _experience = _experience - RemainingExp;
            }
        }

        public void IncreasePower()
        {
            _basePower++;
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
