//Derek Edwards
//Observer interface
//Observer pattern
using System.Drawing;

namespace MorgSim
{
    interface IObserver
    {
        void Update(Point preyLoc);
    }
}