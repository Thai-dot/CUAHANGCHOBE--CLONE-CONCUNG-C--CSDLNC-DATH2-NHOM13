
namespace Employee
{
    partial class TaoHopDong_QuanLy
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_DanhSach = new System.Windows.Forms.Label();
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.dgv_2 = new System.Windows.Forms.DataGridView();
            this.label_Hopdong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txb_MaHD = new System.Windows.Forms.TextBox();
            this.txb_MaSOThue = new System.Windows.Forms.TextBox();
            this.date_NgayLap = new System.Windows.Forms.DateTimePicker();
            this.date_NgayDenHan = new System.Windows.Forms.DateTimePicker();
            this.txb_TinhTrang = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txb_MaDT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(376, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 44);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ký Kết Hợp Đồng";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(80, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 56);
            this.button1.TabIndex = 2;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_DanhSach
            // 
            this.label_DanhSach.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_DanhSach.AutoSize = true;
            this.label_DanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DanhSach.Location = new System.Drawing.Point(334, 144);
            this.label_DanhSach.Name = "label_DanhSach";
            this.label_DanhSach.Size = new System.Drawing.Size(307, 32);
            this.label_DanhSach.TabIndex = 4;
            this.label_DanhSach.Text = "Danh Sách Đối Tác Ở";
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(73, 202);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(943, 160);
            this.dgv_1.TabIndex = 5;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgv_2
            // 
            this.dgv_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_2.Location = new System.Drawing.Point(73, 466);
            this.dgv_2.Name = "dgv_2";
            this.dgv_2.RowHeadersWidth = 51;
            this.dgv_2.RowTemplate.Height = 24;
            this.dgv_2.Size = new System.Drawing.Size(943, 160);
            this.dgv_2.TabIndex = 6;
            this.dgv_2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_2_CellContentClick);
            // 
            // label_Hopdong
            // 
            this.label_Hopdong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Hopdong.AutoSize = true;
            this.label_Hopdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hopdong.Location = new System.Drawing.Point(334, 395);
            this.label_Hopdong.Name = "label_Hopdong";
            this.label_Hopdong.Size = new System.Drawing.Size(175, 32);
            this.label_Hopdong.TabIndex = 7;
            this.label_Hopdong.Text = "HỢP ĐỒNG";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 689);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã Hợp Đồng";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 730);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày Lập";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 689);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ngày Đến Hạn";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 728);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Mã Số Thuế";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(663, 689);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tình Trạng";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(738, 720);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 42);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cập Nhật/Tạo Mới Hợp Đồng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txb_MaHD
            // 
            this.txb_MaHD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaHD.Location = new System.Drawing.Point(186, 684);
            this.txb_MaHD.Name = "txb_MaHD";
            this.txb_MaHD.Size = new System.Drawing.Size(112, 22);
            this.txb_MaHD.TabIndex = 14;
            // 
            // txb_MaSOThue
            // 
            this.txb_MaSOThue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaSOThue.Location = new System.Drawing.Point(461, 728);
            this.txb_MaSOThue.Name = "txb_MaSOThue";
            this.txb_MaSOThue.Size = new System.Drawing.Size(160, 22);
            this.txb_MaSOThue.TabIndex = 15;
            // 
            // date_NgayLap
            // 
            this.date_NgayLap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_NgayLap.Location = new System.Drawing.Point(186, 728);
            this.date_NgayLap.Name = "date_NgayLap";
            this.date_NgayLap.Size = new System.Drawing.Size(113, 22);
            this.date_NgayLap.TabIndex = 16;
            // 
            // date_NgayDenHan
            // 
            this.date_NgayDenHan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.date_NgayDenHan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_NgayDenHan.Location = new System.Drawing.Point(460, 689);
            this.date_NgayDenHan.Name = "date_NgayDenHan";
            this.date_NgayDenHan.Size = new System.Drawing.Size(161, 22);
            this.date_NgayDenHan.TabIndex = 17;
            // 
            // txb_TinhTrang
            // 
            this.txb_TinhTrang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TinhTrang.Location = new System.Drawing.Point(758, 686);
            this.txb_TinhTrang.Name = "txb_TinhTrang";
            this.txb_TinhTrang.Size = new System.Drawing.Size(182, 22);
            this.txb_TinhTrang.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 646);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Mã Đối Tác";
            // 
            // txb_MaDT
            // 
            this.txb_MaDT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaDT.Location = new System.Drawing.Point(187, 646);
            this.txb_MaDT.Name = "txb_MaDT";
            this.txb_MaDT.ReadOnly = true;
            this.txb_MaDT.Size = new System.Drawing.Size(112, 22);
            this.txb_MaDT.TabIndex = 20;
            // 
            // TaoHopDong_QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 807);
            this.Controls.Add(this.txb_MaDT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txb_TinhTrang);
            this.Controls.Add(this.date_NgayDenHan);
            this.Controls.Add(this.date_NgayLap);
            this.Controls.Add(this.txb_MaSOThue);
            this.Controls.Add(this.txb_MaHD);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Hopdong);
            this.Controls.Add(this.dgv_2);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.label_DanhSach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "TaoHopDong_QuanLy";
            this.Text = "TaoHopDong_QuanLy";
            this.Load += new System.EventHandler(this.TaoHopDong_QuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_DanhSach;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.DataGridView dgv_2;
        private System.Windows.Forms.Label label_Hopdong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txb_MaHD;
        private System.Windows.Forms.TextBox txb_MaSOThue;
        private System.Windows.Forms.DateTimePicker date_NgayLap;
        private System.Windows.Forms.DateTimePicker date_NgayDenHan;
        private System.Windows.Forms.TextBox txb_TinhTrang;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txb_MaDT;
    }
}