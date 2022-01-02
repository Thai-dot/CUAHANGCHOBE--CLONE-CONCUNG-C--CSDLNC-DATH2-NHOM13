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
    public partial class DiemDanh_BanHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DiemDanh_BanHang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(Global.Loai_NS == "Bán hàng")
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                SqlCommand cmd = new SqlCommand("diemdanh_nhansu", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNS", SqlDbType.Int).Value = Global.MaNS;
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("Điểm danh thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                connection.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
