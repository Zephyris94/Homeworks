namespace MagicBattle
{
    public class Human
    {
        public string Name  { get; protected set; }
        public int Age      { get; protected set; }

        public int HealthPoints => 100 + Strength;
        public int ManaPoints   => 100 + Intelligence;

        public int Intelligence { get; protected set; } = 1;
        public int Agility      { get; protected set; } = 1;
        public int Strength     { get; protected set; } = 1;

        public Human(int age, string name)
        {
            Name = name;
            Age = age;
        }

        public void RenameCharacter(string newName)
        {
            Name = newName;
        }

        public override string ToString()
        {
            return $"Name = {Name}, Age = {Age}";
        }
    }
}
