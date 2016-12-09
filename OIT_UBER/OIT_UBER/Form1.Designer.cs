namespace OIT_UBER
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RegisterUser = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox_DriverInfo = new System.Windows.Forms.GroupBox();
            this.label_LastName = new System.Windows.Forms.Label();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.label_FirstName = new System.Windows.Forms.Label();
            this.label_VehicleType = new System.Windows.Forms.Label();
            this.textBox_PlateNumber = new System.Windows.Forms.TextBox();
            this.label_LicensePlate = new System.Windows.Forms.Label();
            this.textBox_VehicleType = new System.Windows.Forms.TextBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.button_Register = new System.Windows.Forms.Button();
            this.rdbRider = new System.Windows.Forms.RadioButton();
            this.rdbDriver = new System.Windows.Forms.RadioButton();
            this.groupBox_RequestRide = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RRLastName = new System.Windows.Forms.TextBox();
            this.RRFirstName = new System.Windows.Forms.TextBox();
            this.RRRiderID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SubmitRequest = new System.Windows.Forms.Button();
            this.label_RequestTime = new System.Windows.Forms.Label();
            this.label_Location = new System.Windows.Forms.Label();
            this.textBox_DesiredTime = new System.Windows.Forms.TextBox();
            this.label_DesiredTime = new System.Windows.Forms.Label();
            this.textBox_Zipcode = new System.Windows.Forms.TextBox();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.textBox_Street = new System.Windows.Forms.TextBox();
            this.label_Zipcode = new System.Windows.Forms.Label();
            this.label_City = new System.Windows.Forms.Label();
            this.label_Street = new System.Windows.Forms.Label();
            this.RideRequestBrowse = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DriverRequestAccept = new System.Windows.Forms.GroupBox();
            this.button_AcceptRequest = new System.Windows.Forms.Button();
            this.label_RideRequestID = new System.Windows.Forms.Label();
            this.RRIDRideRequest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox_RiderPay = new System.Windows.Forms.GroupBox();
            this.button_SubmitPayment = new System.Windows.Forms.Button();
            this.textBox_CreditCard = new System.Windows.Forms.TextBox();
            this.label_CreditCard = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DIDRideRequest = new System.Windows.Forms.TextBox();
            this.RegisterUser.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_DriverInfo.SuspendLayout();
            this.groupBox_RequestRide.SuspendLayout();
            this.RideRequestBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.DriverRequestAccept.SuspendLayout();
            this.groupBox_RiderPay.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterUser
            // 
            this.RegisterUser.Controls.Add(this.groupBox1);
            this.RegisterUser.Controls.Add(this.groupBox_DriverInfo);
            this.RegisterUser.Controls.Add(this.button_Register);
            this.RegisterUser.Controls.Add(this.rdbRider);
            this.RegisterUser.Controls.Add(this.rdbDriver);
            this.RegisterUser.Location = new System.Drawing.Point(11, 11);
            this.RegisterUser.Margin = new System.Windows.Forms.Padding(2);
            this.RegisterUser.Name = "RegisterUser";
            this.RegisterUser.Padding = new System.Windows.Forms.Padding(2);
            this.RegisterUser.Size = new System.Drawing.Size(253, 345);
            this.RegisterUser.TabIndex = 9;
            this.RegisterUser.TabStop = false;
            this.RegisterUser.Text = "Register User";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Location = new System.Drawing.Point(4, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 107);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riders: Please Fill Out";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Last Name";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(100, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Credit Card #:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(100, 54);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(118, 20);
            this.textBox3.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(100, 31);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(118, 20);
            this.textBox5.TabIndex = 10;
            // 
            // groupBox_DriverInfo
            // 
            this.groupBox_DriverInfo.Controls.Add(this.label_LastName);
            this.groupBox_DriverInfo.Controls.Add(this.textBox_LastName);
            this.groupBox_DriverInfo.Controls.Add(this.label_FirstName);
            this.groupBox_DriverInfo.Controls.Add(this.label_VehicleType);
            this.groupBox_DriverInfo.Controls.Add(this.textBox_PlateNumber);
            this.groupBox_DriverInfo.Controls.Add(this.label_LicensePlate);
            this.groupBox_DriverInfo.Controls.Add(this.textBox_VehicleType);
            this.groupBox_DriverInfo.Controls.Add(this.textBox_FirstName);
            this.groupBox_DriverInfo.Location = new System.Drawing.Point(10, 172);
            this.groupBox_DriverInfo.Name = "groupBox_DriverInfo";
            this.groupBox_DriverInfo.Size = new System.Drawing.Size(238, 139);
            this.groupBox_DriverInfo.TabIndex = 16;
            this.groupBox_DriverInfo.TabStop = false;
            this.groupBox_DriverInfo.Text = "Drivers: Please Fill Out";
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.Location = new System.Drawing.Point(6, 57);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(61, 13);
            this.label_LastName.TabIndex = 13;
            this.label_LastName.Text = "Last Name:";
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Location = new System.Drawing.Point(100, 57);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(118, 20);
            this.textBox_LastName.TabIndex = 14;
            // 
            // label_FirstName
            // 
            this.label_FirstName.AutoSize = true;
            this.label_FirstName.Location = new System.Drawing.Point(6, 31);
            this.label_FirstName.Name = "label_FirstName";
            this.label_FirstName.Size = new System.Drawing.Size(60, 13);
            this.label_FirstName.TabIndex = 10;
            this.label_FirstName.Text = "First Name:";
            // 
            // label_VehicleType
            // 
            this.label_VehicleType.AutoSize = true;
            this.label_VehicleType.Location = new System.Drawing.Point(6, 83);
            this.label_VehicleType.Name = "label_VehicleType";
            this.label_VehicleType.Size = new System.Drawing.Size(72, 13);
            this.label_VehicleType.TabIndex = 11;
            this.label_VehicleType.Text = "Vehicle Type:";
            // 
            // textBox_PlateNumber
            // 
            this.textBox_PlateNumber.Location = new System.Drawing.Point(100, 109);
            this.textBox_PlateNumber.Name = "textBox_PlateNumber";
            this.textBox_PlateNumber.Size = new System.Drawing.Size(118, 20);
            this.textBox_PlateNumber.TabIndex = 11;
            // 
            // label_LicensePlate
            // 
            this.label_LicensePlate.AutoSize = true;
            this.label_LicensePlate.Location = new System.Drawing.Point(6, 109);
            this.label_LicensePlate.Name = "label_LicensePlate";
            this.label_LicensePlate.Size = new System.Drawing.Size(84, 13);
            this.label_LicensePlate.TabIndex = 12;
            this.label_LicensePlate.Text = "License Plate #:";
            // 
            // textBox_VehicleType
            // 
            this.textBox_VehicleType.Location = new System.Drawing.Point(100, 83);
            this.textBox_VehicleType.Name = "textBox_VehicleType";
            this.textBox_VehicleType.Size = new System.Drawing.Size(118, 20);
            this.textBox_VehicleType.TabIndex = 11;
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Location = new System.Drawing.Point(100, 31);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(118, 20);
            this.textBox_FirstName.TabIndex = 10;
            // 
            // button_Register
            // 
            this.button_Register.Location = new System.Drawing.Point(57, 317);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(133, 23);
            this.button_Register.TabIndex = 15;
            this.button_Register.Text = "Submit Registration";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // rdbRider
            // 
            this.rdbRider.AutoSize = true;
            this.rdbRider.Location = new System.Drawing.Point(4, 22);
            this.rdbRider.Margin = new System.Windows.Forms.Padding(2);
            this.rdbRider.Name = "rdbRider";
            this.rdbRider.Size = new System.Drawing.Size(50, 17);
            this.rdbRider.TabIndex = 2;
            this.rdbRider.TabStop = true;
            this.rdbRider.Text = "Rider";
            this.rdbRider.UseVisualStyleBackColor = true;
            this.rdbRider.CheckedChanged += new System.EventHandler(this.rdbRider_CheckedChanged);
            // 
            // rdbDriver
            // 
            this.rdbDriver.AutoSize = true;
            this.rdbDriver.Location = new System.Drawing.Point(10, 150);
            this.rdbDriver.Margin = new System.Windows.Forms.Padding(2);
            this.rdbDriver.Name = "rdbDriver";
            this.rdbDriver.Size = new System.Drawing.Size(53, 17);
            this.rdbDriver.TabIndex = 1;
            this.rdbDriver.TabStop = true;
            this.rdbDriver.Text = "Driver";
            this.rdbDriver.UseVisualStyleBackColor = true;
            // 
            // groupBox_RequestRide
            // 
            this.groupBox_RequestRide.Controls.Add(this.label6);
            this.groupBox_RequestRide.Controls.Add(this.label7);
            this.groupBox_RequestRide.Controls.Add(this.RRLastName);
            this.groupBox_RequestRide.Controls.Add(this.RRFirstName);
            this.groupBox_RequestRide.Controls.Add(this.RRRiderID);
            this.groupBox_RequestRide.Controls.Add(this.label5);
            this.groupBox_RequestRide.Controls.Add(this.button_SubmitRequest);
            this.groupBox_RequestRide.Controls.Add(this.label_RequestTime);
            this.groupBox_RequestRide.Controls.Add(this.label_Location);
            this.groupBox_RequestRide.Controls.Add(this.textBox_DesiredTime);
            this.groupBox_RequestRide.Controls.Add(this.label_DesiredTime);
            this.groupBox_RequestRide.Controls.Add(this.textBox_Zipcode);
            this.groupBox_RequestRide.Controls.Add(this.textBox_City);
            this.groupBox_RequestRide.Controls.Add(this.textBox_Street);
            this.groupBox_RequestRide.Controls.Add(this.label_Zipcode);
            this.groupBox_RequestRide.Controls.Add(this.label_City);
            this.groupBox_RequestRide.Controls.Add(this.label_Street);
            this.groupBox_RequestRide.Location = new System.Drawing.Point(268, 11);
            this.groupBox_RequestRide.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_RequestRide.Name = "groupBox_RequestRide";
            this.groupBox_RequestRide.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_RequestRide.Size = new System.Drawing.Size(222, 317);
            this.groupBox_RequestRide.TabIndex = 10;
            this.groupBox_RequestRide.TabStop = false;
            this.groupBox_RequestRide.Text = "Rider: Request Ride";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "First Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Last Name";
            // 
            // RRLastName
            // 
            this.RRLastName.Location = new System.Drawing.Point(67, 73);
            this.RRLastName.Name = "RRLastName";
            this.RRLastName.Size = new System.Drawing.Size(118, 20);
            this.RRLastName.TabIndex = 21;
            // 
            // RRFirstName
            // 
            this.RRFirstName.Location = new System.Drawing.Point(67, 50);
            this.RRFirstName.Name = "RRFirstName";
            this.RRFirstName.Size = new System.Drawing.Size(118, 20);
            this.RRFirstName.TabIndex = 19;
            // 
            // RRRiderID
            // 
            this.RRRiderID.Location = new System.Drawing.Point(67, 28);
            this.RRRiderID.Name = "RRRiderID";
            this.RRRiderID.Size = new System.Drawing.Size(118, 20);
            this.RRRiderID.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "RiderID:";
            // 
            // button_SubmitRequest
            // 
            this.button_SubmitRequest.Location = new System.Drawing.Point(40, 272);
            this.button_SubmitRequest.Name = "button_SubmitRequest";
            this.button_SubmitRequest.Size = new System.Drawing.Size(145, 23);
            this.button_SubmitRequest.TabIndex = 15;
            this.button_SubmitRequest.Text = "Submit Request";
            this.button_SubmitRequest.UseVisualStyleBackColor = true;
            this.button_SubmitRequest.Click += new System.EventHandler(this.button_SubmitRequest_Click);
            // 
            // label_RequestTime
            // 
            this.label_RequestTime.AutoSize = true;
            this.label_RequestTime.Location = new System.Drawing.Point(5, 217);
            this.label_RequestTime.Name = "label_RequestTime";
            this.label_RequestTime.Size = new System.Drawing.Size(217, 13);
            this.label_RequestTime.TabIndex = 12;
            this.label_RequestTime.Text = "How Long from now do you need a pick up?";
            // 
            // label_Location
            // 
            this.label_Location.AutoSize = true;
            this.label_Location.Location = new System.Drawing.Point(5, 119);
            this.label_Location.Name = "label_Location";
            this.label_Location.Size = new System.Drawing.Size(86, 13);
            this.label_Location.TabIndex = 11;
            this.label_Location.Text = "Where Are You?";
            // 
            // textBox_DesiredTime
            // 
            this.textBox_DesiredTime.Location = new System.Drawing.Point(99, 238);
            this.textBox_DesiredTime.Name = "textBox_DesiredTime";
            this.textBox_DesiredTime.Size = new System.Drawing.Size(118, 20);
            this.textBox_DesiredTime.TabIndex = 13;
            // 
            // label_DesiredTime
            // 
            this.label_DesiredTime.AutoSize = true;
            this.label_DesiredTime.Location = new System.Drawing.Point(5, 238);
            this.label_DesiredTime.Name = "label_DesiredTime";
            this.label_DesiredTime.Size = new System.Drawing.Size(95, 13);
            this.label_DesiredTime.TabIndex = 14;
            this.label_DesiredTime.Text = "Desired Time(Min):";
            // 
            // textBox_Zipcode
            // 
            this.textBox_Zipcode.Location = new System.Drawing.Point(99, 187);
            this.textBox_Zipcode.Name = "textBox_Zipcode";
            this.textBox_Zipcode.Size = new System.Drawing.Size(118, 20);
            this.textBox_Zipcode.TabIndex = 11;
            // 
            // textBox_City
            // 
            this.textBox_City.Location = new System.Drawing.Point(99, 163);
            this.textBox_City.Name = "textBox_City";
            this.textBox_City.Size = new System.Drawing.Size(118, 20);
            this.textBox_City.TabIndex = 11;
            // 
            // textBox_Street
            // 
            this.textBox_Street.Location = new System.Drawing.Point(99, 140);
            this.textBox_Street.Name = "textBox_Street";
            this.textBox_Street.Size = new System.Drawing.Size(118, 20);
            this.textBox_Street.TabIndex = 10;
            // 
            // label_Zipcode
            // 
            this.label_Zipcode.AutoSize = true;
            this.label_Zipcode.Location = new System.Drawing.Point(5, 187);
            this.label_Zipcode.Name = "label_Zipcode";
            this.label_Zipcode.Size = new System.Drawing.Size(46, 13);
            this.label_Zipcode.TabIndex = 12;
            this.label_Zipcode.Text = "Zipcode";
            // 
            // label_City
            // 
            this.label_City.AutoSize = true;
            this.label_City.Location = new System.Drawing.Point(5, 163);
            this.label_City.Name = "label_City";
            this.label_City.Size = new System.Drawing.Size(27, 13);
            this.label_City.TabIndex = 11;
            this.label_City.Text = "City:";
            // 
            // label_Street
            // 
            this.label_Street.AutoSize = true;
            this.label_Street.Location = new System.Drawing.Point(5, 140);
            this.label_Street.Name = "label_Street";
            this.label_Street.Size = new System.Drawing.Size(38, 13);
            this.label_Street.TabIndex = 10;
            this.label_Street.Text = "Street:";
            // 
            // RideRequestBrowse
            // 
            this.RideRequestBrowse.Controls.Add(this.dataGridView1);
            this.RideRequestBrowse.Location = new System.Drawing.Point(494, 10);
            this.RideRequestBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.RideRequestBrowse.Name = "RideRequestBrowse";
            this.RideRequestBrowse.Padding = new System.Windows.Forms.Padding(2);
            this.RideRequestBrowse.Size = new System.Drawing.Size(568, 451);
            this.RideRequestBrowse.TabIndex = 11;
            this.RideRequestBrowse.TabStop = false;
            this.RideRequestBrowse.Text = "Browse Ride Requests";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(555, 419);
            this.dataGridView1.TabIndex = 0;
            // 
            // DriverRequestAccept
            // 
            this.DriverRequestAccept.Controls.Add(this.label8);
            this.DriverRequestAccept.Controls.Add(this.DIDRideRequest);
            this.DriverRequestAccept.Controls.Add(this.button_AcceptRequest);
            this.DriverRequestAccept.Controls.Add(this.label_RideRequestID);
            this.DriverRequestAccept.Controls.Add(this.RRIDRideRequest);
            this.DriverRequestAccept.Controls.Add(this.label2);
            this.DriverRequestAccept.Controls.Add(this.textBox4);
            this.DriverRequestAccept.Location = new System.Drawing.Point(11, 360);
            this.DriverRequestAccept.Margin = new System.Windows.Forms.Padding(2);
            this.DriverRequestAccept.Name = "DriverRequestAccept";
            this.DriverRequestAccept.Padding = new System.Windows.Forms.Padding(2);
            this.DriverRequestAccept.Size = new System.Drawing.Size(253, 115);
            this.DriverRequestAccept.TabIndex = 12;
            this.DriverRequestAccept.TabStop = false;
            this.DriverRequestAccept.Text = "Driver: Accept Ride Request";
            // 
            // button_AcceptRequest
            // 
            this.button_AcceptRequest.Location = new System.Drawing.Point(57, 85);
            this.button_AcceptRequest.Name = "button_AcceptRequest";
            this.button_AcceptRequest.Size = new System.Drawing.Size(133, 23);
            this.button_AcceptRequest.TabIndex = 13;
            this.button_AcceptRequest.Text = "Accept Request";
            this.button_AcceptRequest.UseVisualStyleBackColor = true;
            this.button_AcceptRequest.Click += new System.EventHandler(this.button_AcceptRequest_Click);
            // 
            // label_RideRequestID
            // 
            this.label_RideRequestID.AutoSize = true;
            this.label_RideRequestID.Location = new System.Drawing.Point(10, 44);
            this.label_RideRequestID.Name = "label_RideRequestID";
            this.label_RideRequestID.Size = new System.Drawing.Size(99, 13);
            this.label_RideRequestID.TabIndex = 13;
            this.label_RideRequestID.Text = "Ride Request ID #:";
            // 
            // RRIDRideRequest
            // 
            this.RRIDRideRequest.Location = new System.Drawing.Point(125, 38);
            this.RRIDRideRequest.Name = "RRIDRideRequest";
            this.RRIDRideRequest.Size = new System.Drawing.Size(118, 20);
            this.RRIDRideRequest.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Estimated Arrival Time:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(124, 61);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(118, 20);
            this.textBox4.TabIndex = 10;
            // 
            // groupBox_RiderPay
            // 
            this.groupBox_RiderPay.Controls.Add(this.button_SubmitPayment);
            this.groupBox_RiderPay.Controls.Add(this.textBox_CreditCard);
            this.groupBox_RiderPay.Controls.Add(this.label_CreditCard);
            this.groupBox_RiderPay.Location = new System.Drawing.Point(268, 332);
            this.groupBox_RiderPay.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_RiderPay.Name = "groupBox_RiderPay";
            this.groupBox_RiderPay.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_RiderPay.Size = new System.Drawing.Size(222, 115);
            this.groupBox_RiderPay.TabIndex = 13;
            this.groupBox_RiderPay.TabStop = false;
            this.groupBox_RiderPay.Text = "Rider: Payment";
            // 
            // button_SubmitPayment
            // 
            this.button_SubmitPayment.Location = new System.Drawing.Point(40, 83);
            this.button_SubmitPayment.Name = "button_SubmitPayment";
            this.button_SubmitPayment.Size = new System.Drawing.Size(145, 23);
            this.button_SubmitPayment.TabIndex = 15;
            this.button_SubmitPayment.Text = "Submit Payment";
            this.button_SubmitPayment.UseVisualStyleBackColor = true;
            this.button_SubmitPayment.Click += new System.EventHandler(this.button_SubmitPayment_Click);
            // 
            // textBox_CreditCard
            // 
            this.textBox_CreditCard.Location = new System.Drawing.Point(99, 36);
            this.textBox_CreditCard.Name = "textBox_CreditCard";
            this.textBox_CreditCard.Size = new System.Drawing.Size(118, 20);
            this.textBox_CreditCard.TabIndex = 10;
            // 
            // label_CreditCard
            // 
            this.label_CreditCard.AutoSize = true;
            this.label_CreditCard.Location = new System.Drawing.Point(50, 39);
            this.label_CreditCard.Name = "label_CreditCard";
            this.label_CreditCard.Size = new System.Drawing.Size(46, 13);
            this.label_CreditCard.TabIndex = 10;
            this.label_CreditCard.Text = "RiderID:";
            this.label_CreditCard.Click += new System.EventHandler(this.label_CreditCard_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Driver ID #:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // DIDRideRequest
            // 
            this.DIDRideRequest.Location = new System.Drawing.Point(125, 15);
            this.DIDRideRequest.Name = "DIDRideRequest";
            this.DIDRideRequest.Size = new System.Drawing.Size(118, 20);
            this.DIDRideRequest.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 486);
            this.Controls.Add(this.groupBox_RiderPay);
            this.Controls.Add(this.DriverRequestAccept);
            this.Controls.Add(this.RideRequestBrowse);
            this.Controls.Add(this.groupBox_RequestRide);
            this.Controls.Add(this.RegisterUser);
            this.Name = "Form1";
            this.Text = "Oregon Tech is Uber Safe!";
            this.RegisterUser.ResumeLayout(false);
            this.RegisterUser.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_DriverInfo.ResumeLayout(false);
            this.groupBox_DriverInfo.PerformLayout();
            this.groupBox_RequestRide.ResumeLayout(false);
            this.groupBox_RequestRide.PerformLayout();
            this.RideRequestBrowse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.DriverRequestAccept.ResumeLayout(false);
            this.DriverRequestAccept.PerformLayout();
            this.groupBox_RiderPay.ResumeLayout(false);
            this.groupBox_RiderPay.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RegisterUser;
        private System.Windows.Forms.RadioButton rdbRider;
        private System.Windows.Forms.RadioButton rdbDriver;
        private System.Windows.Forms.Label label_VehicleType;
        private System.Windows.Forms.Label label_FirstName;
        private System.Windows.Forms.TextBox textBox_PlateNumber;
        private System.Windows.Forms.TextBox textBox_VehicleType;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.Label label_LicensePlate;
        private System.Windows.Forms.GroupBox groupBox_RequestRide;
        private System.Windows.Forms.Label label_RequestTime;
        private System.Windows.Forms.Label label_Location;
        private System.Windows.Forms.TextBox textBox_DesiredTime;
        private System.Windows.Forms.Label label_DesiredTime;
        private System.Windows.Forms.TextBox textBox_Zipcode;
        private System.Windows.Forms.TextBox textBox_City;
        private System.Windows.Forms.TextBox textBox_Street;
        private System.Windows.Forms.Label label_Zipcode;
        private System.Windows.Forms.Label label_City;
        private System.Windows.Forms.Label label_Street;
        private System.Windows.Forms.GroupBox RideRequestBrowse;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox DriverRequestAccept;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button_Register;
        private System.Windows.Forms.Button button_SubmitRequest;
        private System.Windows.Forms.Button button_AcceptRequest;
        private System.Windows.Forms.Label label_RideRequestID;
        private System.Windows.Forms.TextBox RRIDRideRequest;
        private System.Windows.Forms.GroupBox groupBox_DriverInfo;
        private System.Windows.Forms.GroupBox groupBox_RiderPay;
        private System.Windows.Forms.Button button_SubmitPayment;
        private System.Windows.Forms.TextBox textBox_CreditCard;
        private System.Windows.Forms.Label label_CreditCard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox RRLastName;
        private System.Windows.Forms.TextBox RRFirstName;
        private System.Windows.Forms.TextBox RRRiderID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DIDRideRequest;
    }
}

