using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIT_UBER_CL
{
    public class Rider
    {
        public int RiderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CreditCardInfo { get; set; }

        public Rider(int riderid, string firstname, string lastname, string creditcardinfo)
        {
            RiderID = riderid;
            FirstName = firstname;
            LastName = lastname;
            CreditCardInfo = creditcardinfo;
        }
    }
}
