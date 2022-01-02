
namespace ADMIN
{
    partial class Kho_DoiTac
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txb_SoLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_TenDoiTac = new System.Windows.Forms.ComboBox();
            this.cb_TenSP = new System.Windows.Forms.ComboBox();
            this.cb_MaKho = new System.Windows.Forms.ComboBox();
            this.cb_MaSP = new System.Windows.Forms.ComboBox();
            this.cb_MaDT = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(219, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 55);
            this.button1.TabIndex = 15;
            this.button1.Text = "Trở Về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(434, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 36);
            this.label1.TabIndex = 14;
            this.label1.Text = "ĐỐI TÁC CUNG CẤP KHO";
            // 
            // dgv_1
            // 
            this.dgv_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_1.Location = new System.Drawing.Point(147, 155);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(845, 279);
            this.dgv_1.TabIndex = 18;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 488);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Mã Kho";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 486);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mã Sp";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 540);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Tên SP";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(815, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Số Lượng Cung Cấp";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(589, 586);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 49);
            this.button2.TabIndex = 24;
            this.button2.Text = "Cung Cấp";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txb_SoLuong
            // 
            this.txb_SoLuong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_SoLuong.Location = new System.Drawing.Point(818, 532);
            this.txb_SoLuong.Name = "txb_SoLuong";
            this.txb_SoLuong.Size = new System.Drawing.Size(150, 22);
            this.txb_SoLuong.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 586);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mã Đối Tác";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tên Đối Tác";
            // 
            // cb_TenDoiTac
            // 
            this.cb_TenDoiTac.FormattingEnabled = true;
            this.cb_TenDoiTac.Location = new System.Drawing.Point(297, 537);
            this.cb_TenDoiTac.Name = "cb_TenDoiTac";
            this.cb_TenDoiTac.Size = new System.Drawing.Size(144, 24);
            this.cb_TenDoiTac.TabIndex = 31;
            this.cb_TenDoiTac.SelectedIndexChanged += new System.EventHandler(this.cb_TenDoiTac_SelectedIndexChanged);
            // 
            // cb_TenSP
            // 
            this.cb_TenSP.FormattingEnabled = true;
            this.cb_TenSP.Location = new System.Drawing.Point(589, 540);
            this.cb_TenSP.Name = "cb_TenSP";
            this.cb_TenSP.Size = new System.Drawing.Size(144, 24);
            this.cb_TenSP.TabIndex = 32;
            this.cb_TenSP.SelectedIndexChanged += new System.EventHandler(this.cb_TenSP_SelectedIndexChanged);
            // 
            // cb_MaKho
            // 
            this.cb_MaKho.FormattingEnabled = true;
            this.cb_MaKho.Location = new System.Drawing.Point(297, 483);
            this.cb_MaKho.Name = "cb_MaKho";
            this.cb_MaKho.Size = new System.Drawing.Size(144, 24);
            this.cb_MaKho.TabIndex = 33;
            // 
            // cb_MaSP
            // 
            this.cb_MaSP.FormattingEnabled = true;
            this.cb_MaSP.Location = new System.Drawing.Point(589, 485);
            this.cb_MaSP.Name = "cb_MaSP";
            this.cb_MaSP.Size = new System.Drawing.Size(144, 24);
            this.cb_MaSP.TabIndex = 34;
            this.cb_MaSP.SelectedIndexChanged += new System.EventHandler(this.cb_MaSP_SelectedIndexChanged);
            // 
            // cb_MaDT
            // 
            this.cb_MaDT.FormattingEnabled = true;
            this.cb_MaDT.Location = new System.Drawing.Point(297, 586);
            this.cb_MaDT.Name = "cb_MaDT";
            this.cb_MaDT.Size = new System.Drawing.Size(144, 24);
            this.cb_MaDT.TabIndex = 35;
            this.cb_MaDT.SelectedIndexChanged += new System.EventHandler(this.cb_MaDT_SelectedIndexChanged);
            this.cb_MaDT.TextChanged += new System.EventHandler(this.cb_MaDT_TextChanged);
            // 
            // Kho_DoiTac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 758);
            this.Controls.Add(this.cb_MaDT);
            this.Controls.Add(this.cb_MaSP);
            this.Controls.Add(this.cb_MaKho);
            this.Controls.Add(this.cb_TenSP);
            this.Controls.Add(this.cb_TenDoiTac);
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
            this.Name = "Kho_DoiTac";
            this.Text = "Kho_DoiTac";
            this.Load += new System.EventHandler(this.Kho_DoiTac_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txb_SoLuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_TenDoiTac;
        private System.Windows.Forms.ComboBox cb_TenSP;
        private System.Windows.Forms.ComboBox cb_MaKho;
        private System.Windows.Forms.ComboBox cb_MaSP;
        private System.Windows.Forms.ComboBox cb_MaDT;
    }
}