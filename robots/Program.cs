using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
    class Robot
    {
        int X = 0;
        int Y = 0;

        public void SetPosition(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }

        public void RadnomizePosition()
        {
            Random rnd = new Random();
            SetPosition(rnd.Next(1, 80), rnd.Next(1, 25));
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("T");
        }
    }

    class Player
    {
        int X = 10;
        int Y = 10;
        public int Moves = 0;

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            if (Moves > 10)
                Console.Write("ó");
            else
                Console.Write("o");
        }

        public void MoveBy(int dX,  int dY)
        {
            X = X + dX;
            Y = Y + dY;

            if (X < 0)
            {
                X = 0;
            }

            if (X > Console.WindowWidth - 1)
            {
                X = Console.WindowWidth - 1;
            }

            if (Y < 0)
            {
                Y = 0;
            }

            if (Y > Console.WindowHeight - 2)
            {
                Y = Console.WindowHeight - 2;
            }

            Moves = Moves + Math.Abs(dX) + Math.Abs(dY);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        
            ConsoleKeyInfo b;
            Robot r1 = new Robot();
            r1.SetPosition(5, 5);
            Robot r2 = new Robot();
            r2.RadnomizePosition();
            Player p1 = new Player();
            

            while (true)
            {
                Console.Clear();
                p1.Draw();
                r1.Draw();
                r2.Draw();
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Bieganie: " + p1.Moves);

                b = Console.ReadKey();
                
                if (b.Key == ConsoleKey.LeftArrow)
                {
                    p1.MoveBy(-1, 0);
                }
                if (b.Key == ConsoleKey.RightArrow)
                {
                    p1.MoveBy(1, 0);
                }
                if (b.Key == ConsoleKey.DownArrow)
                {
                    p1.MoveBy(0, 1);
                }
                if (b.Key == ConsoleKey.UpArrow)
                {
                    p1.MoveBy(0, -1);
                }

               // if (PlayerX < 0)
                //{
                //    PlayerX = 0;
               // }

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
