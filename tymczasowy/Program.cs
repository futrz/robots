using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tymczasowy
{
    class Player
    {
        string symbol;
        string name;
        Position p;
        Position statusPosition;
        public int count = 0;
        public void MoveBy(int dx, int dy)
        {
            p.MoveBy(dx, dy);
            count = count + 1;
        }
        public Player(int sx, int sy)
        {
            p = new Position(sx, sy);
            statusPosition = new Position();
        }
        public void Draw()
        {
            Console.SetCursorPosition(p.x, p.y);
            Console.Write(symbol);
        }
        public void DrawStatus()
        {
            Console.SetCursorPosition(statusPosition.x, statusPosition.y);
            Console.Write($"{name}: [{p.x}, {p.y}] {count}");
        }
        public void SetName(string newName)
        {
            name = newName;
        }
        public void SetSymbol(string newSymbol)
        {
            symbol = newSymbol;
        }
        public void SetStatusPosition(int statusx, int statusy)
        {
            statusPosition.x = statusx;
            statusPosition.y = statusy;
        }
    }
    class Position
    {
        public int x;
        public int y;
        public Position(int sx, int sy)
        {
            x = sx;
            y = sy;
        }
        public Position() {}
        public void MoveBy(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo b;
            
            Player player = new Player(5, 7);
            player.SetSymbol("o");
            player.SetStatusPosition(1, 20);
            player.SetName("Blobcjusz");
            Player player2 = new Player(3, 2);
            player2.SetSymbol("O");
            player2.SetStatusPosition(40, 20);
            player2.SetName("Blobtycja");


            while (true)
            {
                Console.Clear();
                player.Draw();
                player2.Draw();
                player.DrawStatus();
                player2.DrawStatus();
                b = Console.ReadKey();
                if (b.Key == ConsoleKey.LeftArrow)
                    player.MoveBy(-1, 0);
                if (b.Key == ConsoleKey.RightArrow)
                    player.MoveBy(1, 0);
                if (b.Key == ConsoleKey.UpArrow)
                    player.MoveBy(0, -1);
                if (b.Key == ConsoleKey.DownArrow)
                    player.MoveBy(0, 1);

                if (b.Key == ConsoleKey.A)
                    player2.MoveBy(-1, 0);
                if (b.Key == ConsoleKey.D)
                    player2.MoveBy(1, 0);
                if (b.Key == ConsoleKey.W)
                    player2.MoveBy(0, -1);
                if (b.Key == ConsoleKey.S)
                    player2.MoveBy(0, 1);
                

                if (b.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        static void NapiszCzasem(int a)
        {
            if (a > 4)
                Console.WriteLine(a);
            else
                Console.WriteLine(-a);
        }

        static int Zwieksz(int a)
        {
            a = a + 1;
            return a;
        }

        static int Osiem()
        {
            return 8;
        }

        static void Napisz(string tekst)
        {
            Console.WriteLine(tekst);
        }

        static void Napisz(int liczba)
        {
            string zamienione = liczba.ToString();
            Console.WriteLine(zamienione);
        }

        static void NapiszWiecej(int wiecejcyferek)
        {
            int niebardzowiadomoco = wiecejcyferek + 1;
            Napisz(niebardzowiadomoco);
        }

        static void Schowek()
        {
            string cos = "jakies cokolwiek";
            Console.WriteLine(cos);
            cos = "jakis inny napis";
            Console.WriteLine(cos);
            Console.WriteLine("cos");
            Napisz("abc");
            Napisz("def");
            int numerek = 7;
            Console.WriteLine(numerek);
            Napisz(numerek);
            NapiszWiecej(numerek);
            Console.ReadKey();
            //int cyferka = 3;
            //cyferka = Zwieksz(cyferka) + Zwieksz(cyferka);
            //Console.WriteLine(cyferka);
            NapiszCzasem(3);
            NapiszCzasem(7);

            int i;
            i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }

            for (i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        // pokazać zwracanie wartości
    }
}
