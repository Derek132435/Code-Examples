//Derek Edwards
//Morg Superclass
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MorgSim
{
    class Morg : IObserver, ISubject
    {
        //Member Variables
        private IMoveBehavior moveBehavior;
        private IFeedBehavior feedBehavior;
        private List<Morg> predators;
        private List<string> edibleMorgs;
        private Point location;
        private Morg prey;
        private Point preyLocation;
        private bool hasPrey = false;
        private bool feedSuccessful = false;
        private bool isDead = false;
        private string direction;
        private int speed = 0;
        private string type;
        private List<int> randomNumbers;

        //Remove the first number after each use of list
        public void RemoveRandomNumber() { randomNumbers.RemoveAt(0); }

        //add Morg to edible Morg List
        public void AddEdibleMorg(string aMorgType) { edibleMorgs.Add(aMorgType); }

        //Get/Set Functions
        public bool IsDead { get { return isDead; } set { isDead = value; } }
        public string Type { get { return type; } set { type = value; } }
        public Point Location { get { return location; } set { location = value; } }

        public void preyDead()
        {
            hasPrey = false;
            prey = null;
        }

        //Morg Constructor
        public Morg()
        {
            //Create Predator List
            predators = new List<Morg>();
            edibleMorgs = new List<string>();
            randomNumbers = new List<int>();
            randomNumbers.AddRange(Enumerable.Range(0, 2000).OrderBy(x => Guid.NewGuid()).Take(450));

            //Choose Random Spawn Location
            int X = randomNumbers[0] % 50;
            RemoveRandomNumber();
            int Y = randomNumbers[0] % 50;
            RemoveRandomNumber();
            location = new Point(X, Y);

            //Set random speed 1-4
            int morgSpeed = randomNumbers[0] % 5;
            RemoveRandomNumber();
            if (morgSpeed != 0) { speed = morgSpeed; }
            else { speed = 1; }
        }

        //Move/Feed Behavior Set and Perform Functions
        public void setMoveBehavior(IMoveBehavior move) { moveBehavior = move; }
        public void setFeedBehavior(IFeedBehavior feed) { feedBehavior = feed; }

        //if has prey, move towards it, otherwise move randomly
        public void PerformMove()
        {
            if (hasPrey) { Console.WriteLine("{0} Attempts to Move Towards {1}", type, prey.Type); }
            else { Console.WriteLine("{0} Attempts to Move Randomly {1}...", type, direction); }
            Console.Write(type);
            moveBehavior.move(ref location, speed, direction);

            //If Morg does not have prey, call update to assign a random direction
            if(!hasPrey) { Update(preyLocation); }
        }


        //if has prey, prey is close, and prey is not already dead, try to eat it
        public void PerformFeed()
        {
            if (hasPrey)
            {
                if (((location.X - preyLocation.X) <= 2) && ((location.Y - preyLocation.Y) <= 2) && (!prey.IsDead))
                {
                    Console.Write(type);
                    feedBehavior.feed(ref feedSuccessful, prey.Type, randomNumbers[0]);
                    RemoveRandomNumber();
                    if (feedSuccessful)
                    {
                        prey.IsDead = true;
                        foreach (Morg morg in prey.predators)
                        {
                            morg.preyDead();
                        }
                        feedSuccessful = false;
                    }
                }
            }
        }


        //ISubject Interface Implementation
        public void RegisterObserver(Morg pred) { predators.Add(pred); }
        public void RemoveObserver(Morg pred) { predators.Remove(pred); }
        //Send Current Location To all Predators
        public void NotifyObservers() { foreach (Morg pred in predators) { pred.Update(location); } }


        //IObserver Interface Implementation
        public void Update(Point preyLoc)
        {
            //Receive Prey's Location From Prey and Set preyLocation and direction Variables
            preyLocation = preyLoc;
            if (hasPrey)
            {
                if (location.Y < preyLocation.Y) { direction = "Up"; }
                else if (location.Y > preyLocation.Y) { direction = "Down"; }
                else if (location.X < preyLocation.X) { direction = "Right"; }
                else { direction = "Left"; }
            }
            else
            {
                int dir = randomNumbers[0] % 4;
                RemoveRandomNumber();
                if (dir == 3) { direction = "Up"; }
                else if (dir == 2) { direction = "Down"; }
                else if (dir == 1) { direction = "Left"; }
                else { direction = "Right"; }
            }
        }

        public void setPrey(Morg thePrey)
        {
            if ((this != thePrey) && (!hasPrey) && (!thePrey.IsDead))
            {
                foreach (string preyType in edibleMorgs)
                {
                    if(preyType == thePrey.Type)
                    {
                        hasPrey = true;
                        prey = thePrey;
                        thePrey.RegisterObserver(this);
                        Console.WriteLine("{0} Has Been Spotted By {1}", thePrey.Type, type);
                    }
                }
            }
        }
    }
}
