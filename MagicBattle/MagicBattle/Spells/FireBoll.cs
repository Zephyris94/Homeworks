using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle.Spells
{
    public class FireBoll : Spell
    {

        public FireBoll(int damage, int manacost, string effect)
        {

           Damage = damage;
           ManaCost = manacost;
           Effect = effect;

        }
    }
   
}
