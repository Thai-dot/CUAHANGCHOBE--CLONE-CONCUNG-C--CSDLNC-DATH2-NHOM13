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
    public partial class ThongTinCaNhan_BanHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongTinCaNhan_BanHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(Global.Loai_NS=="Bán hàng")
            {
                Home_BanHang home = new Home_BanHang();
                home.Show();
            }
            else
            {
                Home_QuanLy home = new Home_QuanLy();
                home.Show();
            }
            

        }

        private void dgv_1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThongTinCaNhan_BanHang_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();


            connection.Close();
        }

        private void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select MaNS as Mã_NS, HoTenNS as Họ_Tên, DiaChiNS as Địa_Chỉ, " +
                "SDTNS as SĐT, LuongNS as Lương_VNĐ from NhanSu where MaNS = '" + Global.MaNS + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
           
            dgv_1.DataSource = table;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txb_MKCu.Text ==""||txb_MKMoi.Text == "" || txb_NLMK.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select MatKhauNS FROM TK_NhanSu WHERE MaNS='" + Global.MaNS + "'";
            string check1 = command.ExecuteScalar().ToString();
            Console.WriteLine(check1);
            if(txb_MKCu.Text != check1.Trim())
            {
                MessageBox.Show("Mật khẩu cũ không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(txb_MKMoi.Text != txb_NLMK.Text)
            {
                MessageBox.Show("Mật khẩu mới không trùng nhau", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {

                    connection = new SqlConnection(Global.strconnect);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("doimatkhau_nvbh", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Global.MaNS;
                    cmd.Parameters.Add("@MatKhauMoi", SqlDbType.Char).Value = txb_MKMoi.Text;
                 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thay đổi mật khẩu thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
              

                    connection.Close();
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            

        }
    }
}
