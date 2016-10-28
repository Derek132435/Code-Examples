//Derek Edwards
//MoveBehavior MoveOoze
//Strategy Pattern
using System;
using System.Drawing;

namespace MorgSim
{
    class MoveOoze : IMoveBehavior
    {
        //Ooze Movement always goes as specified
        public void move(ref Point location, int speed, string direction)
        {
            Point temp = location;

            if (direction == "Up" && location.Y + speed >= 0) { location.Offset(0, speed); }
            else if (direction == "Down" && location.Y - speed < 50) { location.Offset(0, -speed); }
            else if (direction == "Right" && location.X + speed < 50) { location.Offset(speed, 0); }
            else if (direction == "Left" && location.X - speed >= 0) { location.Offset(-speed, 0); }

            if(temp == location) { Console.WriteLine(" Bumped Into a Wall"); }
            else { Console.WriteLine(" Moved {0} Space(s) {1}", speed, direction); }
        }
    }
}