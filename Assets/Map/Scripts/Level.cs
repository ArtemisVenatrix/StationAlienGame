using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Map
{
    public class Level
    {
        //made this more unity like
        public CustomTile[,] Tiles;

        public void GenerateMap(Vector2Int size, CustomTile[] tileArr)
        {
            MapGenerator mg = new MapGenerator(tileArr, size);
            Tiles = mg.MakeRooms(10) ;
        }
        
        public void Vent(int start_x, int start_y)
        {
            for (int y = 0; y < Tiles.GetLength(0); y++)
            {
                for (int x = 0; x < Tiles.GetLength(1); x++)
                {
                    if (!IsTileAirtight(x, y))
                    {
                        Tiles[x, y].IsVented = true;
                    }
                }
            }
        }

        public bool IsTileAirtight(int x, int y)
        {
            bool hasVentedNeighbor = false;
            for (int xOff = -1; xOff <= 1; xOff++)
            {
                for (int yOff = -1; yOff <= 1; yOff++)
                {
                    if (x + xOff >= 0 && x + xOff < Tiles.GetLength(1))
                    {
                        if (y + yOff >= 0 && y + yOff < Tiles.GetLength(0))
                        {
                            if (Tiles[x + xOff, y + yOff].TryVent(x, y, ref Tiles))
                            {
                                hasVentedNeighbor = true;
                                break;
                            }
                        }
                    }
                }
            }

            return hasVentedNeighbor;
        }
    }
}