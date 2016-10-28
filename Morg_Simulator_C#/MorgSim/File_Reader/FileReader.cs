//Derek Edwards
//FileReader: opens a file and reads a line from it
//Decorator Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MorgSim
{
    class FileReader : Reader
    {
        private StreamReader streamReader;

        //Attempt to open a file
        public FileReader(string fileName)
        {
            streamReader = System.IO.File.OpenText(fileName);
            if (streamReader == null) { throw new Exception("OpenRead() failed for file " + fileName); }
        }

        // get and return a single line of text
        public override string Read() { return streamReader.ReadLine(); }

        public override void Close() { streamReader.Close(); }
    }
}
