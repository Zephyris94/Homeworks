using System.Collections.Generic;

namespace MagicBattle
{
    public class Magician : Character
    {
        private List<string> _spells = new List<string>();
        private int _basePower = 0;
        private int _experience = 0;
        private int _baseSkillPoint = 0;
        private int _baseIntelligence = 10;
        private int _baseMana = 20;
        private int _baseHealthPoints = 20;
        private int _baseDeffence = 10;
        private int _baseLvl = 0;
        private string _baseName = "User";
        private int _baseAge = 0;


        private const int RequiredLevelModifier = 1000;

        public Magician()
        {
            Name = _baseName;
            Age = _baseAge;
            Level = _baseLvl;
            Race = Race.Unknown;
            Rarity = Rarity.Common;
            Deffence = _baseDeffence;                      
            HealthPoints = _baseHealthPoints;
            Mana = _baseMana;
            Intelligence = _baseIntelligence;
            SkillPoint = _baseSkillPoint;
            
        }

        public Magician(int age, int level, string name, int mana, int intelligence, int healthPoints, Race race, Rarity rarity)           
        {
            
            Name = name;
            Age = age;
            Level = level;
            Name = name;
            Age = age;
            Level = level;
            HealthPoints = healthPoints;
            Mana = mana;
            Intelligence = intelligence;
            Rarity = rarity;
            Race = race;
        }

        //public new int Level { get; private set; }

        public Rarity Rarity { get; private set; }
        public Race Race { get; private set; }

        public int Power => (int) Rarity * 2 + Level * 10 + _spells.Count * 10 + _basePower*3;

        public int RemainingExp => RequiredExp - _experience;

        private int RequiredExp => (Level + 1) * RequiredLevelModifier;

        public void LearnSpell(string spell)
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
            return $"{baseData}.HP: {HealthPoints}, Strength: {Strength}, Deffence {Deffence} " +
                $"Stamina: {Stamina}, Agility: {Agility}, Rase: {Race}, {Rarity} Warrior  " +
                $"has {Power} power score with {_spells.Count} skill";
        }
    }
}
