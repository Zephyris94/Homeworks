using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    internal class DestructionSpell : Spell
    {
        public DestructionSpellType DM_Type { get; set; }
        public DestructionSpellEffects DM_Effect { get; set; }        
    }
}
