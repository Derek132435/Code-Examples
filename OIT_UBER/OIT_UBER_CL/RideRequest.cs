using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIT_UBER_CL
{
    public class RideRequest
    {
        public int RequestID { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string DesiredTime { get; set; }

        public RideRequest(int requestid, string firstname,
            string street, string city, string zipcode, string desiredTime)
        {
            RequestID = requestid;
            FirstName = firstname;
            Street = street;
            City = city;
            Zipcode = zipcode;
            DesiredTime = desiredTime;
        }
    }
}
