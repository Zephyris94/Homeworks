using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MagicBattle
{
    public class DestructionSpell : Spell
    {
        public DestructionSpellType DM_Type { get; set; }
        public DestructionSpellEffects DM_Effect { get; set; }
        public DestructionSpell CreateRandomDestructionSpell(string spellName)
        {
            DestructionSpell destructionSpell = new DestructionSpell();
            Array spellType = Enum.GetValues(typeof(DestructionSpellType));            
            Random rnd = new Random();

            destructionSpell.Name = spellName;
            destructionSpell.Power = rnd.Next(1,MaxSpellPower);
            destructionSpell.DM_Type = (DestructionSpellType)spellType.GetValue(rnd.Next(spellType.Length));

            switch (destructionSpell.DM_Type)
            {
                case DestructionSpellType.Fire: destructionSpell.DM_Effect = DestructionSpellEffects.Burning;
                    break;
                case DestructionSpellType.Ice: destructionSpell.DM_Effect = DestructionSpellEffects.Cold;
                    break;
                case DestructionSpellType.Lightning: destructionSpell.DM_Effect = DestructionSpellEffects.Electrified;
                    break;
                case DestructionSpellType.Water: destructionSpell.DM_Effect = DestructionSpellEffects.Wet;
                    break;
                default: destructionSpell.DM_Effect = DestructionSpellEffects.None;
                    break;
            }
            destructionSpell.ManaCost = rnd.Next(1,destructionSpell.Power);

            return destructionSpell;
        }
        public List<DestructionSpell> CreateDestructionSpellsList(int count)
        {
            List<DestructionSpell> destructionSpells = new List<DestructionSpell>();
            for(int i = 0; i < count; i++)
            {
                destructionSpells.Add(CreateRandomDestructionSpell($"Spell {i}"));
            }
            return destructionSpells;
        }
        public List<DestructionSpell> SortByPower(List<DestructionSpell> spellList)
        {
            var sortedSpellList = spellList.OrderByDescending(p => p.Power).ToList();
            return sortedSpellList;
        }
        public DestructionSpell GetTheStrongestSpell(List<DestructionSpell> spellList)
        {
            var sortedSpellList = spellList.OrderByDescending(p => p.Power);
            return sortedSpellList.First();
        }
        public string DestructionSpellInfo()
        {
            return $"Spell name: {Name}. Element: {DM_Type}. Spell effect: {DM_Effect}. Spell power: {Power}";
        }
    }
}
