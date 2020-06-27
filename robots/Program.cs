﻿using System;
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

            PathFinder path_finder = new PathFinder(map);

            int nRobots = 4;
            int i;

            Robot[] robots = new Robot[nRobots];

            i = 0;
            while(i < nRobots)
            {
                robots[i] = new Robot();
                robots[i].RadnomizePosition(map.GetWidth(), map.GetHeight());
                i++;
            }

            Player[] players = new Player[2];
            players[0] = new Player(5, 7);
            players[1] = new Player( 7, 7);

            ConsoleKeyInfo b;
            players[0].SetSymbol("o");
            players[0].SetName("Blobcjusz");
            players[0].SetNumber(1);

            players[1].SetSymbol("O");
            players[1].SetName("Blobtycja");
            players[1].SetNumber(2);


            while (true)
            {
                Console.Clear();

                map.Draw();

                path_finder.FindPathTo(players[0].p);
                path_finder.Draw();

                i = 0;
                while (i < nRobots)
                {
                    robots[i].Draw();
                    i++;
                }

                players[0].Draw();
                players[0].DrawStatus();
                players[1].Draw();
                players[1].DrawStatus();

                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                Console.Write($"{players[0].p.x} {players[0].p.y} {map.GetField(players[0].p.x, players[0].p.y)}");

                b = Console.ReadKey();
                
                if (b.Key == ConsoleKey.LeftArrow)
                    players[0].MoveBy(-1, 0, map);
                if (b.Key == ConsoleKey.RightArrow)
                    players[0].MoveBy(1, 0, map);
                if (b.Key == ConsoleKey.DownArrow)
                    players[0].MoveBy(0, 1, map);
                if (b.Key == ConsoleKey.UpArrow)
                    players[0].MoveBy(0, -1, map);

                if (b.Key == ConsoleKey.A)
                    players[1].MoveBy(-1, 0, map);
                if (b.Key == ConsoleKey.D)
                    players[1].MoveBy(1, 0, map);
                if (b.Key == ConsoleKey.W)
                    players[1].MoveBy(0, -1, map);
                if (b.Key == ConsoleKey.S)
                    players[1].MoveBy(0, 1, map);

                i = 0;
                while (i < nRobots)
                {
                    robots[i].MoveTowardsPlayer(path_finder);
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
