namespace MagicBattle
{
  public class Human
  {
    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public double HealthValue { get; set; }

    public double ManaValue { get; set; }

    public bool IsHasMana { get; set; }

    // check if magician know or not the spell
    public bool IsKnownSpell { get; set; } = false;


    public Human(int age, string name)
    {
      Name = name;
      Age = age;
    }

        public Human()
        {
        }

        public override string ToString()
    {
      return $"Name = {Name}, Age = {Age}";
    }
  }
}
