using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;

namespace MagicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var magician = new Magician(27, 10, "Vlad", Rarity.Epic);

            ////Console.WriteLine(magician.ToString());
            ////Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");

            ////magician.GainExperience(magician.RemainingExp + 10);
            ////Console.WriteLine(magician);
            ////Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");

            //var secondMage = new Magician(20, 5, "Gman", Rarity.Common);

            //var result = magician + secondMage;
            //Console.WriteLine(result);

            DestructionSpell destructionSpell = new DestructionSpell();
            List<DestructionSpell> destructionSpellList = new List<DestructionSpell>(destructionSpell.CreateDestructionSpellsList(10));

            Console.WriteLine("Unsorted list of spells\n");

            foreach (DestructionSpell spell in destructionSpellList)
            {
                Console.WriteLine(spell.DestructionSpellInfo());
            }

            Console.WriteLine("\nList of spells sorted by Power\n");

            var sortedList = destructionSpell.SortByPower(destructionSpellList);

            foreach (DestructionSpell spell in sortedList)
            {
                Console.WriteLine(spell.DestructionSpellInfo());
            }

            Console.WriteLine($"\nSo the strongest spell is {destructionSpell.GetTheStrongestSpell(destructionSpellList).DestructionSpellInfo()}");

        }
    }
}
