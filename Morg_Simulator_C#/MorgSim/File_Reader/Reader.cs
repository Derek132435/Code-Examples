//Derek Edwards
//Reader interface
//Decorator Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSim
{
    abstract class Reader
    {
        abstract public string Read();
        abstract public void Close();
    }
}
