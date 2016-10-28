//Derek Edwards
//MorgFactory: Makes morgs based on string array
//Factory Pattern
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MorgSim
{
    class MorgFactory: IMorgFactory
    {
        string[] parts;

        public MorgFactory(string [] morgParts)
        {
            parts = morgParts;
        }

        public Morg CreateMorg()
        {
            Morg m = new Morg();

            CreateType(m);
            CreateLocation(m);
            CreateMove(m);
            CreateFeed(m);
            CreateEdibles(m);

            return m;
        }

        public void CreateType(Morg m)
        {
            m.Type = parts[0];
        }

        public void CreateLocation(Morg m)
        {
            int xValue;
            int yValue;

            // Confirm that given X and Y values are valid and then set morg starting location
            if ((int.TryParse(parts[1], out xValue)) && (((Convert.ToInt32(parts[1])) >= 0) && ((Convert.ToInt32(parts[1])) < 50)))
            { xValue = Convert.ToInt32(parts[1]); }
            else { throw new Exception("Not a valid X Coordinate: " + parts[1]); }

            if ((int.TryParse(parts[2], out yValue)) && (((Convert.ToInt32(parts[2])) >= 0) && ((Convert.ToInt32(parts[2])) < 50)))
            { yValue = Convert.ToInt32(parts[2]); }
            else { throw new Exception("Not a valid Y Coordinate: " + parts[1]); }

            m.Location = new Point(xValue, yValue);
        }

        public void CreateMove(Morg m)
        {
            // Confirm that moveBehavior is valid and set
            if (parts[3] == "Paddles" || parts[3] == "paddles") { m.setMoveBehavior(new MovePaddle()); }
            else if (parts[3] == "Oozes" || parts[3] == "oozes") { m.setMoveBehavior(new MoveOoze()); }
            else { throw new Exception("Not a valid Movement Type: " + parts[3]); }
        }

        public void CreateFeed(Morg m)
        {
            // Confirm that FeedBehavior is valid and set
            if (parts[4] == "Absorbs" || parts[4] == "absorbs") { m.setFeedBehavior(new FeedAbsorb()); }
            else if (parts[4] == "Envelops" || parts[4] == "envelops") { m.setFeedBehavior(new FeedEnvelop()); }
            else { throw new Exception("Not a valid Feed Type: " + parts[4]); }
        }

        public void CreateEdibles(Morg m)
        {
            //Add Remaining values in string array 'parts' to List edibleMorgs
            for (int i = 5; i < parts.Length; i++) { if (parts[i] != null) { m.AddEdibleMorg(parts[i]); } }
        }
    }
}
