using System.Collections;
using System.Collections.Generic;
using Map;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class MapManagerBehaviour : MonoBehaviour
{
    //public vars set by unity
    public int NumberOfLevels = 1;
    public float DistanceBetweenLayers = 5f;
    public Vector2Int MapSize = new Vector2Int(255, 255);
    [SerializeField] public CustomTile[] tiles;
     
    
    //These variables store the levels of the map, both their game objects and their componets
    private GameObject[] LevelsGameObjects;


    // Start is called before the first frame update
    void Start()
    {
        //sets the game world up for the new map
        
        //make levels and maps a new array of the correct size
        LevelsGameObjects = new GameObject[NumberOfLevels];

        //loop through and assign new instances
        for (int i = 0; i < NumberOfLevels; i++)
        {
            LevelsGameObjects[i] = MakeTilemap();
        }
    }
    
    /// <summary>
    /// Makes a new Tilemap, and assigns it all neccisary compenents 
    /// </summary>
    /// <returns>A made tilemap GameObject</returns>
    GameObject MakeTilemap()
    {
        GameObject go = new GameObject("Map_Level");
        go.transform.parent = transform;
        go.AddComponent<Tilemap>();
        go.AddComponent<TilemapRenderer>();
        go.AddComponent<MapBehaviour>();
        MapBehaviour tmp = go.GetComponent<MapBehaviour>();
        tmp.size = MapSize;
        tmp.tiles = tiles;
        return go;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
