using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
    class PathFinder
    {
        int[][] distancesToTarget;
        Map map;

        public PathFinder(Map newMap)
        {
            map = newMap;

            distancesToTarget = new int[map.GetHeight()][];

            for (int y = 0; y < map.GetHeight(); y++)
                distancesToTarget[y] = new int[map.GetWidth()];
        }

        public void FindPathTo(Position target)
        {
            for (int x = 0; x < map.GetWidth(); x++)
                for (int y = 0; y < map.GetHeight(); y++)
                    distancesToTarget[y][x] = -1;
            distancesToTarget[target.y][target.x] = 0;

            int totalFieldsCount;
            int currentDistance = 0;
            do
            {
                totalFieldsCount = 0;
                for (int x = 0; x < map.GetWidth(); x++)
                {
                    for (int y = 0; y < map.GetHeight(); y++)
                    {
                        if (distancesToTarget[y][x] == currentDistance)
                            totalFieldsCount += FillSurrounding(x, y);
                    }
                }
                currentDistance++;
            } while (totalFieldsCount > 0);
        }

        int FillSurrounding(int centerX, int centerY)
        {
            int fieldsCount = 0;
            int newDistance = distancesToTarget[centerY][centerX] + 1;
            for (int x = centerX - 1; x <= centerX + 1; x++)
            {
                for (int y = centerY - 1; y <= centerY + 1; y++)
                {
                    if (x >= map.GetWidth() || x < 0)
                        continue;
                    if (y >= map.GetHeight() || y < 0)
                        continue;
                    if (distancesToTarget[y][x] != -1)
                        continue;
                    if (map.GetField(x, y) != '.')
                        continue;

                    distancesToTarget[y][x] = newDistance;
                    fieldsCount++;
                }
            }
            return fieldsCount;
        }

        public void Draw()
        {
            for (int y = 0; y < map.GetHeight(); y++)
            {
                for (int x = 0; x < map.GetWidth(); x++)
                    Console.Write(SymbolFor(distancesToTarget[y][x]));
                Console.WriteLine();
            }
        }

        public Position NextMove(Position start)
        {
            for (int x = start.x - 1; x <= start.x + 1; x++)
            {
                for (int y = start.y - 1; y <= start.y + 1; y++)
                {
                    if (x >= map.GetWidth() || x < 0)
                        continue;
                    if (y >= map.GetHeight() || y < 0)
                        continue;
                    if (distancesToTarget[start.y][start.x] > distancesToTarget[y][x] && distancesToTarget[y][x] != -1)
                        return new Position(x, y);
                }
            }

            return start;
        }

        char SymbolFor(int value)
        {
            if (value == -1)
                return '-';
            string value_string = value.ToString();
            return value_string[value_string.Length - 1];
        }
    }
}
