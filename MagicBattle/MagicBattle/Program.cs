//Homework by #OleksiiV
using System;
using System.Net;
using System.Net.Http;

namespace MagicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            var magician = new Magician(27, 10, "Vlad", Rarity.Epic);

            Console.WriteLine(magician.ToString());
            Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");
            Console.WriteLine($"HP: {magician.HealthPoints}, MP: {magician.ManaPoints}\n");

            magician.GainExperience(magician.RemainingExp + 10);
            magician.RenameCharacter("Don");
            Console.WriteLine(magician);
            Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");
            Console.WriteLine($"HP: {magician.HealthPoints}, MP: {magician.ManaPoints}\n");

            magician.GainExperience(50);
            Console.WriteLine(magician.ToString());
            magician.LearnSpell();
        }
    }
}
