
namespace ADMIN
{
    partial class Kho_ChiNhanh
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
            this.cb_MaKho = new System.Windows.Forms.ComboBox();
            this.cb_TenSP = new System.Windows.Forms.ComboBox();
            this.cb_TenChiNhanh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_SoLuong = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_MaChiNhanh = new System.Windows.Forms.ComboBox();
            this.cb_MaSP = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(97, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 55);
            this.button1.TabIndex = 17;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(286, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 36);
            this.label1.TabIndex = 16;
            this.label1.Text = "CUNG CẤP SẢN PHẨM CHO CHI NHÁNH";
            // 
            // dgv_1
            // 
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(99, 162);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(946, 262);
            this.dgv_1.TabIndex = 18;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // cb_MaKho
            // 
            this.cb_MaKho.FormattingEnabled = true;
            this.cb_MaKho.Location = new System.Drawing.Point(301, 465);
            this.cb_MaKho.Name = "cb_MaKho";
            this.cb_MaKho.Size = new System.Drawing.Size(144, 24);
            this.cb_MaKho.TabIndex = 46;
            this.cb_MaKho.SelectedIndexChanged += new System.EventHandler(this.cb_MaKho_SelectedIndexChanged);
            // 
            // cb_TenSP
            // 
            this.cb_TenSP.FormattingEnabled = true;
            this.cb_TenSP.Location = new System.Drawing.Point(593, 522);
            this.cb_TenSP.Name = "cb_TenSP";
            this.cb_TenSP.Size = new System.Drawing.Size(144, 24);
            this.cb_TenSP.TabIndex = 45;
            this.cb_TenSP.SelectedIndexChanged += new System.EventHandler(this.cb_TenSP_SelectedIndexChanged);
            // 
            // cb_TenChiNhanh
            // 
            this.cb_TenChiNhanh.FormattingEnabled = true;
            this.cb_TenChiNhanh.Location = new System.Drawing.Point(301, 519);
            this.cb_TenChiNhanh.Name = "cb_TenChiNhanh";
            this.cb_TenChiNhanh.Size = new System.Drawing.Size(144, 24);
            this.cb_TenChiNhanh.TabIndex = 44;
            this.cb_TenChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cb_TenChiNhanh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Tên Chi Nhánh";
            // 
            // txb_SoLuong
            // 
            this.txb_SoLuong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_SoLuong.Location = new System.Drawing.Point(822, 514);
            this.txb_SoLuong.Name = "txb_SoLuong";
            this.txb_SoLuong.Size = new System.Drawing.Size(150, 22);
            this.txb_SoLuong.TabIndex = 42;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(593, 568);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 49);
            this.button2.TabIndex = 39;
            this.button2.Text = "Cung Cấp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(819, 485);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "Số Lượng Cung Cấp";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(502, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Tên SP";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(502, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Mã Sp";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 568);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "Mã Chi Nhánh";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Mã Kho";
            // 
            // cb_MaChiNhanh
            // 
            this.cb_MaChiNhanh.FormattingEnabled = true;
            this.cb_MaChiNhanh.Location = new System.Drawing.Point(301, 568);
            this.cb_MaChiNhanh.Name = "cb_MaChiNhanh";
            this.cb_MaChiNhanh.Size = new System.Drawing.Size(144, 24);
            this.cb_MaChiNhanh.TabIndex = 47;
            // 
            // cb_MaSP
            // 
            this.cb_MaSP.FormattingEnabled = true;
            this.cb_MaSP.Location = new System.Drawing.Point(593, 461);
            this.cb_MaSP.Name = "cb_MaSP";
            this.cb_MaSP.Size = new System.Drawing.Size(144, 24);
            this.cb_MaSP.TabIndex = 48;
            this.cb_MaSP.SelectedIndexChanged += new System.EventHandler(this.cb_MaSP_SelectedIndexChanged);
            // 
            // Kho_ChiNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 699);
            this.Controls.Add(this.cb_MaSP);
            this.Controls.Add(this.cb_MaChiNhanh);
            this.Controls.Add(this.cb_MaKho);
            this.Controls.Add(this.cb_TenSP);
            this.Controls.Add(this.cb_TenChiNhanh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_SoLuong);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Kho_ChiNhanh";
            this.Text = "Kho_ChiNhanh";
            this.Load += new System.EventHandler(this.Kho_ChiNhanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.ComboBox cb_MaKho;
        private System.Windows.Forms.ComboBox cb_TenSP;
        private System.Windows.Forms.ComboBox cb_TenChiNhanh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_SoLuong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_MaChiNhanh;
        private System.Windows.Forms.ComboBox cb_MaSP;
    }
}