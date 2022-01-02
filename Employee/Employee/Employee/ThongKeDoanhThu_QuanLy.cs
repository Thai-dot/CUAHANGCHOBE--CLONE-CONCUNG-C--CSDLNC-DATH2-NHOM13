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
    public partial class ThongKeDoanhThu_QuanLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        public ThongKeDoanhThu_QuanLy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_QuanLy HOME = new Home_QuanLy();
            HOME.Show();
        }

        private void ThongKeDoanhThu_QuanLy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(Global.strconnect);
            connection.Open();
            loaddata();


            connection.Close();
        }
        private void loaddata()
        {
            if(cb_ChonBang.Text == "")
            {
                return;
            }
            if(cb_ChonBang.Text=="HOADON")
            {
                command = connection.CreateCommand();
                command.CommandText = "select * from HoaDon where ChiNhanh='"+Global.ChiNhanhLamViec+"'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dgv_1.DataSource = table;

                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "Select sum(TongTien) from HoaDon where ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                txb_DoanhThu.Text = Convert.ToString(command.ExecuteScalar());
                connection.Close();
            }
            if(cb_ChonBang.Text == "CT_HOADON")
            {
                command = connection.CreateCommand();
                command.CommandText = "select ct.MaHoaDon,ct.MaSP,ct.GiaBan,ct.SoLuong,ct.ThanhTien " +
                    "from CT_HoaDon ct,HoaDon hd where hd.MaHoaDon=ct.MaHoaDon and hd.ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                adapter.SelectCommand = command;
                table2.Clear();
                adapter.Fill(table2);
                dgv_1.DataSource = table2;
                connection = new SqlConnection(Global.strconnect);
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = "Select sum(ct.ThanhTien) from CT_HoaDon ct," +
                    "HoaDon hd where hd.MaHoaDon=ct.MaHoaDon and hd.ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                txb_DoanhThu.Text = Convert.ToString(command.ExecuteScalar());
                connection.Close();
            }
            

        }

        private void cb_ChonBang_SelectedIndexChanged(object sender, EventArgs e)
        {

            loaddata();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cb_ChonBang.Text == "" || cb_Thang.Text == "")
            {
                loaddata();
                return;
            }
            else
            {
                txb_MaHoaDon.Text = "";
                txb_TongTien.Text = "";
                if (cb_ChonBang.Text == "HOADON")
                {
                    DataTable table3 = new DataTable();
                    connection = new SqlConnection(Global.strconnect);
                    command = connection.CreateCommand();
                    command.CommandText = "select * from HoaDon where Month(NgayLap) = " + cb_Thang.Text + " and ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table3);
                    dgv_1.DataSource = table3;
                    if (dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                        txb_DoanhThu.Text = dgv_1.Rows[0].Cells[4].Value.ToString();

                    }
                }
                else
                {
                    DataTable table3 = new DataTable();
                    connection = new SqlConnection(Global.strconnect);
                    command = connection.CreateCommand();
                    command.CommandText = "select ct.MaHoaDon,ct.MaSP,ct.GiaBan,ct.SoLuong,ct.ThanhTien " +
                    "from CT_HoaDon ct,HoaDon hd where Month(hd.NgayLap) = " + cb_Thang.Text + " and hd.MaHoaDon=ct.MaHoaDon and hd.ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table3);
                    dgv_1.DataSource = table3;
                    if (dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                        int n = dgv_1.Rows.Count;
                        double tongtien = 0;
                        for (int i = 0; i < n - 1; i++)
                        {
                            tongtien += Convert.ToDouble(dgv_1.Rows[i].Cells[4].Value.ToString());
                        }
                        txb_DoanhThu.Text = Convert.ToString(tongtien);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(cb_Thang.Text == "" && txb_MaHoaDon.Text == ""&& txb_TongTien.Text == "")
            {
                MessageBox.Show("Chưa điền thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(cb_Thang.Text != "")
            {

            }
        }

        private void txb_MaHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (cb_ChonBang.Text == "" ||txb_MaHoaDon.Text=="")
            {
                loaddata();
                return;

            }
            else
            {
                cb_Thang.Text = "";
                txb_TongTien.Text = "";
                if (cb_ChonBang.Text == "HOADON")
                {
                DataTable table3 = new DataTable();
                connection = new SqlConnection(Global.strconnect);
                command = connection.CreateCommand();
                command.CommandText = "select * from HoaDon where MaHoaDon = "+txb_MaHoaDon.Text+" and ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table3);
                dgv_1.DataSource = table3;
                if(dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                      txb_DoanhThu.Text =   dgv_1.Rows[0].Cells[4].Value.ToString();
                        
                    }
                }
                else
                {
                    DataTable table3 = new DataTable();
                    connection = new SqlConnection(Global.strconnect);
                    command = connection.CreateCommand();
                    command.CommandText = "select ct.MaHoaDon,ct.MaSP,ct.GiaBan,ct.SoLuong,ct.ThanhTien " +
                    "from CT_HoaDon ct,HoaDon hd where ct.MaHoaDon="+txb_MaHoaDon.Text+" and hd.MaHoaDon=ct.MaHoaDon and hd.ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table3);
                    dgv_1.DataSource = table3;
                    if (dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                        int n = dgv_1.Rows.Count;
                        double tongtien = 0;
                        for (int i = 0; i < n-1; i++)
                        {
                            tongtien += Convert.ToDouble(dgv_1.Rows[i].Cells[4].Value.ToString());
                        }
                        txb_DoanhThu.Text = Convert.ToString(tongtien);
                    }
                }

            }
        }

        private void txb_TongTien_TextChanged(object sender, EventArgs e)
        {
            if (cb_ChonBang.Text == "" || txb_TongTien.Text == "")
            {
                loaddata();
                return;

            }
            else
            {
                cb_Thang.Text = "";
                txb_MaHoaDon.Text = "";
                if (cb_ChonBang.Text == "HOADON")
                {
                    DataTable table3 = new DataTable();
                    connection = new SqlConnection(Global.strconnect);
                    command = connection.CreateCommand();
                    command.CommandText = "select * from HoaDon where TongTien > " + txb_TongTien.Text + " and ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table3);
                    dgv_1.DataSource = table3;
                    if (dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                        txb_DoanhThu.Text = dgv_1.Rows[0].Cells[4].Value.ToString();

                    }
                }
                else
                {
                    DataTable table3 = new DataTable();
                    connection = new SqlConnection(Global.strconnect);
                    command = connection.CreateCommand();
                    command.CommandText = "select ct.MaHoaDon,ct.MaSP,ct.GiaBan,ct.SoLuong,ct.ThanhTien " +
                    "from CT_HoaDon ct,HoaDon hd where hd.TongTien > " + txb_TongTien.Text + " and hd.MaHoaDon=ct.MaHoaDon and hd.ChiNhanh='" + Global.ChiNhanhLamViec + "'";
                    adapter.SelectCommand = command;
                    table.Clear();
                    adapter.Fill(table3);
                    dgv_1.DataSource = table3;
                    if (dgv_1.Rows.Count < 2)
                    {
                        txb_DoanhThu.Text = "";
                    }
                    else
                    {
                        int n = dgv_1.Rows.Count;
                        double tongtien = 0;
                        for (int i = 0; i < n - 1; i++)
                        {
                            tongtien += Convert.ToDouble(dgv_1.Rows[i].Cells[4].Value.ToString());
                        }
                        txb_DoanhThu.Text = Convert.ToString(tongtien);
                    }
                }

            }
        }
    }
}
