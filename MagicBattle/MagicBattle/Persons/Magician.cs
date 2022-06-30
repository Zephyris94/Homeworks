using MagicBattle.Enums;
using MagicBattle.Spells;
using System;
using System.Collections.Generic;

namespace MagicBattle.Persons
{
    public class Magician : Human
    {
        public List<string> _spells = new List<string>();
        private int _basePower = 0;
        private int _experience = 0;

        private const int RequiredLevelModifier = 1000;

        public Magician()
            : base(25, "Doe", 100, 10, 100, 10)
        {
            Level = 10;
            Rarity = Rarity.Common;
        }

        public Magician(int age, int level, string name, Rarity rarity, int maxHP, int HP, int maxMana, int mana)
            : base(age, name, maxHP, HP, maxMana, mana)
        {
            Level = level;
            Rarity = rarity;
        }


        public int Level { get; private set; }

        public Rarity Rarity { get; private set; }

        public int Power => (int)Rarity * 2 + Level * 10 + _spells.Count * 10 + _basePower * 3;

        public int RemainingExp => RequiredExp - _experience;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public void LearnSpell(string spell)
        {
            _spells.Add(spell);
        }

        public void CastSpell(int spellNum)
        {
            try { 
                var sp = _spells[spellNum];
                Console.WriteLine($"cast {_spells[spellNum]}");
            } 
            catch 
            {
                Console.WriteLine($"spell {_spells[spellNum]} not found");
            }
        }

        public void ShowSpells()
        {
            foreach (var Spells in _spells)
            {
                System.Console.WriteLine($"spell: {Spells}");
            }

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
            return $"{baseData}. \n{Rarity} Magician {Level} lvl. has {Power} power score with {_spells.Count} spells";
        }
    }
}
