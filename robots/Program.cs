using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace robots
{
    public static class StaticRandom
    {
        private static int seed;

        private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref seed)));

        static StaticRandom()
        {
            seed = Environment.TickCount;
        }

        public static Random Instance { get { return threadLocal.Value; } }
        public static int Next(int min, int max) { return Instance.Next(min, max); }
    }

    class Robot
    {
        public Position p = new Position(0, 0);

        public void SetPosition(Position newPosition)
        {
            p.x = newPosition.x;
            p.y = newPosition.y;
        }

        public void RadnomizePosition()
        {
            Position np = new Position(StaticRandom.Next(1, 80), StaticRandom.Next(1, 24));
            SetPosition(np);
        }

        public void Draw()
        {
            Console.SetCursorPosition(p.x, p.y);
            Console.Write("T");
        }

        public void MoveTowards(Position destination)
        {
            if (p.x < destination.x)
                p.x++;
            if (p.x > destination.x)
                p.x--; 
            if (p.y < destination.y)
                p.y++;
            if (p.y > destination.y)
                p.y--;
        }

        public void MoveTowardsPlayer(Player player, Player player2)
        {
            if (player.p.DistanceTo(p) > player2.p.DistanceTo(p))
                MoveTowards(player2.p);
            else
                MoveTowards(player.p);
        }
    }

    class Player
    {
        public int count = 0;
        string symbol;
        string name;
        int number;
        public Position p;

        public Player(int sx, int sy)
        {
            p = new Position(sx, sy);
        }
        public void Draw()
        {
            Console.SetCursorPosition(p.x, p.y);
            Console.Write(symbol);
        }
        public void DrawStatus()
        {
            int statusX;
            string status = $"{name}: [{p.x}, {p.y}] {count}";
            if (number == 1)
                statusX = 1;
            else
                statusX = Console.WindowWidth - status.Length - 1;
            Console.SetCursorPosition(statusX, Console.WindowHeight - 1);
            Console.Write(status);
        }
        public void SetNumber(int newNumber)
        {
            number = newNumber;
        }
        public void SetName(string newName)
        {
            name = newName;
        }
        public void SetSymbol(string newSymbol)
        {
            symbol = newSymbol;
        }

        public void MoveBy(int dx,  int dy, Map map)
        {
            Position newPosition = new Position(p);
            newPosition.x += dx;
            newPosition.y += dy;

            if (newPosition.x < 0)
                newPosition.x = 0;
            if (newPosition.x > Console.WindowWidth - 1)
                newPosition.x = Console.WindowWidth - 1;
            if (newPosition.y < 0)
                newPosition.y = 0;
            if (newPosition.y > Console.WindowHeight - 2)
                newPosition.y = Console.WindowHeight - 2;

            if (map.GetField(newPosition.x, newPosition.y) == ' ')
                p = newPosition;

            count = count + Math.Abs(dx) + Math.Abs(dy);
        }
    }

    class Position
    {
        public int x;
        public int y;
        public Position(int startX, int startY)
        {
            x = startX;
            y = startY;
        }
        public Position() { }
        public Position(Position position)
        {
            x = position.x;
            y = position.y;
        }
        public int DistanceTo(Position position)
        {                  
            return Math.Abs(x - position.x) + Math.Abs(y - position.y);
        }
    }

    class Program
    {


        static void Main(string[] args)
        {
            Map map = new Map();
            map.Load("C:\\wlochate\\programowanie\\robots\\robots\\mapa.txt");

            int nRobots = 4;
            int i;

            Robot[] robots = new Robot[nRobots];

            i = 0;
            while(i < nRobots)
            {
                robots[i] = new Robot();
                robots[i].RadnomizePosition();
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
                    robots[i].MoveTowardsPlayer(players[0], players[1]);
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
