using System;
using System.Collections.Generic;
using System.Linq;
using LessonOne.Models;

namespace LessonOne
{

  /*
    1) По кнопке 'h' выдавать меню команд
    
    
    3) Реализовать команды для вывода данных.
    
    4) Обработать исключения, которые мы бросаем изнутри
    Сразу выводить пользователю сообщение об ошибке
    Складывать все сообщения об ошибках в массив и перед закрытием
    программы предложить вывести их на экран.

    Текущая версия проекта лежит в нашем репозитории, стяните последнюю версию Теста и отбренчуйтесь от нее
   */



  class Program
  {

    static void Main(string[] args)
    {

      var register = new HealthCareRegister(new List<HealthcareBuilding>()
      {
        new Hospital(101,5, 5, 150),
        new Hospital(102, 3, 2, 100),
        new Hospital(103, 2, 1, 50),
        new Infirmary(201, 7, 7, 500),
        new Infirmary(202,5, 3, 350),
        new Infirmary(203, 3, 1, 200)
      });
      //var hospitals = new Hospital(101, 5, 5, 150);
      //var clinics = new List<Clinic>();
      //var infirmaries = new List<Infirmary>();

      //register.AddPatientToBuilding();

      ;
      var emptyHospitals = register.Buildings
        .Where(x => x.Type == BuildingType.Hospital ||
        x.Type == BuildingType.Infirmary).Max(m => m.MaxPatients);


      

      bool exit = false;

      Console.WriteLine("Hello, here is our healthcare register");

      string command = string.Empty;
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
            AddNewPatientCommand(register);
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
      Console.WriteLine("Input number");
      var id = int.Parse(Console.ReadLine());

      Console.WriteLine("Input type");
      var type = Console.ReadLine();
      var buildingType = Enum.Parse<BuildingType>(type);

      Console.WriteLine("Input car count");
      var carCount = int.Parse(Console.ReadLine());

      Console.WriteLine("Please input floor count");
      var floorCount = int.Parse(Console.ReadLine());

      Console.WriteLine("Please input max patient count");
      var maxPatients = int.Parse(Console.ReadLine());

      reg.AddNewBuilding(id, buildingType, carCount, floorCount, maxPatients);
    }

