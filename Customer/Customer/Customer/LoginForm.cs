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

namespace Customer
{
    public partial class LoginForm : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string query = "Select * from TaiKhoan where TenDangNhap = '" + txb_TK_KH.Text.Trim() + "' And MatKhau = '" + txb_MK_KH.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Global.strconnect);
                DataTable dta = new DataTable();
                sda.Fill(dta);
                if (dta.Rows.Count == 1)
                {
                    
                    Global.Ten_DN = txb_TK_KH.Text;
                    connection = new SqlConnection(Global.strconnect);
                    connection.Open();
                    command = connection.CreateCommand();
                    command.CommandText = "select Makh FROM TAIKHOAN WHERE TENDANGNHAP='" + Global.Ten_DN + "'";
                    Global.MaKH = command.ExecuteScalar().ToString();

                    command = connection.CreateCommand();
                    command.CommandText = "select HoTenKH from KhachHang where MaKH= '"+Global.MaKH+"'";
                    Global.HoTen_KH = command.ExecuteScalar().ToString();
                    connection.Close();
                    Home_KH home_KH = new Home_KH();
                    this.Hide();
                    home_KH.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private bool isValid()
        {
            if (txb_TK_KH.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Hay nhap ten dang nhap vao truoc", "Error");
                return false;
            }
            else if (txb_MK_KH.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Hay nhap mat khau vao truoc", "Error");
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy_KH dk_form = new DangKy_KH();
            dk_form.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}

public static class Global
{

    public static String Ten_DN = "";
    public static String MaKH = "";
    public static String HoTen_KH = "";
    public static int MaCN = -1;
    public const string strconnect = @"Data Source=DESKTOP-GFLTFQM\SQLEXPRESS;Initial Catalog=CUAHANGCHOBE;Integrated Security=True";
    public static bool IsNumeric(string value)
    {
        return value.All(char.IsNumber);
    }
}

