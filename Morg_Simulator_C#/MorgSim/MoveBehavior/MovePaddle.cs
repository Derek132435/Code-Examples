//Derek Edwards
//MoveBehavior MovePaddle
//Strategy Pattern
using System;
using System.Drawing;

namespace MorgSim
{
    class MovePaddle : IMoveBehavior
    {
        //Paddle Movement Moves Slightly Quicker Than Speed Or Fails
        public void move(ref Point location, int speed, string direction)
        {
            Point temp = location;
            int impSpeed = speed + 2;

            Random rnd = new Random();
            if(rnd.Next(1, 4) > 1)
            {
                if (direction == "Up" && location.Y + impSpeed >= 0) { location.Offset(0, impSpeed); }
                else if (direction == "Down" && location.Y - impSpeed <= 50) { location.Offset(0, -impSpeed); }
                else if (direction == "Right" && location.X + impSpeed <= 50) { location.Offset(impSpeed, 0); }
                else if (direction == "Left" && location.X - impSpeed >= 0) { location.Offset(-impSpeed, 0); }

                if (temp == location) { Console.WriteLine(" Bumped Into a Wall"); }
                else { Console.WriteLine(" Paddled Quickly {0} Space(s) {1}", impSpeed, direction); }
            }
            else { Console.WriteLine(" Tried to Paddle Quickly But Fell On Its Face"); }
        }
    }
}