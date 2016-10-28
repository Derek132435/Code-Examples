//Derek Edwards
//FeedBehavior FeedAbsorb
//Strategy Pattern
using System;
using System.Collections.Generic;
using System.Linq;

namespace MorgSim
{
    //Absorb behavior implementation, 50% chance of success
    class FeedAbsorb : IFeedBehavior
    {
        public void feed(ref bool feedSuccessful, string food, int chanceOfSuccess)
        {
            Console.WriteLine(" Attempts to Absorb: {0}...", food);
            int chance = chanceOfSuccess % 2;
            if (chance == 0)
            {
                Console.WriteLine("Successfully Absorbs: {0}!", food);
                feedSuccessful = true;
            }
            else { Console.WriteLine("Fails to Absorb: {0}...", food); }
        }
    }
}
