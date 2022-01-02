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
using System.Globalization;
using System.Net;

namespace Customer
{
    public partial class ThongTinKH : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongTinKH()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_KH home = new Home_KH();
            home.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có muốn thoát ?", "Thoát Đăng Nhập", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                LoginForm login = new LoginForm();
                login.Show();
                Global.HoTen_KH = "";
                Global.Ten_DN = "";
                Global.MaKH = "";
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GioHang_KH giohang = new GioHang_KH();
            giohang.Show();
        }

        private void ThongTinKH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loadata();
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_KH.ToString();

            connection.Close();
        }

        private void loadata()
        {
            command = connection.CreateCommand();
            command.CommandText = "select HoTenKH as Họ_Tên,GioiTinh as Giới_Tính, SDTKH as Số_Điện_Thoại, NgaySinhKH as Ngày_Sinh, DiaChiKH as Địa_Chỉ from KhachHang where MaKH = '"+Global.MaKH+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;

            int i;
            i = dgv_1.CurrentRow.Index;
            txb_HoTen.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            comboBox1.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_SDT.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            datepicker_1.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_DiaChi.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_HoTen.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            comboBox1.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_SDT.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            datepicker_1.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_DiaChi.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("ChinhSua_ThongTin_KH", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = txb_HoTen.Text;
                cmd.Parameters.Add("@SDTKH", SqlDbType.NVarChar).Value = txb_SDT.Text;
                cmd.Parameters.Add("@NgaySinhKH", SqlDbType.Date).Value = datepicker_1.Text;
                cmd.Parameters.Add("@DiaChiKH", SqlDbType.NVarChar).Value = txb_DiaChi.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = comboBox1.Text;
                


                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin thành công?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                loadata();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
           if(txb_MKCu.Text == ""|| txb_MKM.Text == ""|| txb_NLMKM.Text == "")
            {
                MessageBox.Show("Không được để trống mật khẩu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                string query = "Select MatKhau from TaiKhoan where MaKh = '" + Global.MaKH + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, Global.strconnect);
                DataTable dta = new DataTable();
                sda.Fill(dta);

                if (dta.Rows.Count == 1)
                {
                    if (txb_MKM.Text != txb_NLMKM.Text)
                    {
                        MessageBox.Show("Sai 2 MK mới", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            connection = new SqlConnection(Global.strconnect);
                            connection.Open();
                            SqlCommand cmd = new SqlCommand("capnhat_matkhau", connection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                            cmd.Parameters.Add("@MatKhau", SqlDbType.Char).Value = txb_MKM.Text;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật mật khẩu thành công?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            connection.Close();
                            loadata();
                            return;

                        }
                    catch(Exception ex)
                        {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                    }
                }
                else
                {
                    MessageBox.Show("Sai MK cũ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            YeuThich yt = new YeuThich();
            this.Hide();
            yt.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSu_MuaHang_KH ls = new LichSu_MuaHang_KH();
            ls.Show();
        }
    }
}

