namespace Classes.BodyAssets
{
    public class Eyes : Organ
    {
        private const float VolumeBase = 1.0f;
        private const float WeightBase = 0.2f;
        private const float PerceptionBase = 5;
        public Eyes(float powerMod)
        {
            PowerMod = powerMod;
            VolumeMod = 1.0f;
            IsCritical = false;
            MaxHp = 8.0f;
            CurrentHp = MaxHp;
            Volume = VolumeBase * VolumeMod;
            Weight = Volume * WeightBase;
            DifficultyToHitMelee = 0.15f;
            DifficultyToHitRanged = 0.15f;
        }

        public override int[] CalcStats()
        {
            int modifiedPerception = (int) (PerceptionBase * PowerMod);
            return new[]
            {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                modifiedPerception
            };
        }
    }
}