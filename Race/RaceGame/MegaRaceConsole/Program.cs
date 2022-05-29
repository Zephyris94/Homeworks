using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MegaRaceConsole
{

  /*
    Если после теории захотите поиграться - вот вам задачка.
    Создайте класс машина, у нее 3 свойства - 1 -цвет(ConsoleColor), 2 - скорость(int) км\ч , 3 (string) - имя пилота

    в 4 потока устроить драг заезд машинок(соревнования, кто быстрее приедет)
    каждому потоку - своя машинка(цвет отрисовки) и своя дорожка(индекс строчки на котором отображается в консоли)
    Свяжите как-то скорость с Thread.Sleep() или Task.Delay() т.е чем больше скорость,
    тем меньше задержку.
    Или если вы добавите математики в расчеты - тоже прикольно.
    Ну и кто приедет первым - остановить отрисовку, вывести на экран победителя :)

    Console.SetCursorPosition(); - вот эта команда поможет вам ставить курсор 
    - в нужное место для отрисовки.

    Если есть дополнительно вопросы по дз - спрашивайте :)
   */
  class Program
  {
    //for maximize console window
    //https://www.codegrepper.com/code-examples/csharp/maximize+window+c%23+console
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;

    static void MaximizeWindow()
    {
      Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
      ShowWindow(ThisConsole, MAXIMIZE);

    }

    static void Run(RaceCar car, int trackNumber, int raceInfo)
    {
      //string winner = "";
      Random rnd = new Random();
      int sleep = (rnd.Next(20, 30) * 50) - car.Speed;

      int finishLine = Console.WindowWidth - 7;
      int crashLine = Console.WindowWidth;

      var speed = 0;
      try
      {
        for (int i = 1; i < finishLine; i += (car.TeamRaiting + car.PilotRaiting))
        {
          Thread.Sleep(sleep);

          int tmp = 1;
          tmp = i + car.PilotRaiting;

          if (tmp > speed)
          {
            speed = tmp;
          }
          //Console.Clear();
          Console.SetCursorPosition(0, raceInfo);
          Console.Write($"{car.Pilot}, on {Console.ForegroundColor = car.Color} bolid is driving");

          Console.SetCursorPosition(speed, trackNumber +1);
          Console.Write($"{speed}");


          Console.SetCursorPosition(speed, trackNumber);
          Console.Write($"#-#>");
        }
      }
      catch
      {
        //if (speed > finishLine && speed > crashLine)
        //{
          //i = i + finishLine;
          Console.SetCursorPosition(0, 10 + trackNumber);
          Console.WriteLine($"Oh my god {car.Pilot} is in Accident. Race was stopped");
        //}
      }
      finally
      {
        //if (speed >= finishLine && speed < crashLine)
        //{
          //i = i + finishLine;
          Console.SetCursorPosition(0, 10 + trackNumber);
          Console.WriteLine($"Congratulations!!! {car.Pilot} finish the race");
          //Console.Write();
        //}
      }
    }

    static void Main(string[] args)
    {
      MaximizeWindow();

      Random rnd = new Random();
      string raceResult = null;
      var carSchuma = new RaceCar(ConsoleColor.Red, 250, "Schumacher");
      carSchuma.PilotRaiting = rnd.Next(5, 10);
      carSchuma.TeamRaiting = rnd.Next(7, 10);

      var carHakkinen = new RaceCar(ConsoleColor.Blue , 260, "Hakkinen");
      carHakkinen.PilotRaiting = rnd.Next(3, 8);
      carHakkinen.TeamRaiting = rnd.Next(5, 8);

      int mikRaceInfo = 0;
      int mikTrackNumber = Console.CursorTop + 1;


      int kimiRaceInfo = 3;
      int kimiTrackNumber = Console.CursorTop + 4;


      Thread pos1 = new Thread(() =>
        Run(carSchuma, mikTrackNumber, mikRaceInfo));

      Thread pos2 = new Thread(() =>
        Run(carHakkinen, kimiTrackNumber, kimiRaceInfo));


      pos1.Start();

      pos2.Start();


      Console.WriteLine(raceResult);






      //for (int i = 1; i < Console.WindowWidth - 1; i++)
      //{
      //  Console.Clear();                
      //  Console.SetCursorPosition(0, 0);
      //  Console.WriteLine("Race Comming!");
      //  Console.SetCursorPosition(i, (Console.CursorTop));
      //  Console.Write($"#-#>");
      //}


      Console.ReadLine();
    }

  }
}

