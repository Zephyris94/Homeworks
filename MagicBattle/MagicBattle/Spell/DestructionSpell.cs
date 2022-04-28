using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class DestructionSpell : Spell

    {

        public int Damage => Health / 2;
        

        public DestructionSpell()
        {
            
        }

       
    }
}
