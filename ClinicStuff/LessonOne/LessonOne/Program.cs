using System;
using LessonOne.Models;

namespace LessonOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, here is our healthcare register");
            var register = new HealthCareRegister();
            var reader = new BildingFileReader();

            HealthcareBuilding activeBuilding;
            activeBuilding = null;
            bool exit = false;

            string command;
            do
            {
                Console.WriteLine("Input 'h' for available commands");
                command = Console.ReadLine();
            } while (command.ToLower() != "h");

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
                        AddNewPatientCommand(register , activeBuilding);
                        break;
                    case ConsoleKey.D3:
                        GetBiggestBuildingCommand(register);
                        break;
                   
                    case ConsoleKey.D8:
                        FileReader(register, reader);
                        break;
                    case ConsoleKey.D9:
                        Console.WriteLine(register.GetWholeInformation());
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
            Console.WriteLine("Input bilding type");
            var type = Console.ReadLine();
            var buildingType = Enum.Parse<BuildingType>(type);

            Console.WriteLine("Input bilding name");
            var bildingName = Console.ReadLine();

            Console.WriteLine("Input car count");
            var carCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input floor count");
            var floorCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Please input max patient count");
            var maxPatients = int.Parse(Console.ReadLine());

            reg.AddNewBuilding(buildingType, carCount, floorCount, maxPatients , bildingName);
        }



        static void FileReader(HealthCareRegister reg, BildingFileReader read)
        {

            var pre = read.GetBuildings();
            reg.AddExsistingBuildings(pre);
        }
        static Patient CreatePatient()
        {
            var patient = new Patient();

            Console.WriteLine("Input name");
            patient.FullName = Console.ReadLine();
            Console.WriteLine("Input age");
            patient.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Input address");
            patient.Address = Console.ReadLine();
            Console.WriteLine("Input diagnosis");
            patient.Diagnosis = Console.ReadLine();
            Console.WriteLine("Input type (Military/Civilian");
            var type = Console.ReadLine();
            patient.PatientType = Enum.Parse<PatientType>(type);

            return patient;
        }
        static void AddNewPatientCommand(HealthCareRegister reg, HealthcareBuilding activeBuilding)
        {
            HealthcareBuilding building = null;

            // Если у нас есть активное здание из других реквестов - попробовать предложить его
            if (activeBuilding != null)
            {
                Console.WriteLine("Would you like to choose active building? (y/n)");
                Console.WriteLine(activeBuilding.ReturnInformation());

                // если пользователь жмакнул y - то просто заполнить билдинг
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    building = activeBuilding;
                }
            }

            // если после операций выше билдинг остался пустым - то тогда выберем его по индексу
            if (building == null)
            {
                building = ChooseBuilding(reg);
            }

            // создадим пациента
            var patient = CreatePatient();

            // миксуем
            reg.AddPatientToBuilding(patient, building);
        }

        static HealthcareBuilding ChooseBuilding(HealthCareRegister reg)
        {
            Console.WriteLine("Choose building index");
            var index = int.Parse(Console.ReadLine());

            return reg.GetBuildingByIndex(index);
        }

        static HealthcareBuilding GetBiggestBuildingCommand(HealthCareRegister reg)
        {
            var key = Console.ReadKey();
            Console.WriteLine("Choose building type : 1 - Clinic, 2 - Hospital 3,");
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    return reg.FindBiggest(BuildingType.Clinic);
                case ConsoleKey.D2:
                    return reg.FindBiggest(BuildingType.Hospital);
                case ConsoleKey.D3:
                    return reg.FindBiggest(BuildingType.Infirmary);
                default:
                    Console.WriteLine("Try again");
                    break;
            }
            return null;
            return reg.FindBiggest(BuildingType.Hospital);
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
            Console.WriteLine("Input 8 to add information from file");
            Console.WriteLine("Input 9 GetWholeInformation");
            Console.WriteLine("Input 'e' for exit");
        }

    }
}

