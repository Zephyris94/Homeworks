using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle
{
    public class Spell
    {
        public int Damage { get; protected set; }
        public int ManaCost { get; protected set; }
        public string Effect { get; protected set; }
    }
}
