//Derek Edwards
//FeedBehavior Interface
//Strategy Pattern
namespace MorgSim
{
    interface IFeedBehavior
    {
        void feed(ref bool feedSuccessful, string food, int chanceOfSuccess);
    }
}
