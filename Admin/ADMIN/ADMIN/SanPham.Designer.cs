
namespace ADMIN
{
    partial class SanPham
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
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txb_MaSP = new System.Windows.Forms.TextBox();
            this.txb_TenSP = new System.Windows.Forms.TextBox();
            this.txb_GiaBan = new System.Windows.Forms.TextBox();
            this.txb_GiaMua = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txb_MucGiam = new System.Windows.Forms.TextBox();
            this.txb_TenDT = new System.Windows.Forms.TextBox();
            this.cb_MaGG = new System.Windows.Forms.ComboBox();
            this.cb_MaDT = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txb_LoaiSP = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(470, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(62, 129);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(1107, 422);
            this.dgv_1.TabIndex = 1;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(127, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 55);
            this.button1.TabIndex = 2;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 601);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã SP";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 663);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên SP";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 727);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Giá Bán";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(485, 601);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Giá Mua";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(485, 663);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mã GG";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(804, 598);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tên Đối Tác";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(804, 663);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Mức Giảm";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(485, 727);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Mã Đối Tác";
            // 
            // txb_MaSP
            // 
            this.txb_MaSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaSP.Location = new System.Drawing.Point(213, 601);
            this.txb_MaSP.Name = "txb_MaSP";
            this.txb_MaSP.Size = new System.Drawing.Size(193, 22);
            this.txb_MaSP.TabIndex = 11;
            // 
            // txb_TenSP
            // 
            this.txb_TenSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TenSP.Location = new System.Drawing.Point(213, 663);
            this.txb_TenSP.Name = "txb_TenSP";
            this.txb_TenSP.Size = new System.Drawing.Size(193, 22);
            this.txb_TenSP.TabIndex = 12;
            // 
            // txb_GiaBan
            // 
            this.txb_GiaBan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_GiaBan.Location = new System.Drawing.Point(213, 722);
            this.txb_GiaBan.Name = "txb_GiaBan";
            this.txb_GiaBan.Size = new System.Drawing.Size(193, 22);
            this.txb_GiaBan.TabIndex = 13;
            // 
            // txb_GiaMua
            // 
            this.txb_GiaMua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_GiaMua.Location = new System.Drawing.Point(571, 598);
            this.txb_GiaMua.Name = "txb_GiaMua";
            this.txb_GiaMua.Size = new System.Drawing.Size(193, 22);
            this.txb_GiaMua.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(807, 701);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 65);
            this.button2.TabIndex = 18;
            this.button2.Text = "Xóa SP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(993, 701);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 65);
            this.button3.TabIndex = 19;
            this.button3.Text = "THÊM/SỬA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txb_MucGiam
            // 
            this.txb_MucGiam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MucGiam.Location = new System.Drawing.Point(924, 663);
            this.txb_MucGiam.Name = "txb_MucGiam";
            this.txb_MucGiam.ReadOnly = true;
            this.txb_MucGiam.Size = new System.Drawing.Size(163, 22);
            this.txb_MucGiam.TabIndex = 20;
            // 
            // txb_TenDT
            // 
            this.txb_TenDT.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TenDT.Location = new System.Drawing.Point(924, 596);
            this.txb_TenDT.Name = "txb_TenDT";
            this.txb_TenDT.ReadOnly = true;
            this.txb_TenDT.Size = new System.Drawing.Size(163, 22);
            this.txb_TenDT.TabIndex = 21;
            // 
            // cb_MaGG
            // 
            this.cb_MaGG.FormattingEnabled = true;
            this.cb_MaGG.Location = new System.Drawing.Point(571, 663);
            this.cb_MaGG.Name = "cb_MaGG";
            this.cb_MaGG.Size = new System.Drawing.Size(193, 24);
            this.cb_MaGG.TabIndex = 22;
            this.cb_MaGG.SelectedIndexChanged += new System.EventHandler(this.cb_MaGG_SelectedIndexChanged);
            // 
            // cb_MaDT
            // 
            this.cb_MaDT.FormattingEnabled = true;
            this.cb_MaDT.Location = new System.Drawing.Point(571, 720);
            this.cb_MaDT.Name = "cb_MaDT";
            this.cb_MaDT.Size = new System.Drawing.Size(193, 24);
            this.cb_MaDT.TabIndex = 23;
            this.cb_MaDT.SelectedIndexChanged += new System.EventHandler(this.cb_MaDT_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 780);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Loại SP";
            // 
            // txb_LoaiSP
            // 
            this.txb_LoaiSP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_LoaiSP.Location = new System.Drawing.Point(213, 775);
            this.txb_LoaiSP.Name = "txb_LoaiSP";
            this.txb_LoaiSP.Size = new System.Drawing.Size(193, 22);
            this.txb_LoaiSP.TabIndex = 25;
            // 
            // SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 827);
            this.Controls.Add(this.txb_LoaiSP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_MaDT);
            this.Controls.Add(this.cb_MaGG);
            this.Controls.Add(this.txb_TenDT);
            this.Controls.Add(this.txb_MucGiam);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txb_GiaMua);
            this.Controls.Add(this.txb_GiaBan);
            this.Controls.Add(this.txb_TenSP);
            this.Controls.Add(this.txb_MaSP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.label1);
            this.Name = "SanPham";
            this.Text = "SanPham";
            this.Load += new System.EventHandler(this.SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txb_MaSP;
        private System.Windows.Forms.TextBox txb_TenSP;
        private System.Windows.Forms.TextBox txb_GiaBan;
        private System.Windows.Forms.TextBox txb_GiaMua;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txb_MucGiam;
        private System.Windows.Forms.TextBox txb_TenDT;
        private System.Windows.Forms.ComboBox cb_MaGG;
        private System.Windows.Forms.ComboBox cb_MaDT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txb_LoaiSP;
    }
}