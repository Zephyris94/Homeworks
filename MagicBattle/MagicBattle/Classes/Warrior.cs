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
        private int _baseSkillPoint = 0; 
        private int _baseStrength = 15;
        private int _baseStamina = 20;
        private int _baseAgility = 20;
        private int _baseHealthPoints = 20;
        private int _baseDeffence = 15;
        private int _baseLvl = 0;
        private string _baseName = "User";
        private int _baseAge = 0;


        private const int RequiredLevelModifier = 1000;

        public Warrior()
        {
            Name = _baseName;
            Age = _baseAge;
            Level = _baseLvl;
            Race = Race.Unknown;
            Rarity = Rarity.Common;
            Deffence = _baseDeffence;
            HealthPoints = _baseHealthPoints;
            Stamina = _baseStamina;
            Agility = _baseAgility;
            Strength = _baseStrength;
            SkillPoint = _baseSkillPoint;
        }
        public Warrior (int age, int level, string name, int strength, int deffence,
            int stamina, int agility, int healthPoints, Race race, Rarity rarity)
        {
            Name = name;
            Age = age;
            Level = level;
            HealthPoints = healthPoints;
            Deffence = deffence;
            Strength = strength;
            Stamina = stamina;
            Agility = agility;
            Rarity = rarity;
            Race = race;
        }

        public Rarity Rarity { get; private set; }
        public Race Race { get; private set; }

        public int Power => (int)Rarity * 2 + Level * 10 + _skills.Count * 10 + _basePower * 3 + (int)Race * 2;

        public int RemainingExp => RequiredExp - _experience;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public void LearnSkill(string skill)
        {
            _skills.Add(skill);
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
            return $"{baseData}.HP: {HealthPoints}, Strength: {Strength}, Deffence {Deffence} " +
                $"Stamina: {Stamina}, Agility: {Agility}, Rase: {Race}, {Rarity} Warrior  " +
                $"has {Power} power score with {_skills.Count} skill";
        }
    }
}
