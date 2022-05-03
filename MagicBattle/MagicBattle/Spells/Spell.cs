<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MagicBattle.Spells
{
  public class Spell
  {
    public double MinPower { get; set; } = 100;

    public double MaxPower { get; set; } = 1000; 

    public string Effect { get; set; }

    public double Damage { get; set; } = 10;


    public int Duration { get; set; } = 10;

    // min level for magician who can use this spell    
    public int MinMagicianLevel { get; private set; } = 1;

    // min mana level that need magician for use spell 
    public int MinManaValue { get; private set; } = 5;
    


    public enum Type
    {      
      // regenerate health or mana units
      Regenerative = 1,

      // can protect from damage (shield or something else)     
      Protective = 2,

      // can damage enemy
      Destructive = 3,
      
      // other
      Versative = 4
    }

    public enum Complexity
    {     
      Light = 1, 

      Middle = 2,

      Hard = 3,

      Fatal = 4    
      
    }
  }
=======
﻿using MagicBattle.Spells.Metadata;

namespace MagicBattle.Spells
{
    public abstract class Spell
    {
        public int Manacost { get; protected set; }

        public int Level { get; set; }

        public double Duration { get; set; } // in seconds

        public double CastPoint { get; set; } // in seconds

        public Affinity Affinity { get; protected set; }

        public TargetType TargetType { get; protected set; }

        public abstract CastResult Cast();

        public abstract string GetDescription();
    }
>>>>>>> Test
}
