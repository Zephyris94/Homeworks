namespace MagicBattle
{
    public class Character
    {      
        public string Strength { get; protected set; }
        public string Stamina { get; protected set; }

        public string Agility { get; protected set; }
        public string Mana { get; protected set; }
        public string Intelligence { get; protected set; }
        public string Name { get; protected set; }
        public int Level { get; protected set; }    
        public int Age { get; protected set; }

        //public Character(int age, string name)
        //{
        //    Name = name;
        //    Age = age;
        //}

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age}" ;
        }
    }
}
