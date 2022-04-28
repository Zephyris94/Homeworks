namespace MagicBattle
{
    public class Human
    {
        public string Name { get; set; }

        public int Age { get; set; }
       

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
