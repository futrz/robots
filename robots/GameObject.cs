using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
    class GameObject
    {
        public string symbol;
        protected string name;
        public Position p = new Position(0, 0);

        public void SetPosition(Position newPosition)
        {
            p.x = newPosition.x;
            p.y = newPosition.y;
        }

        public void RadnomizePosition(int width, int height)
        {
            Position np = new Position(StaticRandom.Next(0, width - 1), StaticRandom.Next(0, height - 1));
            SetPosition(np);
        }

        public void Draw()
        {
            Console.SetCursorPosition(p.x, p.y);
            Console.Write(symbol);
        }
    }
}
