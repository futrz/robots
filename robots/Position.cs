using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
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
}
