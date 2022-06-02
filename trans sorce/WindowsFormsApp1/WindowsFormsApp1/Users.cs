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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            ShowUser();
        }
        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());
        private void Clear()
        {
            NameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
        }
        private void ShowUser()
        {
            Con.Open();
            string Query = "select * from UserTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UserDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missning information!!\nقم بأدخال اسم,رقم هاتف,رقم سري للمستخدم");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into UserTbl (UName, UPhone, UPassword) values(@UN, @UP, @UPA)", Con);
                    cmd.Parameters.AddWithValue("@UN", NameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حفظ المستخدم");
                    Con.Close();
                    ShowUser();
                    Clear();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }
        int Key = 0;

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("قم بتحديد مستخدم");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update  UserTbl set UName=@UN,  UPhone=@UP, UPassword=@UPA", Con);
                    cmd.Parameters.AddWithValue("@Userkey", Key);
                    cmd.Parameters.AddWithValue("@UN", NameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPA", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تحديث المستخدم");
                    Con.Close();
                    Clear();
                    ShowUser();
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
                    SqlCommand cmd = new SqlCommand("delete from UserTbl where UId=@UserKey", Con);
                    cmd.Parameters.AddWithValue("@UserKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف المسنخدم ");
                    Con.Close();
                    ShowUser();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);
                }
            }
        }

        private void UserDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = UserDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = UserDGV.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = UserDGV.SelectedRows[0].Cells[3].Value.ToString();

            if (NameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UserDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
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


