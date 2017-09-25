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

    class Program
    {
        static void Main(string[] args)
        {
            int PlayerX = 10;
            int PlayerY = 10;
            ConsoleKeyInfo b;
            int Licznik = 0;
            int LicznikP = 0;
            Robot r1 = new Robot();
            r1.SetPosition(5, 5);
            Robot r2 = new Robot();
            r2.RadnomizePosition();

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.Write("o");
                r1.Draw();
                r2.Draw();
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.Write("Bieganie w prawo albo w dol: " + LicznikP);
                Console.Write(" | Bieganie gdziekolwiek: " + Licznik);

                b = Console.ReadKey();
                
                if (b.Key == ConsoleKey.LeftArrow && PlayerX > 0)
                {
                    PlayerX--;
                    Licznik++;
                }
                if (b.Key == ConsoleKey.RightArrow && PlayerX < Console.WindowWidth - 1)
                {
                    PlayerX++;
                    Licznik++;
                    LicznikP++;
                }
                if (b.Key == ConsoleKey.DownArrow && PlayerY < Console.WindowHeight - 2)
                {
                    PlayerY++;
                    Licznik++;
                    LicznikP++;
                }
                if (b.Key == ConsoleKey.UpArrow && PlayerY > 0)
                {
                    PlayerY--;
                    Licznik++;
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
