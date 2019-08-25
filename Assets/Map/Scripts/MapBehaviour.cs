using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    [RequireComponent(typeof(Tilemap))]
    public class MapBehaviour : MonoBehaviour
    {

        public Vector2Int size;
        public CustomTile[] tiles;
        
        //a refrence to the tilemap compent on the gameobject
        private Tilemap tilemap;
        Level map = new Level();
        public void Start()
        {
            //get the tilemap compenent
            tilemap = GetComponent<Tilemap>();
            //generate the map
            map.GenerateMap(size, tiles);
            SetTilemap(map);
        }
        
        //Update the tilemap
        public void SetTilemap(Level toSet)
        {
            for (int y = 0; y < toSet.Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < toSet.Tiles.GetLength(1); x++)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), toSet.Tiles[x, y].Asset);
                }
            }
        }
    }
}