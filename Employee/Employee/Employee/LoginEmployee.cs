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

namespace Employee
{ 
    public partial class LoginEmployee : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public LoginEmployee()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            if (txb_DN.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Hay nhap ten dang nhap vao truoc", "Error");
                return false;
            }
            else if (txb_MK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Hay nhap mat khau vao truoc", "Error");
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string query = "Select * from TK_NhanSU where TenDangNhapNS = '" + txb_DN.Text.Trim() + "' And MatKhauNS = '" + txb_MK.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Global.strconnect);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                if (dta.Rows.Count == 1)
                {

                    Global.TenDNNS = txb_DN.Text;
                    connection = new SqlConnection(Global.strconnect);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select MaNS FROM TK_NhanSu WHERE TENDANGNHAPNS='" +Global.TenDNNS + "'";
                    Global.MaNS = Convert.ToInt32( command.ExecuteScalar().ToString());

                    command = connection.CreateCommand();
                    command.CommandText = "select HoTenNS from NhanSu where MaNS='" + Global.MaNS + "'";
                    Global.HoTen_NS = command.ExecuteScalar().ToString();

                    command = connection.CreateCommand();
                    command.CommandText = "Select LoaiNS from NhanSU where MaNS ='" + Global.MaNS + "'";
                    Global.Loai_NS = command.ExecuteScalar().ToString();

                    command = connection.CreateCommand();
                    command.CommandText = "Select ChiNhanhLamViec from NhanSU where MaNS = '" + Global.MaNS + "'";
                    Global.ChiNhanhLamViec = Convert.ToInt32(command.ExecuteScalar().ToString());

                    command = connection.CreateCommand();
                    command.CommandText = "Select DiaChiCN from ChiNhanh where MaChiNhanh = '" + Global.ChiNhanhLamViec + "'";
                    Global.TenChiNhanh = command.ExecuteScalar().ToString();

                    if (Global.Loai_NS == "Bán hàng")
                    {
                        this.Hide();
                        Home_BanHang bh = new Home_BanHang();
                        bh.Show();
                        return;
                    }
                    else if(Global.Loai_NS == "Quản lý"){
                        this.Hide();
                        Home_QuanLy ql = new Home_QuanLy();
                        ql.Show();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại loại khách hàng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                    connection.Close();
                    
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void LoginEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}

public static class Global
{

    public static String Loai_NS = "";
    public static int MaNS = -1;
    public static String HoTen_NS = "";
    public static String TenDNNS = "";
    public static int ChiNhanhLamViec = -1;
    public static String TenChiNhanh = "";
    public const string strconnect = @"Data Source=DESKTOP-GFLTFQM\SQLEXPRESS;Initial Catalog=CUAHANGCHOBE;Integrated Security=True";
    public static bool IsNumeric(string value)
    {
        return value.All(char.IsNumber);
    }
}

