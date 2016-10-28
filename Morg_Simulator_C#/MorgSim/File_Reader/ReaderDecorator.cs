//Derek Edwards
//ReaderDecorator
//Decorator Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSim
{
    abstract class ReaderDecorator : Reader
    {
        private Reader wrappedReader;

        protected ReaderDecorator(Reader wrapped) { wrappedReader = wrapped; }

        protected Reader Wrapped { get { return wrappedReader; } }
    }
}
