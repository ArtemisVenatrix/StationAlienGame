using System.Collections.Generic;

namespace Classes.BodyAssets
{
    public abstract class ContainerPart : IExternalPart
    {
        public List<IBodyPart> ContainedParts { get; set; }
        public float CurrentHp { get; set; }
        public float MaxHp { get; set; }
        public float DifficultyToHitRanged { get; set; }
        public float DifficultyToHitMelee { get; set; }
        public float Volume { get; set; }
        public float Armor { get; set; }
        public float Weight { get; set; }
        public float EnergyUpkeep { get; set; }
        public float MineralUpkeep { get; set; }
        public bool IsCritical { get; set; }


        public float GetChildVolumeSum()
        {
            float sum = 0.0f;
            foreach (var part in ContainedParts)
            {
                sum += part.Volume;
            }

            return sum;
        }

        public float GetCurrentHp()
        {
            float currentHpTemp = CurrentHp;
            foreach (var part in ContainedParts)
            {
                currentHpTemp += part.GetCurrentHp();
            }

            return currentHpTemp;
        }

        public float GetMaxHp()
        {
            float maxHpTemp = MaxHp;
            foreach (var part in ContainedParts)
            {
                maxHpTemp += part.GetMaxHp();
            }

            return maxHpTemp;
        }

        public float GetWeight()
        {
            float weightTemp = Weight;
            foreach (var part in ContainedParts)
            {
                weightTemp += part.GetWeight();
            }

            return weightTemp;
        }

        public int[] GetStatEffects()
        {
            int[] statsSum = new int[8];
            foreach (var part in ContainedParts)
            {
                int[] statsTemp = part.GetStatEffects();
                for (int i = 0; i < statsSum.Length; i++)
                {
                    statsSum[i] += statsTemp[i];
                }
            }

            return statsSum;
        }

        public float CalcEnergyUpkeep()
        {
            return Volume * 0.8f;
        }

        public float CalcMineralUpkeep()
        {
            return Volume + Armor * 0.8f;
        }
    }
}