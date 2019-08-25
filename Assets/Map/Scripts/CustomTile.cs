using UnityEngine;
using UnityEngine.Tilemaps;

namespace Map
{
    public class CustomTile : ScriptableObject
    {
        public Tile Asset;
        public float Damage;
        public bool IsVented;
        public bool IsVentable;
        
        public bool TryVent(int x, int y, ref CustomTile[ , ] map)
        {
            if (IsVentable)
            {
                bool isAirtight = true;
                for (int xOff = -1; xOff <= 1; xOff++)
                {
                    for (int yOff = -1; yOff <= 1; yOff++)
                    {
                        if (x + xOff >= 0 && x + xOff < map.GetLength(1))
                        {
                            if (y + yOff >= 0 && y + yOff < map.GetLength(0))
                            {
                                if (map[x + xOff, y + yOff].IsVentable && map[x + xOff, y + yOff].IsVented)
                                {
                                    isAirtight = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                return isAirtight;
            }

            return false;
        }
    }
}