using System;
using LessonOne.Models;

namespace LessonOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = new HealthCareRegister();
            HealthcareBuilding activeBuilding;
            bool exit = false;

            Console.WriteLine("Hello, here is our healthcare register");

            string command = string.Empty;
            do
            {
                Console.WriteLine("Input 'help' for available commands");
                command = Console.ReadLine();
            } while (command.ToLower() != "help");

            DisplayMenu();

            do
            {
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        AddNewBuildingCommand(register);
                        break;
                    case ConsoleKey.D2:
                        AddNewPatientCommand();
                        break;
                    case ConsoleKey.D3:
                        GetBiggestBuildingCommand();
                        break;
                    case ConsoleKey.E:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            } while (!exit);

            Console.WriteLine(register.GetWholeInformation());

            Console.WriteLine("Good bye");
        }

        static void AddNewBuildingCommand(HealthCareRegister reg)
        {
            // BuildingType type, int carCount, int floorCount, int maxPatients
            Console.WriteLine("Input type");
            var type = Console.ReadLine();
            var buildingType = Enum.Parse<BuildingType>(type);

            Console.WriteLine("Input car count");
            var carCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input floor count");
            var floorCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input max patient count");
            var maxPatients = int.Parse(Console.ReadLine());

            reg.AddNewBuilding(buildingType, carCount, floorCount, maxPatients);
        }

        static void AddNewPatientCommand()
        {

        }

        static HealthcareBuilding GetBiggestBuildingCommand()
        {
            return null;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Input 1 to create a new building");
            Console.WriteLine("Input 2 to add a patient");
            Console.WriteLine("Input 3 to find the biggest building");
            Console.WriteLine("Input 4 to find the most free building");
            Console.WriteLine("Input 5 to find first building with free car");
            Console.WriteLine("Input 6 to get all building information");
            Console.WriteLine("Input 7 to get full register");
            Console.WriteLine("Input 'e' for exit");
        }

    }
}

