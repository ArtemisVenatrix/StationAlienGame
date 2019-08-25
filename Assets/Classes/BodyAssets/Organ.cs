namespace Classes.BodyAssets
{
    public abstract class Organ : IEffectivePart, IBodyPart
    {
        public int[] StatEffects { get; set; }
        public float PowerMod { get; set; }
        public float VolumeMod { get; set; }
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }
        public float Volume { get; set; }
        public abstract int[] GetStatEffects();
    }
}