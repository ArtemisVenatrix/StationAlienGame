using System;

namespace Classes.BodyAssets
{
    public class Brain : Organ
    {

        private const int IntelligenceBase = 5;
         private const float VolumeBase = 5.0f;
         private const float WeightBase = 2.0f;

         public Brain(float volumeMod, float powerMod)
         {
             VolumeMod = volumeMod;
             PowerMod = powerMod;
             IsCritical = true;
             MaxHp = 10.0f;
             CurrentHp = MaxHp;
             Weight = VolumeMod * WeightBase;
             Volume = VolumeBase * VolumeMod;
             StatEffects = CalcStats();
             DifficultyToHitMelee = 0.15f;
             DifficultyToHitRanged = 1.0f;
         }

         public override int[] CalcStats()
         {
             int modifiedIntelligence = (int)(IntelligenceBase * VolumeMod * PowerMod);
             return new int[]
             {
                 0,
                 modifiedIntelligence,
                 0,
                 0,
                 0,
                 0,
                 0,
                 0
             };
         }
    }
}