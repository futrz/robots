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

            List<GameObject> gameObjects = new List<GameObject>();

            i = 0;
            while(i < nRobots)
            {
                Robot r = new Robot();
                r.RadnomizePosition(map.GetWidth(), map.GetHeight());
                gameObjects.Add(r);
                i++;
            }

            int nItems = 4;

            i = 0;
            while (i < nItems)
            {
                Item it = new Item();
                it.RadnomizePosition(map.GetWidth(), map.GetHeight());
                gameObjects.Add(it);
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

                foreach(GameObject go in gameObjects)
                    go.Draw();
                
                player.Draw();
                player.DrawStatus();

                Console.SetCursorPosition(0, Console.WindowHeight - 10);
                Console.Write("Znalezione rzeczy");

                foreach (GameObject go in gameObjects)
                {
                    if (go.p.x == player.p.x && go.p.y == player.p.y)
                        Console.Write($"\n{go.symbol}");
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

                foreach (GameObject go in gameObjects)
                {
                    if (go is Robot)
                    {
                        Robot r = (Robot)go;
                        r.MoveTowardsPlayer(pathFinder);
                    }
                }


                if (b.Key == ConsoleKey.Escape)
                {
                    break;
                }
                
                
            }
            
        }


    }

}
