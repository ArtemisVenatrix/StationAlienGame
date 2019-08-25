namespace Classes.BodyAssets
{
    public abstract class Organ : IInternalPart, IEffectivePart
    {
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }
        public float Weight { get; set; }
        public float VolumeMod { get; set; }
        public float Volume { get; set; }
        public float DifficultyToHitRanged { get; set; }
        public float DifficultyToHitMelee { get; set; }
        public float PowerMod { get; set; }
        public int[] StatEffects { get; set; }
        public float MineralUpkeep { get; set; }
        public float EnergyUpkeep { get; set; }
        public bool IsCritical { get; set; }

        public float GetCurrentHp()
        {
            return CurrentHp;
        }

        public float GetMaxHp()
        {
            return MaxHp;
        }

        public float GetWeight()
        {
            return Weight;
        }

        public abstract int[] CalcStats();

        public int[] GetStatEffects()
        {
            return StatEffects;
        }
    }
}