using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    
    /// <summary>
    /// This class represnets a tile with no states
    /// </summary>
    [CreateAssetMenu]
    public class StaticVentableCustomTile : CustomTile
    {
        //There is no need for this class realy, but important to have some control for the DynamicVentableCustomTile   
    }
}