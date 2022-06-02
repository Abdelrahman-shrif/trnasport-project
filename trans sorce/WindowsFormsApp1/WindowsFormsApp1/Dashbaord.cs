using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashbaord : Form
    {
        public Dashbaord()
        {
            InitializeComponent();
            CountVehicles();
            CountDrivers();
            CountUsers();
            CountCustomers();
            CountBooking();
            SumAmt();
        }

        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());

        private void CountVehicles()
        {
            Con.Open();
            string Query = "select count(*) from VehicleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VNumLbl.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountDrivers()
        {
            Con.Open();
            string Query = "select count(*) from DriverTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DNumLbl.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountUsers()
        {
            Con.Open();
            string Query = "select count(*) from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            UNumLbl.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountCustomers()
        {
            Con.Open();
            string Query = "select count(*) from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CNumLbl.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void CountBooking()
        {
            Con.Open();
            string Query = "select count(*) from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BNumLbl.Text = dt.Rows[0][0].ToString();

            Con.Close();
        }
        private void SumAmt()
        {
            Con.Open();
            string Query = "select sum(Amount) from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string income;
            income = INumLbl.Text = dt.Rows[0][0].ToString();
            if (income == "")
            {
                INumLbl.Text = "0 EGP";
            }
            else
            {
                INumLbl.Text = dt.Rows[0][0].ToString() + " EGP";
            }

            Con.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Driver Obj = new Driver();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Driver Obj = new Driver();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
            Obj.Show();
            this.Hide();
        }
    }
}
