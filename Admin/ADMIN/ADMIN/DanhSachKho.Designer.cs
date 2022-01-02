
namespace ADMIN
{
    partial class DanhSachKho
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
            this.cb_DiaChi = new System.Windows.Forms.ComboBox();
            this.dgv_2 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txb_MaKHo = new System.Windows.Forms.TextBox();
            this.txb_TenKho = new System.Windows.Forms.TextBox();
            this.txb_DiaChi = new System.Windows.Forms.TextBox();
            this.txb_SoDienThoai = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(96, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 55);
            this.button1.TabIndex = 10;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(446, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "DANH SÁCH CÁC KHO";
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(55, 132);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(985, 198);
            this.dgv_1.TabIndex = 11;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Địa Chỉ";
            // 
            // cb_DiaChi
            // 
            this.cb_DiaChi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cb_DiaChi.FormattingEnabled = true;
            this.cb_DiaChi.Location = new System.Drawing.Point(193, 89);
            this.cb_DiaChi.Name = "cb_DiaChi";
            this.cb_DiaChi.Size = new System.Drawing.Size(228, 24);
            this.cb_DiaChi.TabIndex = 13;
            this.cb_DiaChi.SelectedIndexChanged += new System.EventHandler(this.cb_DiaChi_SelectedIndexChanged);
            // 
            // dgv_2
            // 
            this.dgv_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_2.Location = new System.Drawing.Point(52, 377);
            this.dgv_2.Name = "dgv_2";
            this.dgv_2.RowHeadersWidth = 51;
            this.dgv_2.RowTemplate.Height = 24;
            this.dgv_2.Size = new System.Drawing.Size(985, 182);
            this.dgv_2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 616);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Mã Kho";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 670);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tên Kho";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 616);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Địa Chỉ Kho";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(350, 670);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Số Điện Thoại";
            // 
            // txb_MaKHo
            // 
            this.txb_MaKHo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MaKHo.Location = new System.Drawing.Point(163, 616);
            this.txb_MaKHo.Name = "txb_MaKHo";
            this.txb_MaKHo.Size = new System.Drawing.Size(129, 22);
            this.txb_MaKHo.TabIndex = 19;
            this.txb_MaKHo.TextChanged += new System.EventHandler(this.txb_MaKHo_TextChanged);
            // 
            // txb_TenKho
            // 
            this.txb_TenKho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_TenKho.Location = new System.Drawing.Point(163, 665);
            this.txb_TenKho.Name = "txb_TenKho";
            this.txb_TenKho.Size = new System.Drawing.Size(129, 22);
            this.txb_TenKho.TabIndex = 20;
            // 
            // txb_DiaChi
            // 
            this.txb_DiaChi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_DiaChi.Location = new System.Drawing.Point(467, 611);
            this.txb_DiaChi.Name = "txb_DiaChi";
            this.txb_DiaChi.Size = new System.Drawing.Size(129, 22);
            this.txb_DiaChi.TabIndex = 21;
            // 
            // txb_SoDienThoai
            // 
            this.txb_SoDienThoai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_SoDienThoai.Location = new System.Drawing.Point(467, 670);
            this.txb_SoDienThoai.Name = "txb_SoDienThoai";
            this.txb_SoDienThoai.Size = new System.Drawing.Size(129, 22);
            this.txb_SoDienThoai.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(738, 601);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 53);
            this.button2.TabIndex = 23;
            this.button2.Text = "Thêm Kho Mới";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(925, 601);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 53);
            this.button3.TabIndex = 24;
            this.button3.Text = "Sửa TT Kho";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(820, 670);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 53);
            this.button4.TabIndex = 25;
            this.button4.Text = "Xóa Kho";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DanhSachKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 771);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txb_SoDienThoai);
            this.Controls.Add(this.txb_DiaChi);
            this.Controls.Add(this.txb_TenKho);
            this.Controls.Add(this.txb_MaKHo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_2);
            this.Controls.Add(this.cb_DiaChi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachKho";
            this.Text = "DanhSachKho";
            this.Load += new System.EventHandler(this.DanhSachKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_DiaChi;
        private System.Windows.Forms.DataGridView dgv_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txb_MaKHo;
        private System.Windows.Forms.TextBox txb_TenKho;
        private System.Windows.Forms.TextBox txb_DiaChi;
        private System.Windows.Forms.TextBox txb_SoDienThoai;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}