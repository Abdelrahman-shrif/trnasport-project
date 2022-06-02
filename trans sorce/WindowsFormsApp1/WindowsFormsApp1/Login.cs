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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());
        public static string User;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string Query = "select count(*) from UserTbl where UName = '" + UNameTb.Text + "' and UPassword = '" + UPasswordTb.Text + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                User = UNameTb.Text;
                Vehicles Obj = new Vehicles();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password!!");
                UNameTb.Text = "";
                UPasswordTb.Text = "";
            }

            Con.Close();
        }

        private void AdminLbl_Click(object sender, EventArgs e)
        {
            AdminLogin Obj = new AdminLogin();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
