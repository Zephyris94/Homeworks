namespace MagicBattle.Spells
{
    public class OffensiveSpell : Spell
    {
        public override CastResult Cast()
        {
            return new CastResult()
            {
                DamageDone = 0,
                CustomEffect = "Base offensive effect"
            };
        }

        public override string GetDescription()
        {
            return "This is an offensive spell";
        }
    }
}
