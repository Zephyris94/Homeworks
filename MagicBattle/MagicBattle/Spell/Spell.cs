using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class Spell
    {
        public SpellType Type { get; set; } = SpellType.Exploding;
        public SpellComplexity Complexity { get; set; } = SpellComplexity.initial;
        public string Name { get; set; }  
        public string Description { get; set; } = string.Empty;
        public const int MinPower  = 100;
        public const int MaxPower = 1000;
        public int Power { get; protected set; } = 1;
        public int Health { get; set; } = 100;
        public int Mana { get; set; } = 100;



        public Spell()
        {
            this.Name = Name;
            this.Description = Description;
            this.Complexity = Complexity;   
            this.Power = Power; 
            this.Health = Health;   
                    
        }

        public string SpellDescription() {
            return $"Name {Name}, Spell description {Description}, Power {Power}" ;
        }

       
    }
}
