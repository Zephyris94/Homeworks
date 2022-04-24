using MagicBattle.Spells;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MagicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var fireboll = new FireBoll(20, 5, "Огенный шар", Other.TypeOfMagic.Fire);
            var freezingrain = new FreezingRain();
            //Console.WriteLine(fireboll.ToString());
            //Console.WriteLine(freezingrain.ToString());
            
            //var magician = new Magician();
            //var warrior = new Warrior();
            //Console.WriteLine(magician.ToString());
            //Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");
            ////magician.GainExperience(magician.RemainingExp + 10);
            //Console.WriteLine(warrior);
            //Console.WriteLine($"We need {warrior.RemainingExp} experinece to levelup");

            List<Spell> spells = new List<Spell>();
            spells.Add(fireboll);
            spells.Add(freezingrain);
            foreach (var spell in spells)
            {
                spell.Cast();
            }
        }
    }
}
