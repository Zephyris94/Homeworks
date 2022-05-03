namespace MagicBattle.Spells
{
    public class DefensiveSpell : Spell
    {
        public override CastResult Cast()
        {
            return new CastResult()
            {
                DamageDone = 0,
                CustomEffect = "Base defensive effect"
            };
        }

        public override string GetDescription()
        {
            return "this is a defensive spell";
        }
    }
}
