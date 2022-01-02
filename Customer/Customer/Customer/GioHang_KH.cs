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
    public partial class GioHang_KH : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public GioHang_KH()
        {
            InitializeComponent();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_MaSP.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_SoLuong.Text = dgv_1.Rows[i].Cells[1].Value.ToString();
            txb_TenSP.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            
        }

        private void loaddata()
        {
            command = connection.CreateCommand();
            command.CommandText = "Select ghsp.MaSP as Mã_SP, ghsp.SoLuongSP as Số_Lượng_SP,sp.TenSP as Tên_SP,gh.NgayThem as Ngày_Thêm,ghsp.ThanhTienGH as Thành_Tiền from GH_SP ghsp,GioHang gh, SanPham sp where sp.MaSP = ghsp.MaSP and gh.MaKH = ghsp.MaKH ";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgv_1.DataSource = table;            

        }

        private void GioHang_KH_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
            loadPrice();
            label_XinChao.Text = label_XinChao.Text + " " + Global.HoTen_KH.ToString();
            connection.Close();
        }

        private void loadPrice()
        {

            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select sum(ThanhTienGH) FROM GH_SP WHERE MaKH='" + Global.MaKH + "'and MaGioHang = 1";
            double PhiSanPham = 0;
            if(command.ExecuteScalar().ToString() == "")
            {
                return;
            }
            PhiSanPham = Convert.ToDouble(command.ExecuteScalar().ToString());
            double PhiShip = 0;

            if(PhiSanPham < 99000)
            {
                PhiShip = 30000;
            }
            else if (PhiSanPham < 299000)
            {
                PhiShip = 20000;
            }
            else if (PhiSanPham < 599000)
            {
                PhiShip = 10000;
            }
            else
            {
                PhiShip = 0;

            }

            double TongTien = PhiShip + PhiSanPham;
            txb_PhiSanPham.Text = (Math.Round(PhiSanPham,2)).ToString();
            txb_PhiShip.Text = (Math.Round(PhiShip, 2)).ToString();
            txb_TongTien.Text = (Math.Round(TongTien, 2)).ToString();
           
            connection.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_KH home = new Home_KH();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_MaSP.Text == "")
            {

                MessageBox.Show("Chưa chọn sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            SqlCommand cmd = new SqlCommand("update_Soluong_GHSP", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = txb_MaSP.Text;
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value =  Global.MaKH;
            cmd.Parameters.Add("@SoLuongSP", SqlDbType.Int).Value = int.Parse(txb_SoLuong.Text);


            cmd.ExecuteNonQuery();
            loaddata();
            loadPrice();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txb_MaSP.Text == "")
            {

                MessageBox.Show("Chưa chọn sản phẩm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            SqlCommand cmd = new SqlCommand("delete_SP_GH", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaSP", SqlDbType.Int).Value = txb_MaSP.Text;
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
            cmd.Parameters.Add("@SoLuongSP", SqlDbType.Int).Value = txb_SoLuong.Text;


            cmd.ExecuteNonQuery();
            loaddata();
            loadPrice();
            connection.Close();
        }

        private void cb_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(txb_DiaChiGiao.Text == ""|| cb_HTTT.Text == "")
            {
                MessageBox.Show("Điền chưa đầy đủ thông tin giao hàng?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            SqlCommand cmd = new SqlCommand("them_hoadon_KH", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PhiVanChuyen", SqlDbType.Float).Value = Convert.ToDouble(txb_PhiShip.Text);
            cmd.Parameters.Add("@PhiSanPham", SqlDbType.Float).Value = Convert.ToDouble(txb_PhiSanPham.Text);
            cmd.Parameters.Add("@TongTien", SqlDbType.Float).Value = Convert.ToDouble(txb_TongTien.Text);
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Global.MaKH;
            cmd.Parameters.Add("@MaCN", SqlDbType.Int).Value = Global.MaCN;
            cmd.Parameters.Add("@HinhThucThanhToan", SqlDbType.NVarChar).Value = cb_HTTT.Text;
            cmd.Parameters.Add("@DiaChiGiao", SqlDbType.NVarChar).Value = txb_DiaChiGiao.Text;
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txb_MoTa.Text;


            cmd.ExecuteNonQuery();
            MessageBox.Show("Thanh toán thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               loaddata();
                loadPrice();

            connection.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThongTinKH tt = new ThongTinKH();
            tt.Show();
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

        private void txb_MaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_HTTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_SoCN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeuThich yt = new YeuThich();
            yt.Show();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            TreEm_KH tt = new TreEm_KH();
            tt.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            LichSu_MuaHang_KH ls = new LichSu_MuaHang_KH();
            ls.Show();
        }
    }
}
