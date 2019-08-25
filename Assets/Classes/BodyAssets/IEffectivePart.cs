namespace Classes.BodyAssets
{
    public interface IEffectivePart
    {
        float PowerMod { get; set; }
        float VolumeMod { get; set; }
        int[] StatEffects { get; set; } //strength, intelligence, constitution, dexterity, agility, land movement speed, propulsion speed, perception;
        int[] CalcStats();
    }
}