namespace Classes.BodyAssets
{
    public interface IBodyPart
    {
        float MaxHp { get; set; }
        float CurrentHp { get; set; }
        float Volume { get; set; }

        int[] GetStatEffects();
    }
}