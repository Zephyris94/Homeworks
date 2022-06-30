namespace MagicBattle.Spells
{
    public class Spell
    {
        public string SpellName { get; protected set; }
        public string Description { get; protected set; }
        public string SpellType { get; protected set; }
        public int Power { get; protected set; }
        public double Damage { get; protected set; }
        public int Cooldown { get; protected set; }

        public Spell(string spellName, string description, int power, double damage, int cooldown, string spellType)
        {
            SpellName = spellName;
            Description = description;
            Power = power;
            Damage = damage;
            Cooldown = cooldown;
            SpellType = spellType;
        }

        public Spell(string spellName, string description, string spellType, int power, double damage, int cooldown)
        {
            SpellName = spellName;
            Description = description;
            SpellType = spellType;
            Power = power;
            Damage = damage;
            Cooldown = cooldown;
        }

        public override string ToString()
        {
            return $"Spell name: {SpellName} \nDescript: {Description} \n Power: {Power} \n Damage: {Damage} \n Cooldown: {Cooldown}";
        }
    }
}