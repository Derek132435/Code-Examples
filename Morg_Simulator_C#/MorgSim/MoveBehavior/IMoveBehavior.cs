//Derek Edwards
//MoveBehavior Interface
//Strategy Pattern
using System.Drawing;

namespace MorgSim
{
    interface IMoveBehavior
    {
        void move(ref Point location, int speed, string direction);
    }
}
