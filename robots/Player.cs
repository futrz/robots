using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
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

        public void MoveBy(int dx, int dy, Map map)
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

            if (map.GetField(newPosition.x, newPosition.y) == '.')
                p = newPosition;

            count = count + Math.Abs(dx) + Math.Abs(dy);
        }
    }
}
