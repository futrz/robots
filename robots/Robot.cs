using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robots
{
    class Robot : GameObject
    {
        public Robot()
        {
            symbol = "T";
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

        public void MoveTowardsPlayer(PathFinder path)
        {
            p = path.NextMove(p);
        }
    }
}
