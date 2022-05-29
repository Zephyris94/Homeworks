using System;
using System.Collections.Generic;
using System.Text;

namespace MegaRaceConsole
{
  public class RaceCar
  {


    Random rnd = new Random();

    public RaceCar() { }
    public RaceCar(ConsoleColor color, int speed, string pilot)
    {
      //PilotRaiting = rnd.Next(4, 10);
      //TeamRaiting = rnd.Next(6, 10);
      Color = color;
      Speed = speed;
      Pilot = pilot;
    }

    public ConsoleColor Color { get; set; }

    public int Speed { get; set; }

    public string Pilot { get; set; }

    public int PilotRaiting { get; set; }

    public int TeamRaiting { get; set; }



    
  }
}
