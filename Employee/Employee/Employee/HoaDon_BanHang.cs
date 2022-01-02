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
    public partial class HoaDon_BanHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public HoaDon_BanHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_BanHang home = new Home_BanHang();
            home.Show();
        }

        private void HoaDon_BanHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();
           

            connection.Close();
        }


        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "Select MaHoaDon as Mã_Hóa_Đơn, NgayLap as Ngày_Lập,PhiSanPham as Phí_Sản_Phẩm, PhiVanChuyen as Phí_Vận_Chuyển, TongTien as Tổng_Tiền, " +
                "MaKH as Mã_KH, MaNS as Mã_NS, HinhThucThanhToan as Hình_Thức_Thanh_Toán from HoaDon where ChiNhanh = '"+Global.ChiNhanhLamViec+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            txb_MaNS.Text = Convert.ToString( Global.MaNS);
            dgv_1.DataSource = table;

            command = connection.CreateCommand();
            command.CommandText = "Select TenDV from DonViVanChuyen";
            SqlDataReader datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                string tendonvi = datareader.GetString(0);
                cb_DVVC.Items.Add(tendonvi);
            }
        }

        private void loaddata2()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MaSP as Mã_SP, GiaBan as Gía_Bán, SoLuong as Số_Lượng, ThanhTien as Thành_Tiền from ct_hoadon where mahoadon = '"+txb_MaHD.Text+"'";
            adapter.SelectCommand = command;
            table2.Clear();
            adapter.Fill(table2);
            dgv_2.DataSource = table2;
            command = connection.CreateCommand();
            command.CommandText = "select TinhTrangDH FROM PhieuGiaoHang WHERE MaHD='" + txb_MaHD.Text + "'";
            txb_TinhTrang.Text = command.ExecuteScalar().ToString();
            command = connection.CreateCommand();
            command.CommandText = "select MoTa FROM PhieuGiaoHang WHERE MaHD='" + txb_MaHD.Text + "'";
            txb_MoTa.Text = command.ExecuteScalar().ToString();

            command.CommandText = "select DiaChiGiao FROM PhieuGiaoHang WHERE MaHD='" + txb_MaHD.Text + "'";
            txb_DiaChiGiao.Text = command.ExecuteScalar().ToString();
        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgv_1.CurrentRow.Index;
            txb_MaHD.Text = dgv_1.Rows[i].Cells[0].Value.ToString();
            txb_NgayLap.Text = dgv_1.Rows[i].Cells[2].Value.ToString();
            txb_MaKH.Text = dgv_1.Rows[i].Cells[5].Value.ToString();
            
        }

        private void txb_MaHD_TextChanged(object sender, EventArgs e)
        {
            if(txb_MaHD.Text == "")
            {
                return;
            }
            try
            {
                connection.Open();
                loaddata2();
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txb_MaHD.Text == ""||txb_TinhTrang.Text == "" || cb_DVVC.Text =="")
            {
                MessageBox.Show("Chưa Chọn Đơn Hàng hoặc Chưa Nhập Thông Tin?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xacnhan_donhang_nv", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = Convert.ToInt32(txb_MaHD.Text);
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Convert.ToInt32(txb_MaKH.Text);
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Global.MaNS;
                cmd.Parameters.Add("@TrangThaiDonHang", SqlDbType.NVarChar).Value = txb_TinhTrang.Text;
                cmd.Parameters.Add("@DonViVC", SqlDbType.NVarChar).Value = cb_DVVC.Text;
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật đơn hàng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txb_MaHD.Text == "" )
            {
                MessageBox.Show("Chưa Chọn Đơn Hàng?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("xoadonhang_nv", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaHD", SqlDbType.Int).Value = Convert.ToInt32(txb_MaHD.Text);
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = Convert.ToInt32(txb_MaKH.Text);
                cmd.Parameters.Add("@MaCN", SqlDbType.Int).Value = Convert.ToInt32(Global.ChiNhanhLamViec);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa đơn hàng thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();

                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
