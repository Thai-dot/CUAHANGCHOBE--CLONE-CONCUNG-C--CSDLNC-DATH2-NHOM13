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

namespace Customer
{
    public partial class Home_KH : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Home_KH()
        {
            InitializeComponent();
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

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_MaSP.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_TenSP_Home.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_GiaBan_Home.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_LoaiSP_Home.Text = dgv_1.Rows[i].Cells[3].Value.ToString();
            txb_CongTy_Home.Text = dgv_1.Rows[i].Cells[4].Value.ToString();
        }

        private void loaddata()
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "Select DiaChiCN from ChiNhanh";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string chinhanh = datareader.GetString(0);
                cb_ChiNhanh.Items.Add(chinhanh);
            }
            connection.Close();
            connection = new SqlConnection(Global.strconnect);
            connection.Open();

            if (cb_SoCN.Text == "")
            {
                return;
            }
            command = connection.CreateCommand();
            command.CommandText = "Select sp.MaSP as Mã_SP,sp.TenSP as Tên_Sản_Phẩm,sp.GiaBan as Giá_Bán,sp.LoaiSP as Loại_Hàng,dt.TenDoiTac as Công_Ty from SanPham sp," +
                " DoiTac dt,ChiNhanh_SanPham cn where sp.DoiTac = dt.MaDT and cn.MaCN = "+cb_SoCN.Text+" and cn.MaSP = sp.MaSP ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;


            connection.Close();

        }

        private void Home_KH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_KH.ToString();
       
            connection.Close();
        }

      

        private void btn_MuaSanPham_Click(object sender, EventArgs e)
        {
            if(txb_TenSP_Home.Text ==""||txb_SoLuong_Home.Text ==""||txb_TongTien_Home.Text == ""||txb_TongTien_Home.Text=="0")
            {
                connection.Open();
                MessageBox.Show("Điền chưa đầy đủ thông tin sản phẩm?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                command = connection.CreateCommand();
                command.CommandText = "select HoTenKH from KhachHang where MaKH= '" + Global.MaKH + "'";
                Global.HoTen_KH = command.ExecuteScalar().ToString();
                connection.Close();



            }
            else
            {
                
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("ThemMotSPGioHang_KhachHang", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = txb_MaSP.Text;
                cmd.Parameters.Add("@SoLuongSP", SqlDbType.Int).Value = txb_SoLuong_Home.Text;
                cmd.Parameters.Add("@ThanhTienGH", SqlDbType.Float).Value = txb_TongTien_Home.Text;
                Global.MaCN = Convert.ToInt32(cb_SoCN.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công vào giỏ hàng?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (txb_seach_home.Text == "")
            {
                loaddata();
                return;
            }
            load_Search();
        }

        private void load_Search()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select sp.MaSP as Mã_SP, sp.TenSP as Tên_Sản_Phẩm,sp.GiaBan as Giá_Bán,sp.LoaiSP as Loại_Hàng,dt.TenDoiTac as Công_Ty " +
                "from SanPham sp, DoiTac dt, ChiNhanh_SanPham cn where sp.DoiTac = dt.MaDT  and cn.MaCN = " + cb_SoCN.Text + " and cn.MaSP = sp.MaSP and sp.TenSP like'" + txb_seach_home.Text + "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;
        }

        private void txb_SoLuong_Home_TextChanged(object sender, EventArgs e)
        {
            if(txb_SoLuong_Home.Text == "" ||txb_GiaBan_Home.Text ==""||txb_TongTien_Home.Text=="")
            {
                txb_SoLuong_Home.Text = "0";
                txb_TongTien_Home.Text = "0";
            }

            if (Global.IsNumeric(txb_SoLuong_Home.Text))
            {
                txb_TongTien_Home.Text = Convert.ToString(float.Parse(txb_SoLuong_Home.Text, CultureInfo.InvariantCulture.NumberFormat) * float.Parse(txb_GiaBan_Home.Text, CultureInfo.InvariantCulture.NumberFormat));
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            GioHang_KH giohang = new GioHang_KH();
            giohang.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinKH tt = new ThongTinKH();
            tt.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txb_TenSP_Home.Text == "" ||txb_MaSP.Text=="")
            {
             
                MessageBox.Show("Chưa chọn sản phẩm?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {


                //Tìm mã đối tác:
                int MaDT = 0;
                connection.Open();
               
                command = connection.CreateCommand();
                command.CommandText = "select DoiTac from SanPham where MaSP= '" + txb_MaSP.Text+ "'";
                MaDT = Convert.ToInt32(command.ExecuteScalar().ToString());
                connection.Close();


                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("themyeuthich_kh", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
                cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = txb_MaSP.Text;
                cmd.Parameters.Add("@MaDT", SqlDbType.Int).Value = MaDT;
                cmd.Parameters.Add("@TenCongTy", SqlDbType.NVarChar).Value = txb_CongTy_Home.Text;
                cmd.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = txb_TenSP_Home.Text;
                cmd.Parameters.Add("@GiaBan", SqlDbType.Float).Value = txb_GiaBan_Home.Text;


                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm vào danh sách yêu thích?", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeuThich yt = new YeuThich();
            yt.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label_XinChao_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txb_CongTy_Home_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSu_MuaHang_KH ls = new LichSu_MuaHang_KH();
            ls.Show();
        }

        private void cb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ChiNhanh.Text != "")
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "Select MaChiNhanh from ChiNhanh where DiaChiCN=N'" + cb_ChiNhanh.Text + "'";
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    string macn = datareader.GetInt32(0).ToString();
                    cb_SoCN.Items.Add(macn);
                }
                connection.Close();

            }
        }

        private void cb_SoCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_SoCN.Text == "")
            {
                return;
            }
            loaddata();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            TreEm_KH tt = new TreEm_KH();
            tt.Show();
        }
    }
}
