
namespace Employee
{
    partial class HoaDon_BanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.dgv_2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_MaHD = new System.Windows.Forms.TextBox();
            this.txb_MaKH = new System.Windows.Forms.TextBox();
            this.txb_MaNS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_DVVC = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_MoTa = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_NgayLap = new System.Windows.Forms.TextBox();
            this.txb_TinhTrang = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txb_DiaChiGiao = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(468, -77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 44);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nhân viên bán hàng";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(106, -75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 56);
            this.button1.TabIndex = 3;
            this.button1.Text = "Trở về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(135, 29);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(1219, 269);
            this.dgv_1.TabIndex = 4;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // dgv_2
            // 
            this.dgv_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_2.Location = new System.Drawing.Point(135, 347);
            this.dgv_2.Name = "dgv_2";
            this.dgv_2.RowHeadersWidth = 51;
            this.dgv_2.RowTemplate.Height = 24;
            this.dgv_2.Size = new System.Drawing.Size(1219, 173);
            this.dgv_2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(629, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hóa Đơn";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(595, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Chi Tiết Hóa Đơn";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mã HD";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 610);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mã KH";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 694);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã Nhân Sự";
            // 
            // txb_MaHD
            // 
            this.txb_MaHD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaHD.Location = new System.Drawing.Point(347, 568);
            this.txb_MaHD.Name = "txb_MaHD";
            this.txb_MaHD.ReadOnly = true;
            this.txb_MaHD.Size = new System.Drawing.Size(247, 22);
            this.txb_MaHD.TabIndex = 11;
            this.txb_MaHD.TextChanged += new System.EventHandler(this.txb_MaHD_TextChanged);
            // 
            // txb_MaKH
            // 
            this.txb_MaKH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaKH.Location = new System.Drawing.Point(347, 610);
            this.txb_MaKH.Name = "txb_MaKH";
            this.txb_MaKH.ReadOnly = true;
            this.txb_MaKH.Size = new System.Drawing.Size(247, 22);
            this.txb_MaKH.TabIndex = 12;
            // 
            // txb_MaNS
            // 
            this.txb_MaNS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaNS.Location = new System.Drawing.Point(347, 691);
            this.txb_MaNS.Name = "txb_MaNS";
            this.txb_MaNS.ReadOnly = true;
            this.txb_MaNS.Size = new System.Drawing.Size(247, 22);
            this.txb_MaNS.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(663, 646);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Trạng Thái ĐH";
            // 
            // cb_DVVC
            // 
            this.cb_DVVC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_DVVC.FormattingEnabled = true;
            this.cb_DVVC.Location = new System.Drawing.Point(811, 688);
            this.cb_DVVC.Name = "cb_DVVC";
            this.cb_DVVC.Size = new System.Drawing.Size(167, 24);
            this.cb_DVVC.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(663, 691);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Đơn Vị Vận Chuyển";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(663, 607);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Mô Tả";
            // 
            // txb_MoTa
            // 
            this.txb_MoTa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MoTa.Location = new System.Drawing.Point(811, 604);
            this.txb_MoTa.Name = "txb_MoTa";
            this.txb_MoTa.ReadOnly = true;
            this.txb_MoTa.Size = new System.Drawing.Size(396, 22);
            this.txb_MoTa.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(546, 732);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 53);
            this.button2.TabIndex = 20;
            this.button2.Text = "Xác Nhận Đơn Hàng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 646);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ngày Lập";
            // 
            // txb_NgayLap
            // 
            this.txb_NgayLap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_NgayLap.Location = new System.Drawing.Point(347, 646);
            this.txb_NgayLap.Name = "txb_NgayLap";
            this.txb_NgayLap.ReadOnly = true;
            this.txb_NgayLap.Size = new System.Drawing.Size(247, 22);
            this.txb_NgayLap.TabIndex = 22;
            // 
            // txb_TinhTrang
            // 
            this.txb_TinhTrang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TinhTrang.Location = new System.Drawing.Point(811, 646);
            this.txb_TinhTrang.Name = "txb_TinhTrang";
            this.txb_TinhTrang.Size = new System.Drawing.Size(242, 22);
            this.txb_TinhTrang.TabIndex = 23;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(735, 732);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 53);
            this.button3.TabIndex = 24;
            this.button3.Text = "Xóa Đơn Hàng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txb_DiaChiGiao
            // 
            this.txb_DiaChiGiao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_DiaChiGiao.Location = new System.Drawing.Point(811, 563);
            this.txb_DiaChiGiao.Name = "txb_DiaChiGiao";
            this.txb_DiaChiGiao.ReadOnly = true;
            this.txb_DiaChiGiao.Size = new System.Drawing.Size(396, 22);
            this.txb_DiaChiGiao.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(663, 568);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "Địa Chỉ Giao";
            // 
            // HoaDon_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 797);
            this.Controls.Add(this.txb_DiaChiGiao);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txb_TinhTrang);
            this.Controls.Add(this.txb_NgayLap);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txb_MoTa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_DVVC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_MaNS);
            this.Controls.Add(this.txb_MaKH);
            this.Controls.Add(this.txb_MaHD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_2);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Name = "HoaDon_BanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HoaDon_BanHang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HoaDon_BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.DataGridView dgv_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_MaHD;
        private System.Windows.Forms.TextBox txb_MaKH;
        private System.Windows.Forms.TextBox txb_MaNS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_DVVC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_MoTa;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_NgayLap;
        private System.Windows.Forms.TextBox txb_TinhTrang;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txb_DiaChiGiao;
        private System.Windows.Forms.Label label11;
    }
}