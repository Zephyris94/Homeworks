namespace MagicBattle
{
    public class Human
    {
        public string Name { get; protected set; }

        public int Age { get; protected set; }

        public Human()
        {
            
        }

        public Human(int age, string name)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age}";
        }
    }
}
