namespace MagicBattle
{
    public enum DestructionSpellEffects
    {
        Electrified = 1,
        Burning = 2,
        Wet = 3,
        Cold = 4,

        Vaporise = 10, //Burning + Wet
        Superconduct = 11, //Cold + Electrified
        Overloaded = 12, //Burning + Electrified
        Melt = 13, //Cold + Burning
        ElectroCharged = 14, //Wet + Electrified
        Frozen = 15, //Wet + Cold
    }
}
