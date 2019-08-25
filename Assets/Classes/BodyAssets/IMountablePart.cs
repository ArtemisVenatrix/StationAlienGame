using UnityEngine;

namespace Classes.BodyAssets
{
    public interface IMountablePart
    {
        Vector2 Location { get; set; }
        Vector2Int BoundingDimensions { get; set; }
        Vector2 FloatDimensions { get; set; }
    }
}