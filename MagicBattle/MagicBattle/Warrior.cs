using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class Warrior : Character
    {
        private List<string> _skills = new List<string>();
        private int _basePower = 0;
        private int _experience = 0;
        private int _baseIntelligence = 10;
        private int _baseMana = 20;
        private int _baseHealthPoints = 20;


        private const int RequiredLevelModifier = 1000;

        //public Magician()
        //{
        //    Name = "Doe";
        //    Age = 30;
        //    Level = 10;
        //    Rarity = Rarity.Common;
        //}

        public Warrior (int age, int level, string name, int strength, int stamina, int agility, int healthPoints, Race race, Rarity rarity)
        {

            Name = name;
            Age = age;
            Level = level;
            HealthPoints = healthPoints;
            Strength = strength;
            Stamina = stamina;
            Agility = agility;
            Rarity = rarity;
            Race = race;
        }


        public Rarity Rarity { get; private set; }
        public Race Race { get; private set; }

        public int Power => (int)Rarity * 2 + Level * 10 + _skills.Count * 10 + _basePower * 3;

        public int RemainingExp => RequiredExp - _experience;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public void LearnSpell(string spell)
        {
            _skills.Add(spell);
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
            return $"{baseData}.HP: {HealthPoints}, Strength: {Strength}, Stamina: {Stamina}, Agility: {Agility}, Rase: {Race}, {Rarity} Magician  " +
                $"has {Power} power score with {_skills.Count} spells";
        }
    }
}
