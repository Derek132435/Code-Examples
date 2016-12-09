using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OIT_UBER_CL
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string FirstName { get; set; }
        public string LicensePlate { get; set; }
        public string CarType { get; set; }

        public Driver(int driverid, string firstname, string licenseplate, string cartype)
        {
            DriverID = driverid;
            FirstName = firstname;
            LicensePlate = licenseplate;
            CarType = cartype;
        }
    }
}
