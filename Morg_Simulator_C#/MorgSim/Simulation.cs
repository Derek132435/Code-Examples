//Derek Edwards
/*------------------------------------------------------------------------------------------------------
SIMULATION RULES:
Simulation runs through up to 200 cycles of Morgs hunting/eating each other
After 150 cycles, if simulation is not done, SuddenDeathSearch is called, informing all Morgs of all other morgs
If a Morg is the last alive, it is declared te victor
If any prey evades predators for full 200 cycles, it is declared the victor
--------------------------------------------------------------------------------------------------------*/
using System;
using System.Linq;

namespace MorgSim
{
    class Simulation
    {
        private PetriDish Arena;

        public Simulation()
        {
            Arena = new PetriDish();

            //Opens a file and reads morgs from it line by line until end
            MorgReader reader = new MorgReader(new FileReader("Morgs.txt"));
            Morg m = reader.ReadMorg();

            //Read a line from file, convert to a Morg, Add morg to allMorgs list
            while (m != null)
            {
                Arena.AddMorg(m);
                m = reader.ReadMorg();
            }
            reader.Close();
            
            for (int i = 0; i < 200; i++)
            {
                foreach (Morg morg in Arena.allMorgs.ToList())
                {
                    //if simulation runs too long...SUDDEN DEATH COMBAT!!! (Lets all morgs know where all other morgs are)
                    if (i >= 150) { Arena.SuddenDeathSearch(morg); }

                    if (Arena.allMorgs.Count() <= 1) { break; }
                    if (morg.IsDead) { Arena.RemoveMorg(morg); }
                    Arena.Step(morg);
                }
            }
            Console.WriteLine("{0} Is Victorious!", Arena.allMorgs.First().Type);
        }
    }
}