//Derek Edwards
//Petri Dish
//Arena for Morgs to fight in
using System;
using System.Collections.Generic;
using System.Threading;

namespace MorgSim
{
    class PetriDish
    {
        public List<Morg> allMorgs;

        public PetriDish()
        {
            allMorgs = new List<Morg>();
            int[,] board = new int[50, 50];
        }

        public void AddMorg(Morg aMorg) { allMorgs.Add(aMorg); }
        public void RemoveMorg(Morg deadMorg) { allMorgs.Remove(deadMorg); }

        public void Step(Morg m)
        {
            if (!m.IsDead)
            {
                Search(m);
                m.PerformMove();
                m.PerformFeed();
                m.NotifyObservers();
            }  
        }

        public void Search(Morg m)
        {
            foreach (Morg morg in allMorgs)
            {
                if (((m.Location.X - morg.Location.X) <= 10) && ((m.Location.Y - morg.Location.Y) <= 10))
                {
                    m.setPrey(morg);
                }
            }
        }

        public void SuddenDeathSearch(Morg m)
        {
            foreach (Morg morg in allMorgs)
            {
                m.setPrey(morg);
            }
        }
    }
}
