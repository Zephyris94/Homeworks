using MagicBattle.Enums;
using System;
using MagicBattle;


namespace MagicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int age = rand.Next(15, 100);
            int lvl = rand.Next(0, 10);
            int maxHP = 100;
            int HP = rand.Next(1,100);
            int maxMana = 100;
            int mana = rand.Next(1, 100);
            var rar = (Rarity)rand.Next(Enum.GetNames(typeof(Rarity)).Length); //time to shitcode

            Console.WriteLine("\n\n\n\n");
            Console.Title = "magic battle emulator";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\t\tWelcome to magic battle emulator v0.1");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t\t\t\tenter any key to start.");

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Enter your character name: ");
            string name = Console.ReadLine();

            var magician = new Magician(
                age: age, 
                level: lvl,
                name: name, 
                rarity: rar,
                maxHP: maxHP,
                HP: HP,
                maxMana: maxMana,
                mana: mana);

            var fireboll = new Fireboll(
                spellName: "fireboll",
                description: "attacks the enemy with a ball of fire", 
                spellType: "attack",
                power: 5, 
                damage: 20, 
                cooldown: 3
                );

            var shield = new Shield(
                spellName: "woter shield",
                description: "create shield of woter",
                spellType: "support",
                power: 3,
                damage: 0,
                cooldown: 3
                );

            magician.LearnSpell(fireboll.SpellName);
            magician.LearnSpell(shield.SpellName);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                    $"your character\n\n" +
                    $"name: {magician.Name}\n" +
                    $"age: {age}\n" +
                    $"level: {lvl}\n\n" +
                    $"HP: {HP}/{maxHP}\n" +
                    $"Mana: {mana}/{maxMana}\n" +
                    $"rarity: {rar}\n"
                );

            magician.ShowSpells();

            Console.ReadKey();
        }
    }
}
