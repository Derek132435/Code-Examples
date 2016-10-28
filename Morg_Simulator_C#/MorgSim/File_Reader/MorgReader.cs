//Derek Edwards
//MorgReader: Splits string read by FileReader and Calls Factory
//Decorator Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MorgSim
{
    class MorgReader : ReaderDecorator
    {
        public MorgReader(Reader wrapped) : base(wrapped)
        {
        }

        public override string Read() { return Wrapped.Read(); }

        public override void Close() { Wrapped.Close(); }

        public Morg ReadMorg()
        {
            // Read input file line and extract values into string array as Morg parts
            string line = Wrapped.Read();
            if (line != null)
            {
                char[] delimiters = new char[] { ',', ' ' };
                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                MorgFactory mFactory = new MorgFactory(parts);

                return mFactory.CreateMorg();
            }
            else { return null; }
        }
    }
}
