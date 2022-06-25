namespace MagicBattle
{
    public class Human
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        public int MaxHP { get; protected set; }
        public int HP { get; protected set; }
        public int MaxMana { get; protected set; }  
        public int Mana { get; protected set; } 

        public Human(int age, string name, int maxHP, int hp, int maxMana, int mana)
        {
            Name = name;
            Age = age;
            MaxHP = maxHP;  
            HP = hp;
            MaxMana = maxMana;
            Mana = mana;
        }

        public override string ToString()
        {
            return $"Name: {Name} \nAge: {Age} \nHP: {HP}/{MaxHP} \nMana: {Mana}/{MaxMana}";
        }
    }
}
