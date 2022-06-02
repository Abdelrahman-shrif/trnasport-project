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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            ShowCustomer();
        }
        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());
        private void Clear()
        {
            CustNameTb.Text = "";
            CustEmailTb.Text = "";
            CustAddressTb.Text = "";
            CustPhoneTb.Text = "";
            CustPhoneTwoTb.Text = "";
        }
        private void ShowCustomer()
        {
            Con.Open();
            string Query = "select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" ||  CustPhoneTb.Text == "" || CustAddressTb.Text == "")
            {
                MessageBox.Show("Missing Information!!\nتحتاج ادخال أسم الشركه, الهاتف, العنوان");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl (CusName,  CusAdd, CusPhone,  CusPhoneTwo, CusEmail) values(@CN,@CA,@CP,@CPt, @CE) ", Con);
                    cmd.Parameters.AddWithValue("@CN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddressTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CPT", CustPhoneTwoTb.Text);
                    cmd.Parameters.AddWithValue("@CE", CustEmailTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم أضافه الشركه بنجاح");
                    Con.Close();
                    Clear();
                    ShowCustomer();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("قم باختيار الشركه");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Customertbl where CusId=@CustKey", Con);
                    cmd.Parameters.AddWithValue("@Custkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الشركه بنجاح");
                    Con.Close();
                    ShowCustomer();
                    Clear();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void CustDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CustNameTb.Text = CustDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustAddressTb.Text = CustDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhoneTb.Text = CustDGV.SelectedRows[0].Cells[3].Value.ToString();
            CustPhoneTwoTb.Text = CustDGV.SelectedRows[0].Cells[4].Value.ToString();
            CustEmailTb.Text = CustDGV.SelectedRows[0].Cells[5].Value.ToString();

            if (CustNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddressTb.Text == "")
            {
                MessageBox.Show("قم باختيار الشركه");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update  CustomerTbl set CusName=@CN,  CusAdd=@CA, CusPhone=@CP,  CusPhoneTwo=@CPt, CusEmail=@CE where CusId=@CustKey  ", Con);
                    cmd.Parameters.AddWithValue("@Custkey", Key);
                    cmd.Parameters.AddWithValue("@CN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddressTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CPT", CustPhoneTwoTb.Text);
                    cmd.Parameters.AddWithValue("@CE", CustEmailTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم التعديل بنجاح");
                    Con.Close();
                    Clear();
                    ShowCustomer();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles ();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Vehicles Obj = new Vehicles();
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
    }
}
