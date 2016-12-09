using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace OIT_UBER_CL
{
    public class PullDatabase
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=OIT_Uber;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public PullDatabase()
        {

        }

        public ArrayList GetRideRequests()//Completed
        {
            ArrayList requests = new ArrayList();


            // Create the connection to the resource!
            // This is the connection, that is established and
            // will be available throughout this block.
            using (SqlConnection conn = new SqlConnection())
            {
                // Create the connectionString
                // Trusted_Connection is used to denote the connection uses Windows Authentication
                conn.ConnectionString = connectionString;
                conn.Open();

                // Create the command
                String strCmd = "SELECT R.RequestID, I.FirstName, R.Street,Z.City,Z.ZipCode,R.timeneeded FROM Requests AS R Join Riders as I On I.RiderID = R.RiderID join ZipCodes As Z ON Z.ZipCode = R.ZipCode WHERE R.RequestID NOT IN(select R.RequestID from DriverRequests AS DR jOIN Requests as R ON DR.RequestID = R.RequestID)";
                SqlCommand command = new SqlCommand(strCmd, conn);
                // Add the parameters.
                // command.Parameters.Add(new SqlParameter("0", 1));

                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    while (dbReader.Read())
                    {

                        RideRequest request;


                        request = new RideRequest
                                (Convert.ToInt32(dbReader["RequestID"]), dbReader["FirstName"].ToString(), dbReader["Street"].ToString(), dbReader["City"].ToString(), dbReader["ZipCode"].ToString(), dbReader["timeneeded"].ToString());

                        requests.Add(request);
                    }
                    dbReader.Close();
                }

                conn.Close();
            }
            return requests;
        }

        public int AddRiderData(string firstName, string lastName, string creditCardInfo)//Completed
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                int ridernumber = -1;//error code gets changed if not in database


                //Rider INSERT
                //check if the Rider exists in the database
                String strCmd = "SELECT RiderID FROM Riders AS C WHERE C.FirstName='" + firstName + "' AND C.LastName ='" + lastName + "'";
                SqlCommand command = new SqlCommand(strCmd, conn);
                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    if (!dbReader.HasRows)//if there is no returns
                    {
                        dbReader.Close();
                        strCmd = "INSERT INTO Riders(FirstName,LastName,creditcardnumber) VALUES ('" + firstName + "','" + lastName + "','" + creditCardInfo + "')";
                        command = new SqlCommand(strCmd, conn);
                        command.ExecuteNonQuery();
                        
                        strCmd = "SELECT RiderID FROM Riders AS C WHERE C.FirstName='" + firstName + "' AND C.LastName ='" + lastName + "'";//get the auto generated number
                        command = new SqlCommand(strCmd, conn);
                        using (SqlDataReader retreader = command.ExecuteReader())//always returns a single row
                        {
                            if (retreader.Read())
                            ridernumber = Convert.ToInt32(retreader["RiderID"]);
                            retreader.Close();
                        }

                        return ridernumber;
                    }



                    else//if it returns they are already in the database
                    {
                        return ridernumber;
                    }
                }
            }
        }

        public int AddDriverData(string firstName, string lastName, string licensePlate, string carType)//Completed
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();


                int drivernumber = -1;
                //Driver Insert
                //check if the driverexists in the database
                String strCmd = "SELECT DriverID FROM Drivers AS C WHERE C.FirstName='" + firstName + "' AND C.LastName ='" + lastName + "'";
                SqlCommand command = new SqlCommand(strCmd, conn);
                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    if (!dbReader.HasRows)//if there is no returns
                    {
                        dbReader.Close();//close reader
                        strCmd = "INSERT INTO Drivers(FirstName,LastName,licenseplate,VehicleType) VALUES ('" + firstName + "','" + lastName + "','" + licensePlate + "','" + carType + "')";
                        command = new SqlCommand(strCmd, conn);
                        command.ExecuteNonQuery();//Insert into table

                        strCmd = "SELECT DriverID FROM Drivers AS C WHERE C.FirstName='" + firstName + "' AND C.LastName ='" + lastName + "'";//command to get ID #
                        command = new SqlCommand(strCmd, conn);
                        using (SqlDataReader retReader = command.ExecuteReader())
                        {
                            if (retReader.Read())
                            {
                                drivernumber = Convert.ToInt32(retReader["DriverID"]);
                                retReader.Close();
                            }
                        }
                        return drivernumber;//hits this point should be a valid ID
                    }



                    else//if it returns they are already in the database
                    {
                        return drivernumber;//can't enter into database
                    }
                }
            }
        }

        public bool AddRideRequest(int riderid, string firstname, string lastname, string street, string city, string zip, int time)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                //Driver Insert
                //check if the driverexists in the database
                String strCmd = "SELECT RiderID FROM Riders AS C WHERE C.FirstName='" + firstname + "' AND C.LastName ='" + lastname + "' AND C.RiderID='" + riderid + "'";
                SqlCommand command = new SqlCommand(strCmd, conn);
                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    if (!dbReader.HasRows)//if there is no returns
                    {
                        dbReader.Close();//close reader
                        return false;//return cause that is not a valid rider
                    } else
                        dbReader.Close();
                    strCmd = "Select ZipCode FROM ZipCodes where zipcode ='" + zip + "'";
                    command = new SqlCommand(strCmd, conn);
                    using (SqlDataReader zipReader = command.ExecuteReader())
                    {
                        if (!zipReader.Read())//zip code does not exist
                        {
                            zipReader.Close();
                            strCmd = "Insert INTO ZipCodes(ZipCode,City) VALUES('" + zip + "','" + city + "')";
                            command = new SqlCommand(strCmd, conn);
                            command.ExecuteNonQuery();
                        }
                        else//zip code exists
                        {
                            dbReader.Close();
                        }
                        DateTime pickuptime = DateTime.Now;
                        pickuptime.AddMinutes(time);
                        strCmd = "INSERT INTO Requests(RiderID,Street,ZipCode,Completed,timeneeded) VALUES (" + riderid + ",'" + street + "','" + zip + "','NO','" + pickuptime.ToString("yyyy-MM-dd hh:mm:ss") + "')";
                        command = new SqlCommand(strCmd, conn);
                        command.ExecuteNonQuery();//Insert into table
                        return true;
                    }
 
                }


            }
        }

        public bool AcceptRideRequest(int driverID, int requestID, string ETA)//Completed
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();



                //Driver Insert
                //check if the driverexists in the database
                String strCmd = "SELECT RequestID FROM DriverRequests AS C WHERE C.DriverID='" + driverID + "' AND C.RequestID ='" + requestID + "'";
                SqlCommand command = new SqlCommand(strCmd, conn);
                using (SqlDataReader dbReader = command.ExecuteReader())
                {
                    if (!dbReader.HasRows)//if there is no returns
                    {
                        dbReader.Close();
                        strCmd = "INSERT INTO DriverRequestS(DriverID,RequestID,EstimatedTime) VALUES (" + driverID + "," + requestID + "," + ETA + ")";
                        command = new SqlCommand(strCmd, conn);
                        command.ExecuteNonQuery();
                        return true;
                    }



                    else//if it returns they are already in the database
                    {
                        return false;
                    }
                }
            }
        }

        public bool SubmitPayment(int riderID)//completed
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                String strCmd = "update Requests Set Completed = 'YES' WHERE RiderID = '" + riderID + "' AND Completed = 'NO'";
                SqlCommand command = new SqlCommand(strCmd, conn);
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}




