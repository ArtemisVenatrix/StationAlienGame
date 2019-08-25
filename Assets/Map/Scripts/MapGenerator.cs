using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Map
{
    public class MapGenerator
    {
        private CustomTile[] tileArr;
        private Vector2Int size;
        private CustomTile[,] tiles;

        public MapGenerator(CustomTile[] tileArr, Vector2Int size)
        {
            this.size = size;
            this.tileArr = tileArr;
            tiles = new CustomTile[size.x,size.y];
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    tiles[x, y] = tileArr[0];
                }
            }
        }


        public CustomTile[,] GenerateRandomMap()
        {
            
            Random r = new Random(1337);
            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    int rnd = r.Next(0, 2);
                    if (rnd > 0)
                    {
                        tiles[x, y] = tileArr[1];
                    }
                    else
                    {
                        tiles[x, y] = tileArr[0];
                    }
                }
            }

            return tiles;
        }

        private bool PlaceRoomSafe(Room r)
        {
            if (r.radius >= 0)
            {
                if (r.Pos.y - r.radius >= 0 && r.Pos.y + r.radius < tiles.GetLength(0))
                {
                    if (r.Pos.x - r.radius >= 0 && r.Pos.x + r.radius < tiles.GetLength(1))
                    {
                        for (int y = 0; y < r.Tiles.GetLength(0); y++)
                        {
                            for (int x = 0; x < r.Tiles.GetLength(1); x++)
                            {
                                tiles[r.Pos.x + x, r.Pos.y + y] = r.Tiles[x, y];
                                return true;
                            }
                        }
                    }   
                }
            }
            else
            {
                Vector2Int q1 = new Vector2Int();
                q1.x = r.Tiles.GetLength(1) / 2;
                q1.y = r.Tiles.GetLength(0) / 2;
                
                Vector2Int q2 = new Vector2Int();
                q2.x = r.Tiles.GetLength(1) / 2;
                q2.y = r.Tiles.GetLength(0) / 2;
                if (r.Pos.y - q1.y >= 0 && r.Pos.y + q2.y < tiles.GetLength(0))
                {
                    if (r.Pos.x - q1.x >= 0 && r.Pos.x + q2.x < tiles.GetLength(1))
                    {
                        for (int y = 0; y < r.Tiles.GetLength(0); y++)
                        {
                            for (int x = 0; x < r.Tiles.GetLength(1); x++)
                            {
                                tiles[r.Pos.x + x, r.Pos.y + y] = tileArr[1];
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public CustomTile[,] MakeRooms(int numCircles)
        {
            Random r = new Random(1337);
            Room[] rooms = new Room[numCircles];
            for (int i = 0; i < numCircles; i++)
            {
                Vector2Int pos = new Vector2Int(r.Next(0, tiles.GetLength(0)), 
                                                r.Next(0, tiles.GetLength(1)));
                int radius = r.Next(0, 8);
                rooms[i] = new Room(pos, tileArr, new Vector2Int(radius, radius), 
                                                  new Vector2Int(radius, radius));
                Debug.Log(pos + ", " + radius + ", " + PlaceRoomSafe(rooms[i]));
            }

            tiles[0, 0] = tileArr[1];

            return tiles;
        }
    }

    public struct Room
    {
        public CustomTile[,] Tiles;
        public Vector2Int Pos;
        public int radius;
        /// <summary>
        /// This makes a circle
        /// </summary>
        /// <param name="pos">The center of the circle</param>
        /// <param name="radius">the radius of the circle</param>
        public Room(Vector2Int pos, int radius, CustomTile[] tileArr)
        {
            Pos = pos;
            Tiles = new CustomTile[radius, radius];
            this.radius = radius;
            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    if (Vector2Int.Distance(pos, new Vector2Int(x, y)) <= radius)
                    {
                        Tiles[x, y] = tileArr[1];
                    }
                    else
                    {
                        Tiles[x, y] = tileArr[0];
                    }
                }
            }
        }
        /// <summary>
        /// Makes a rectangular room
        /// </summary>
        /// <param name="pos"> center of room</param>
        /// <param name="q1"> the top left corner of the rectangle</param>
        /// <param name="q2"> the bottom right corner of the rectangle</param>
        public Room(Vector2Int pos, CustomTile[] tileArr, Vector2Int q1, Vector2Int q2)
        {
            Pos = pos;
            Tiles = new CustomTile[q2.x - q1.x, q2.y - q1.y];
            radius = -1;
            for (int y = 0; y < q2.y - q1.y; y++)
            {
                for (int x = 0; x < q2.x - q1.x; x++)
                {
                    Tiles[x, y] = tileArr[1];
                }
            }
        }
    }
}