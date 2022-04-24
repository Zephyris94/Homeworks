namespace MagicBattle
{
    public class Character
    {      
        public int Strength { get; protected set; }
        public int Stamina { get; protected set; }
        public int SkillPoint { get; protected set; }
        public int Agility { get; protected set; }
        public int Deffence { get; protected set; }
        public int Mana { get; protected set; }
        public int Intelligence { get; protected set; }
        public string Name { get; protected set; }
        public int Level { get; protected set; }    
        public int Age { get; protected set; }
        public int HealthPoints { get; protected set; }

        //public Character(int age, string name)
        //{
        //    Name = name;
        //    Age = age;
        //}

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age} , Lvl = {Level}"  ;
        }
    }
}
