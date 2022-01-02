
namespace Employee
{
    partial class ThongKeDoanhThu_QuanLy
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ChonBang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_Thang = new System.Windows.Forms.ComboBox();
            this.txb_TongTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_DoanhThu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_MaHoaDon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(57, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(418, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "XEM SỐ LIỆU CÁC BẢNG";
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(47, 148);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(1064, 327);
            this.dgv_1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chọn Bảng";
            // 
            // cb_ChonBang
            // 
            this.cb_ChonBang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_ChonBang.FormattingEnabled = true;
            this.cb_ChonBang.Items.AddRange(new object[] {
            "HOADON",
            "CT_HOADON"});
            this.cb_ChonBang.Location = new System.Drawing.Point(147, 109);
            this.cb_ChonBang.Name = "cb_ChonBang";
            this.cb_ChonBang.Size = new System.Drawing.Size(168, 24);
            this.cb_ChonBang.TabIndex = 4;
            this.cb_ChonBang.SelectedIndexChanged += new System.EventHandler(this.cb_ChonBang_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 499);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sort";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 558);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tháng";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 616);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng Tiền (>)";
            // 
            // cb_Thang
            // 
            this.cb_Thang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_Thang.FormattingEnabled = true;
            this.cb_Thang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cb_Thang.Location = new System.Drawing.Point(271, 555);
            this.cb_Thang.Name = "cb_Thang";
            this.cb_Thang.Size = new System.Drawing.Size(168, 24);
            this.cb_Thang.TabIndex = 8;
            this.cb_Thang.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txb_TongTien
            // 
            this.txb_TongTien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TongTien.Location = new System.Drawing.Point(271, 613);
            this.txb_TongTien.Name = "txb_TongTien";
            this.txb_TongTien.Size = new System.Drawing.Size(144, 22);
            this.txb_TongTien.TabIndex = 9;
            this.txb_TongTien.TextChanged += new System.EventHandler(this.txb_TongTien_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(582, 555);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tổng Doanh Thu";
            // 
            // txb_DoanhThu
            // 
            this.txb_DoanhThu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_DoanhThu.Location = new System.Drawing.Point(734, 552);
            this.txb_DoanhThu.Name = "txb_DoanhThu";
            this.txb_DoanhThu.ReadOnly = true;
            this.txb_DoanhThu.Size = new System.Drawing.Size(190, 22);
            this.txb_DoanhThu.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(592, 613);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Mã Hóa Đơn";
            // 
            // txb_MaHoaDon
            // 
            this.txb_MaHoaDon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaHoaDon.Location = new System.Drawing.Point(734, 613);
            this.txb_MaHoaDon.Name = "txb_MaHoaDon";
            this.txb_MaHoaDon.Size = new System.Drawing.Size(190, 22);
            this.txb_MaHoaDon.TabIndex = 14;
            this.txb_MaHoaDon.TextChanged += new System.EventHandler(this.txb_MaHoaDon_TextChanged);
            // 
            // ThongKeDoanhThu_QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 767);
            this.Controls.Add(this.txb_MaHoaDon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_DoanhThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txb_TongTien);
            this.Controls.Add(this.cb_Thang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_ChonBang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "ThongKeDoanhThu_QuanLy";
            this.Text = "ThongKeDoanhThu_QuanLy";
            this.Load += new System.EventHandler(this.ThongKeDoanhThu_QuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ChonBang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_Thang;
        private System.Windows.Forms.TextBox txb_TongTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_DoanhThu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_MaHoaDon;
    }
}