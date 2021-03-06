using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class Shield : Spells.Spell
    {

        public Shield(string spellName, string description, string spellType, int power, double damage, int cooldown) 
            : base(spellName, description, spellType, power, damage, cooldown)
        {
            SpellName = spellName;
            Description = description;
            SpellType = spellType;
            Power = power;
            Damage = damage;
            Cooldown = cooldown;
        }
        
    }
}
