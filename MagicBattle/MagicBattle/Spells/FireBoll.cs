using MagicBattle.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle.Spells
{
    public class FireBoll : Spell
    {

        public FireBoll(int damage, int manacost, string effect, TypeOfMagic typeOfMagic)
        {

           Damage = damage;
           ManaCost = manacost;
           Effect = effect;
           TypeOfMagic = typeOfMagic;
        }

        public TypeOfMagic TypeOfMagic { get; private set; }
        public override string ToString()
        {
            return $"Name = {Effect}, ManaCost = {ManaCost} , Damage = {Damage} , Type {TypeOfMagic}";
        }
    }
   
}
