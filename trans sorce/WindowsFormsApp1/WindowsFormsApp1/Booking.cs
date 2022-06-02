using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
            GetCustomers();
            ShowBooked();
            GetCars();
            GetDrivers();
            UNameLbl.Text = Login.User;
        }
        int Key = 0;

        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());

        private void Clear()
        {
            CustCb.SelectedIndex = -1;
            VehicleCb.SelectedIndex = -1;
            DriverCb.SelectedIndex = -1;
            AmountTb.Text = "";
        }
        private void ShowBooked()
        {
            Con.Open();
            string Query = "select * from BookingTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BookingDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void GetCustomers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusName", typeof(string));
            dt.Load(rdr);
            CustCb.ValueMember = "CusName";
            CustCb.DataSource = dt;
            Con.Close();
        }

        private void GetDrivers()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from DriverTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DrName", typeof(string));
            dt.Load(rdr);
            DriverCb.ValueMember = "DrName";
            DriverCb.DataSource = dt;
            Con.Close();
        }
        private void GetCars()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from VehicleTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("VLp", typeof(string));
            dt.Load(rdr);
            VehicleCb.ValueMember = "VLp";
            VehicleCb.DataSource = dt;
            Con.Close();
        }
        private void CustomerCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || VehicleCb.SelectedIndex == -1 || DriverCb.SelectedIndex == -1 || AmountTb.Text == "")
            {
                MessageBox.Show("Missning information\n برجاء ادخال كافه البيانات");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BookingTbl (CustName, Vehicle, Driver, PickUpdate, DropOffDate, Amount, BUser) values(@BCN, @BV, @BD, @BPU,@BDOD,@BA,@BU)", Con);
                    cmd.Parameters.AddWithValue("@BCN", CustCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BV", VehicleCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@BD", DriverCb.Text);
                    cmd.Parameters.AddWithValue("@BPU", PickupDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BDOD", ReturnDate.Value.Date);
                    cmd.Parameters.AddWithValue("@BA", AmountTb.Text);
                    cmd.Parameters.AddWithValue("@BU", UNameLbl.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحجز بنجاح");
                    Con.Close();
                    
                    ShowBooked();
                    Clear();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Customer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from BookingTbl where BId=@BookKey", Con);
                    cmd.Parameters.AddWithValue("@Bookkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الغاء الحجز");
                    Con.Close();
                    Clear();
                    ShowBooked();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Dashbaord Obj = new Dashbaord();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashbaord Obj = new Dashbaord();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void BookingDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustCb.SelectedValue = BookingDGV.SelectedRows[0].Cells[1].Value.ToString();
            VehicleCb.SelectedValue = BookingDGV.SelectedRows[0].Cells[2].Value.ToString();
            DriverCb.SelectedValue = BookingDGV.SelectedRows[0].Cells[3].Value.ToString();
            AmountTb.Text = BookingDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (CustCb.SelectedIndex == -1)
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BookingDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
