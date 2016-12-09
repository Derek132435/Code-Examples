using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OIT_UBER_CL;
using System.Collections;

namespace OIT_UBER
{
    public partial class Form1 : Form
    {
        //public Account currentAccount = null;
        public ArrayList rideRequests { get; set; }

        public PullDatabase database { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.InitUberRead();
        }

        private void InitUberRead()
        {
            database = new PullDatabase();
            try
            {
                this.rideRequests = database.GetRideRequests();

                this.dataGridView1.DataSource = rideRequests;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            finally
            {
                Console.WriteLine("You Done Goofed...");
            }
        }

        private void RefreshDisplay()
        {
            this.dataGridView1.DataSource = rideRequests;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dataGridView1.Columns[column.Name].SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        // Register User
        private void button_Register_Click(object sender, EventArgs e)
        {
            int Newid=-1;
            if (rdbRider.Checked)
            {
                Newid =database.AddRiderData(textBox5.Text.ToString(), textBox3.Text.ToString(), textBox2.Text.ToString());
            }
            else if (rdbDriver.Checked)
            {
                Newid=database.AddDriverData(textBox_FirstName.Text.ToString(), textBox_LastName.Text.ToString(),
                textBox_VehicleType.Text.ToString(), textBox_PlateNumber.Text.ToString());

            }
            else
            {
                MessageBox.Show("No User Type Selected");
            }
            if(Newid ==-1)
            {
                MessageBox.Show("Incorrect Data Entry, the info you provided is already in the database");
            }
            else
            {
                MessageBox.Show("Success, your ID:" + Newid);
            }
        }

        // Submit Ride Request
        private void button_SubmitRequest_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                success = database.AddRideRequest(Convert.ToInt32(RRRiderID.Text), RRFirstName.Text.ToString(), RRLastName.Text.ToString(), textBox_Street.Text.ToString(), textBox_City.Text.ToString(), textBox_Zipcode.Text.ToString(), Convert.ToInt32(textBox_DesiredTime.Text));
            }
            catch (Exception b)
            {
                MessageBox.Show("Not all fields entered");
            }
            finally
            {
                if (success)
                {
                    MessageBox.Show("Ride Request Successfully added!");
                    InitUberRead();
                }
                else
                {
                    MessageBox.Show("Incorrect data entry");
                }
            }
        }

        // Accept Ride Request
        private void button_AcceptRequest_Click(object sender, EventArgs e)
        {
            bool success =database.AcceptRideRequest(Convert.ToInt32(DIDRideRequest.Text),Convert.ToInt32(RRIDRideRequest.Text), textBox4.Text.ToString());
            if (success)
            {
                InitUberRead();
            }
            else
                MessageBox.Show("Incorrect Data Entry");

        }

        // Submit Payment Information
        private void button_SubmitPayment_Click(object sender, EventArgs e)
        {
            bool success =database.SubmitPayment(Convert.ToInt32(textBox_CreditCard.Text));
            if(success)
            {
                MessageBox.Show("Payment sent!");
            }
            else
            {
                MessageBox.Show("Error: No ride request found associated with that RiderID");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label_CreditCard_Click(object sender, EventArgs e)
        {

        }

        private void rdbRider_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
