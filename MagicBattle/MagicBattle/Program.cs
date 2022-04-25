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

            magician.GainExperience(magician.RemainingExp + 10);
            Console.WriteLine(magician);
            Console.WriteLine($"We need {magician.RemainingExp} experinece to levelup");

            var secondMage = new Magician(20, 5, "Gman", Rarity.Common);

            var result = magician + secondMage;
            Console.WriteLine(result);

        }
    }
}
