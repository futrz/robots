using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace robots
{
    class Program
    {


        static void Main(string[] args)
        {
            Map map = new Map();
            map.Load("E:\\wlochate\\programowanie\\robots\\robots\\mapa.txt");

            PathFinder pathFinder = new PathFinder(map);

            int nRobots = 4;
            int i;
            int empty;

            GameObject[] gameObjects = new GameObject[100];

            i = 0;
            while(i < nRobots)
            {
                empty = Array.IndexOf(gameObjects, null);
                gameObjects[empty] = new Robot();
                gameObjects[empty].RadnomizePosition(map.GetWidth(), map.GetHeight());
                i++;
            }

            int nItems = 4;

            i = 0;
            while (i < nItems)
            {
                empty = Array.IndexOf(gameObjects, null);
                gameObjects[empty] = new Item();
                gameObjects[empty].RadnomizePosition(map.GetWidth(), map.GetHeight());
                i++;
            }

            Player player = new Player(5, 7);

            ConsoleKeyInfo b;
            player.SetSymbol("o");
            player.SetName("Blobcjusz");
            player.SetNumber(1);

            while (true)
            {
                Console.Clear();

                map.Draw();

                pathFinder.FindPathTo(player.p);
                pathFinder.Draw();

                i = 0;
                while (i < gameObjects.Length)
                {
                    if (gameObjects[i] != null)
                        gameObjects[i].Draw();
                    i++;
                }
               
                player.Draw();
                player.DrawStatus();

                Console.SetCursorPosition(0, Console.WindowHeight - 10);
                Console.Write("Znalezione rzeczy");
                i = 0;
                while (i < gameObjects.Length)
                {
                    if (gameObjects[i] != null && gameObjects[i].p.x == player.p.x && gameObjects[i].p.y == player.p.y)
                        Console.Write($"\n{gameObjects[i].symbol}");
                    i++;
                }

                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write($"{player.p.x} {player.p.y} {map.GetField(player.p.x, player.p.y)}");

                b = Console.ReadKey();
                
                if (b.Key == ConsoleKey.LeftArrow)
                    player.MoveBy(-1, 0, map);
                if (b.Key == ConsoleKey.RightArrow)
                    player.MoveBy(1, 0, map);
                if (b.Key == ConsoleKey.DownArrow)
                    player.MoveBy(0, 1, map);
                if (b.Key == ConsoleKey.UpArrow)
                    player.MoveBy(0, -1, map);

                i = 0;
                while (i < gameObjects.Length)
                {
                    if (gameObjects[i] != null && gameObjects[i] is Robot)
                    {
                        Robot r = (Robot)gameObjects[i];
                        r.MoveTowardsPlayer(pathFinder);
                    }
                    i++;
                }


                if (b.Key == ConsoleKey.Escape)
                {
                    break;
                }
                
                
            }
            
        }


    }

}
