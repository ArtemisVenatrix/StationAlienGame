namespace Classes.BodyAssets
{
    public interface IBodyPart
    {
        float MaxHp { get; set; }
        float CurrentHp { get; set; }
        float Weight { get; set; } //per part
        float Volume { get; set; }
        float DifficultyToHitRanged { get; set; } //relative to parent part
        float DifficultyToHitMelee { get; set; } //relative to parent part
        float EnergyUpkeep { get; set; }
        float MineralUpkeep { get; set; }
        bool IsCritical { get; set; }

        float GetMaxHp();
        float GetCurrentHp();
        float GetWeight(); //recursive
        int[] GetStatEffects(); //recursive
        //float CalcMineralUpkeep();
        //float CalcEnergyUpkeep();
    }
}