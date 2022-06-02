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
    public partial class Vehicles : Form
    {
        public Vehicles()
        {
            InitializeComponent();
            ShowVehicles();
        }

        SqlConnection Con = new SqlConnection(ConnectionString.Getconnectionstring());
        private void ShowVehicles()
        {
            Con.Open();
            string Query = "select * from vehicleTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            VehicleDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Clear()
        {
            LPlateTb.Text = "";
            MarkCb.SelectedIndex = -1;
            ModelTb.Text = "";
            VYearCb.SelectedIndex = -1;
            EngTypeCb.SelectedIndex = -1;
            ColorTb.Text = "";
            MilleageTb.Text = "";
            TypeCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (LPlateTb.Text == "" || MarkCb.SelectedIndex == -1 || ModelTb.Text == "" || VYearCb.SelectedIndex == -1 || EngTypeCb.SelectedIndex == -1 ||  TypeCb.SelectedIndex == -1 || MilleageTb.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("Missing Information!! \nقم بأدخال\nرقم اللوحه,الموديل,الماركه,السنه,نوع المحرك,عدد الكيلو, اللون");

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into VehicleTbl (VLp,Vmark, Vmodel, VYear, VEngType, VColor, VMileage, VType) values(@VP, @Vma, @Vmo, @VY, @VEng,@VCo,@VMi, @VTy)", Con);
                    cmd.Parameters.AddWithValue("@VP", LPlateTb.Text);
                    cmd.Parameters.AddWithValue("@Vma", MarkCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Vmo", ModelTb.Text);
                    cmd.Parameters.AddWithValue("@VY", VYearCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VEng", EngTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VCo", ColorTb.Text);
                    cmd.Parameters.AddWithValue("@VMi", MilleageTb.Text);
                    cmd.Parameters.AddWithValue("@VTy", TypeCb.SelectedItem.ToString());
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حفظ المركبه");

                    Con.Close();
                    ShowVehicles();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (LPlateTb.Text == "")
            {
                MessageBox.Show("قم بأختيار مركبه ");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from VehicleTbl where VLP=@VPlate", Con);
                    cmd.Parameters.AddWithValue("@VPlate", LPlateTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف المركبه");

                    Con.Close();
                    ShowVehicles();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void VehicleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LPlateTb.Text = VehicleDGV.SelectedRows[0].Cells[0].Value.ToString();
            MarkCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = VehicleDGV.SelectedRows[0].Cells[2].Value.ToString();
            VYearCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[3].Value.ToString();
            EngTypeCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[4].Value.ToString();
            ColorTb.Text = VehicleDGV.SelectedRows[0].Cells[5].Value.ToString();
            MilleageTb.Text = VehicleDGV.SelectedRows[0].Cells[6].Value.ToString();
            TypeCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

            if (LPlateTb.Text == "" || MarkCb.SelectedIndex == -1 || ModelTb.Text == "" || VYearCb.SelectedIndex == -1 || EngTypeCb.SelectedIndex == -1 ||  TypeCb.SelectedIndex == -1 || MilleageTb.Text == "" || ColorTb.Text == "")
            {
                MessageBox.Show("قم ب أختيار المركبه المراد تعديلها");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update VehicleTbl set   Vmark=@Vma, Vmodel=@Vmo, VYear= @VY, VEngType= @VEng, VColor=@VCo, VMileage=@VMi, VType = @VTy where VLP = @VP ", Con);
                    cmd.Parameters.AddWithValue("@VP", LPlateTb.Text);
                    cmd.Parameters.AddWithValue("@Vma", MarkCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Vmo", ModelTb.Text);
                    cmd.Parameters.AddWithValue("@VY", VYearCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VEng", EngTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VCo", ColorTb.Text);
                    cmd.Parameters.AddWithValue("@VMi", MilleageTb.Text);
                    cmd.Parameters.AddWithValue("@VTy", TypeCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم تعديل المركبه بنجاح");

                    Con.Close();
                    ShowVehicles();
                    Clear();
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

        private void pictureBox12_Click(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Dashbaord Obj = new Dashbaord();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Driver Obj = new Driver();
            Obj.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Booking Obj = new Booking();
            Obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Dashbaord Obj = new Dashbaord();
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
    }
}