    /*
        2) Реализовать добавление нового пациента по схеме:
            - Если есть активное заведение(об этом дальше) 
              предлагать поместить пациента в него
            - Если такого нет, или пользователь отказался,
              предлагать выбрать заведение по номеру.
        При выборе клиники по номеру делать -1.
        То есть если человек вводит с консоли положить пациента в больницу 1 - это означает в нулевую.
        Обработать ввод правильно от 1 до вменяемого целого числа.
            - Реализовать другие команды - получить самое большое заведение, самое свободное, с первой свободной машиной.
        При получении результата - вписывать его в "активное заведение", которое потом можно предложить при размещении пациента
    */
    static void AddNewPatientCommand(HealthCareRegister reg)
    {
      Console.WriteLine("Add new patient.");
      Console.WriteLine("For 'MILITARY' press 1. For 'CIVILIAN' press 2. Else press 3");


      var patientTmp = Console.ReadLine();

      int patientType = CheckPatient(patientTmp);


      switch (patientType)
      {
        // military
        case 1:
          Console.WriteLine(
            "wish you get place for you militarian in hospital number \n");
         
            var mostEmptyHospital =
              (Hospital)reg.FindMostEmpty(BuildingType.Hospital);
            Console.WriteLine(mostEmptyHospital.ReturnInformation() + "\n");
          //}
          Console.WriteLine(
            $"For register in {mostEmptyHospital.Id} press Y \n" +
            $"for make choice from available hospitals press F");

          var toCurrent = Console.ReadLine().ToLower();
          if (toCurrent.Equals("Y")) 
          {
            var patient = CreatePatient(PatientType.Military);
            reg.AddPatientToBuilding(patient, mostEmptyHospital);
          }
          else
          {
            var activeHospitals = GetActiveHospitals(reg);
          }

          //  GetActiveHospitals();
         
          
          

          //  reg.AddPatientToBuilding(
          //    patient,
          //    new Hospital() { });

          //  break;
          //case 2:
          //  AddNewPatientCommand();
          //  break;
          //case ConsoleKey.D3:
          //  GetBiggestBuildingCommand();
          //  break;
          //case ConsoleKey.E:
          //  exit = true;
          //  break;
          //default:
          //  Console.WriteLine("Try again");
          break;
      }


      //add patient into hospital or clinic or infirmary



    }
    /// <summary>
    /// CREATE PATIENT
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static Patient CreatePatient(PatientType type)
    {
      bool tmp = false;

      int age = 0;
      string fullName, diagnosis, address;

      PatientType pType;
      Patient resultPatient = null;



      switch (type)
      {
        case PatientType.Military:
          while (!tmp)
          {
            Console.WriteLine("Enter patient age: ");
            try
            {
              age = int.Parse(Console.ReadLine());
              if (age < 0 || age > 120)
              {
                Console.WriteLine("Incorrect age value, enter correct age value");
              }
              else
              {
                tmp = true;
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine("Age is not a number, enter correct age value");
            }
          }
          Console.WriteLine("Enter patient fullname");
          fullName = Console.ReadLine();

          Console.WriteLine("Entee patient diagnosis");
          diagnosis = Console.ReadLine();

          Console.WriteLine("Enter patient address");
          address = Console.ReadLine();

          pType = PatientType.Military;

          resultPatient = new Patient
          {
            Age = age,
            FullName = fullName,
            Diagnosis = diagnosis,
            Address = address,
            PatientType = pType
          };
          break;
      }

      return resultPatient;
    }

    /// <summary>
    /// GET ACTIVE HOSPITALS
    /// </summary>
    static Hospital GetActiveHospitals(HealthCareRegister reg)
    {
      Hospital hospital = null;
      var activeHospitals = new List<HealthcareBuilding>();

      // find all empty
      for (int i = 0; i < reg.Buildings.Count; i++)
      {
        // find where we can register militarian
        if (reg.Buildings[i].IsActive)
          activeHospitals.Add(reg.Buildings[i]);
      }
      
      // list of empty hospitals for user choice
      Console.WriteLine("There are active hospitals for register");
      foreach (var active in activeHospitals)
      {
        switch (active.Type) {
          case BuildingType.Hospital:
            Console.WriteLine(((Hospital)active).ReturnInformation());
            break;
          //case BuildingType.Infirmary:
          //  Console.WriteLine(((Infirmary)active).ReturnInformation());
          //  break;
        }       
      }

      Console.WriteLine("Enter hospital number where you want register");
      try
      {        
        var hospitalId = int.Parse(Console.ReadLine());

        List<Hospital> hsTmp = activeHospitals
          .Where(b => b.Type == BuildingType.Hospital)
          .Select(b => (Hospital)b).ToList();

        hospital = hsTmp.Where(h => h.Id == hospitalId).FirstOrDefault();        
      }
      catch (Exception ex)
      {
        Console.WriteLine("uncorrect hospital number");
        string exMessage = ex.Message;
      }
      ;

      //var emptyHospitals = reg.Buildings
      //  .Where(x => x.Type == BuildingType.Hospital ||
      //  x.Type == BuildingType.Infirmary).Max();

      //var hospital = reg.FindMostEmpty(BuildingType.Hospital);

      //throw new NotImplementedException();
      //var result = new Hospital(1,1,1,1);
      return hospital;

    }

    // check if patient type entered correctly
    static int CheckPatient(string patientType)
    {
      int result = 0;

      try
      {
        result = int.TryParse(patientType, out result) ? result : 0;
      }
      catch (Exception ex)
      {
        string exMessage = ex.Message;
      }

      return result;
    }

    //static bool CheckHealthCareBuilding()
    //{
    //  var result = true;

    //  return result;
    //}





    static HealthcareBuilding GetBiggestBuildingCommand()
    {
      return null;
    }

    static void DisplayMenu()
    {
      Console.WriteLine("Input 1 to create a new building"); //done
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

