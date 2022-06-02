using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Driver : Form
    {
        public Driver()
        {
            InitializeComponent();
            ShowDriver();
        }
        int Key = 0;
        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());
        private void ShowDriver()
        {
            Con.Open();
            string Query = "select * from DriverTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DriverDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            DrNameTb.Text = "";
            DrAddressTb.Text = "";
            DrPhoneTb.Text = "";
            DrPhoneTwoTb.Text = "";
            GenCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (DrNameTb.Text == "" || DrPhoneTb.Text == "" || DrAddressTb.Text == "" || DrPhoneTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into DriverTbl (DrName,  DrPhone, DrPhoneSec, DrAdd, DrDob, DrJoinDate, DrGen) values(@DN,  @DP,@DPS,@DAD, @DDOB,@DJD,@DG)", Con);
                    cmd.Parameters.AddWithValue("@DN", DrNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DrPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@DPS", DrPhoneTwoTb.Text);
                    cmd.Parameters.AddWithValue("@DAD", DrAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DrDoB.Value.ToString());
                    cmd.Parameters.AddWithValue("@DJD", DrJoinDate.Value.ToString());
                    cmd.Parameters.AddWithValue("@DG", GenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Driver Recorded");
                    ShowDriver();
                    Clear();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (DrNameTb.Text == "" || DrPhoneTb.Text == "" || DrAddressTb.Text == "" || DrPhoneTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Driver");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update  DriverTbl set DrName=@DN,  DrPhone=@DP, DrPhoneSec=@DPS, DrAdd=@DAD, DrDob=@DDOB, DrJoinDate=@DJD, DrGen=@DG,  where DrId=@DrKey", Con);
                    cmd.Parameters.AddWithValue("@Drkey", Key);
                    cmd.Parameters.AddWithValue("@DN", DrNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", DrPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@DPS", DrPhoneTwoTb.Text);
                    cmd.Parameters.AddWithValue("@DAD", DrAddressTb.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DrDoB.Value.ToString());
                    cmd.Parameters.AddWithValue("@DJD", DrJoinDate.Value.ToString());
                    cmd.Parameters.AddWithValue("@DG", GenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Driver Updated");
                    Con.Close();
                    Clear();
                    ShowDriver();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

            if (Key == 0)
            {
                MessageBox.Show("Select User");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from DriverTbl where DrId=@DriverKey", Con);
                    cmd.Parameters.AddWithValue("@DriverKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Driver Deleted ");
                    Con.Close();
                    ShowDriver();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void DriverDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DrNameTb.Text = DriverDGV.SelectedRows[0].Cells[1].Value.ToString();
            DrPhoneTb.Text = DriverDGV.SelectedRows[0].Cells[2].Value.ToString();
            DrPhoneTwoTb.Text = DriverDGV.SelectedRows[0].Cells[3].Value.ToString();
            DrAddressTb.Text = DriverDGV.SelectedRows[0].Cells[4].Value.ToString();
            DrDoB.Text = DriverDGV.SelectedRows[0].Cells[5].Value.ToString();
            DrJoinDate.Text = DriverDGV.SelectedRows[0].Cells[6].Value.ToString();
            GenCb.Text = DriverDGV.SelectedRows[0].Cells[7].Value.ToString();

            if (DrNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DriverDGV.SelectedRows[0].Cells[0].Value.ToString());
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Dashbaord Obj = new Dashbaord();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
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
    }
}


