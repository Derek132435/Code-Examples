//Derek Edwards
//FeedBehavior FeedEnvelop
//Strategy Pattern
using System;
using System.Collections.Generic;
using System.Linq;

namespace MorgSim
{
    //Envelop behavior implementation, 75% chance of success
    class FeedEnvelop : IFeedBehavior
    {
        public void feed(ref bool feedSuccessful, string food, int chanceOfSuccess)
        {
            Console.WriteLine(" Attempts to Envelop {0}...", food);
            int chance = chanceOfSuccess % 4;
            if (chance > 0)
            {
                Console.WriteLine("Successfully Envelops {0}!", food);
                feedSuccessful = true;
            }
            else { Console.WriteLine("Fails to Envelop {0}...", food); }
        }
    }
}