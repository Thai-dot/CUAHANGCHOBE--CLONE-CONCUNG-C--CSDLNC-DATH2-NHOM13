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
    public partial class DangKy_KH : Form
    {
        SqlConnection connection = new SqlConnection(Global.strconnect);
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        public DangKy_KH()
        {
            InitializeComponent();
        }

        private void DangKy_KH_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isValid())
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("DangKy_KhachHang", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = txb_TenDN_DK.Text;
                cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = txb_MK_DK.Text;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txb_HoTen.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cb_goitinh.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = txb_SDT_DK.Text;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dateTimePicker1.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txb_DiaChi_DK.Text;
                cmd.Parameters.Add("@EmailKH", SqlDbType.Char).Value = txb_Email.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng Ký Thành Công", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                
                



                
            }
            else
            {
                MessageBox.Show("Đăng Ký Thất bại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isValid()
        {
            if (txb_TenDN_DK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa nhập tên đăng nhập ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_MK_DK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có mật khẩu ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_NLMK_DK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có mật khẩu nhập lại mật khẩu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_HoTen.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có họ tên ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_SDT_DK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có số điện thoại ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_DiaChi_DK.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có địa chỉ ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cb_goitinh.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Chưa có giới tính ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string query = "Select * from TaiKhoan where TenDangNhap = '" + txb_TenDN_DK.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Global.strconnect);
            DataTable dta = new DataTable();
            sda.Fill(dta);
            if (dta.Rows.Count == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txb_MK_DK.Text != txb_NLMK_DK.Text)
            {
                MessageBox.Show("Hai mật khẩu không khớp với nhau ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(txb_Email.Text == "")
            {
                MessageBox.Show("Chưa nhập email ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }
    }
}
