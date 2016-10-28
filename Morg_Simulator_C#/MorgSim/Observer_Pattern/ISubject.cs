//Derek Edwards
//Subject interface
//Observer pattern
namespace MorgSim
{
    interface ISubject
    {
        void RegisterObserver(Morg pred);
        void RemoveObserver(Morg pred);
        void NotifyObservers();
    }
}
