namespace MagicBattle
{
    public enum DestructionSpellEffects
    {
        None = 0,
        Burning = 1,        
        Cold = 2,
        Electrified = 3,
        Wet = 4,

        Vaporise = 10, //Burning + Wet
        Superconduct = 11, //Cold + Electrified
        Overloaded = 12, //Burning + Electrified
        Melt = 13, //Cold + Burning
        ElectroCharged = 14, //Wet + Electrified
        Frozen = 15, //Wet + Cold
    }
}
