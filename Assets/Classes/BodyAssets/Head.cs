using System.Collections.Generic;

namespace Classes.BodyAssets
{
    public class Head : ContainerPart
    {
        private const float volumeBase = 2.0f;
        private const float armorToWeightFactor = 0.5f;
        public Head(List<IBodyPart> containedParts, float armor)
        {
            MaxHp = 10.0f;
            CurrentHp = MaxHp;
            ContainedParts = containedParts;
            Volume = GetChildVolumeSum() + volumeBase;
            Armor = armor;
            Weight = 2.0f + armor * armorToWeightFactor;
            IsCritical = true;
            DifficultyToHitMelee = 0.2f;
            DifficultyToHitRanged = 0.1f;
        }
    }
}