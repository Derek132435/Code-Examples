//Derek Edwards
//MorgFactory Interface
//Factory Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorgSim
{
    interface IMorgFactory
    {
        Morg CreateMorg();
        void CreateType(Morg m);
        void CreateLocation(Morg m);
        void CreateMove(Morg m);
        void CreateFeed(Morg m);
        void CreateEdibles(Morg m);
    }
}
