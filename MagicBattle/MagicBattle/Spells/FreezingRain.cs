using System;
using MagicBattle.Other;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle.Spells
{
    internal class FreezingRain: Spell
    {
        public FreezingRain()
        {
            Damage = 50;
            ManaCost = 20;
            Effect = "Ледяной дождь";
            TypeOfMagic = TypeOfMagic.Wather;
        }

        public FreezingRain(int damage, int manacost, string effect, TypeOfMagic typeOfMagic)
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

