using MagicBattle.Spells.Metadata;

namespace MagicBattle.Spells
{
    public abstract class Spell
    {
        public int Manacost { get; protected set; }

        public int Level { get; set; }

        public double Duration { get; set; } // in seconds

        public double CastPoint { get; set; } // in seconds

        public Affinity Affinity { get; protected set; }

        public TargetType TargetType { get; protected set; }

        public abstract CastResult Cast();

        public abstract string GetDescription();
    }
}
