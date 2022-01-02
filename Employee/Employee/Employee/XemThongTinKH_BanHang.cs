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
    public partial class XemThongTinKH_BanHang : Form
    {

        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public XemThongTinKH_BanHang()
        {
            InitializeComponent();
        }

        private void XemThongTinKH_BanHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();


            connection.Close();
        }
        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select MaKH as Mã_KH, HoTenKH as Họ_Tên, SDTKH as SĐT, DIACHIKH as Địa_Chỉ,GioiTinh as Giới_Tính" +
                ",EmailKH as Email from KhachHang where DiaChiKH = N'"+Global.TenChiNhanh+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;


        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(cb_timkiem.Text ==""||txb_timkiem.Text == "")
            {
                MessageBox.Show("Nhập dữ liệu tìm kiếm vào trước", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loaddata();
                return;

            }
            if(cb_timkiem.Text == "Tìm Theo Mã KH")
            {
                loadMaKH();
                loadTreEm();
            }
            if (cb_timkiem.Text == "Tìm Theo Họ Tên")
            {
                loadHoTen();
                loadTreEm();
            }
        }

        private void loadMaKH()
        {
                command = connection.CreateCommand();
                command.CommandText = "select MaKH as Mã_KH, HoTenKH as Họ_Tên, SDTKH as SĐT, DIACHIKH as Địa_Chỉ,GioiTinh as Giới_Tính" +
                    ",EmailKH as Email from KhachHang where MaKH = '"+txb_timkiem.Text+"'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                dgv_1.DataSource = table;


        }
        private void loadHoTen()
        {
            command = connection.CreateCommand();
            command.CommandText = "select MaKH as Mã_KH, HoTenKH as Họ_Tên, SDTKH as SĐT, DIACHIKH as Địa_Chỉ,GioiTinh as Giới_Tính" +
                ",EmailKH as Email from KhachHang where HoTenKH like N'" +txb_timkiem.Text+ "%'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgv_1.DataSource = table;


        }

        private void loadTreEm()
        {
            if(cb_timkiem.Text== "Tìm Theo Mã KH")
            {
            command = connection.CreateCommand();
            command.CommandText = "select * from treem where makh = "+txb_timkiem.Text+"";
            adapter.SelectCommand = command;
            table2.Clear();
            adapter.Fill(table2);

            dgv_2.DataSource = table2;

            }
            else
            {
                command = connection.CreateCommand();
                command.CommandText = "select tt.* from treem tt,khachhang kh where tt.makh = kh.makh and kh.HoTenKH like N'"+txb_timkiem.Text+"%' ";
                adapter.SelectCommand = command;
                table2.Clear();
                adapter.Fill(table2);

                dgv_2.DataSource = table2;
            }
        }

        private void txb_timkiem_TextChanged(object sender, EventArgs e)
        {
            if (txb_timkiem.Text =="")
            {
                loaddata();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_BanHang home = new Home_BanHang();
            home.Show();
        }
    }
}
