
namespace Employee
{
    partial class ThongTinCaNhan_BanHang
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
            this.dgv_1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txb_MKCu = new System.Windows.Forms.TextBox();
            this.txb_MKMoi = new System.Windows.Forms.TextBox();
            this.txb_NLMK = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(128, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 53);
            this.button1.TabIndex = 0;
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
            this.dgv_1.Location = new System.Drawing.Point(128, 194);
            this.dgv_1.Name = "dgv_1";
            this.dgv_1.RowHeadersWidth = 51;
            this.dgv_1.RowTemplate.Height = 24;
            this.dgv_1.Size = new System.Drawing.Size(898, 94);
            this.dgv_1.TabIndex = 1;
            this.dgv_1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_1_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập Mật Khẩu Cũ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật Khẩu Mới";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nhập Lại Mật Khẩu Mới";
            // 
            // txb_MKCu
            // 
            this.txb_MKCu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MKCu.Location = new System.Drawing.Point(325, 374);
            this.txb_MKCu.Name = "txb_MKCu";
            this.txb_MKCu.Size = new System.Drawing.Size(184, 22);
            this.txb_MKCu.TabIndex = 6;
            this.txb_MKCu.UseSystemPasswordChar = true;
            // 
            // txb_MKMoi
            // 
            this.txb_MKMoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_MKMoi.Location = new System.Drawing.Point(325, 445);
            this.txb_MKMoi.Name = "txb_MKMoi";
            this.txb_MKMoi.Size = new System.Drawing.Size(184, 22);
            this.txb_MKMoi.TabIndex = 7;
            this.txb_MKMoi.UseSystemPasswordChar = true;
            // 
            // txb_NLMK
            // 
            this.txb_NLMK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txb_NLMK.Location = new System.Drawing.Point(786, 374);
            this.txb_NLMK.Name = "txb_NLMK";
            this.txb_NLMK.Size = new System.Drawing.Size(184, 22);
            this.txb_NLMK.TabIndex = 8;
            this.txb_NLMK.UseSystemPasswordChar = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(786, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 53);
            this.button2.TabIndex = 9;
            this.button2.Text = "Cập Nhật Mật Khẩu";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(456, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "THÔNG TIN CÁ NHÂN NHÂN SỰ";
            // 
            // ThongTinCaNhan_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 594);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txb_NLMK);
            this.Controls.Add(this.txb_MKMoi);
            this.Controls.Add(this.txb_MKCu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_1);
            this.Controls.Add(this.button1);
            this.Name = "ThongTinCaNhan_BanHang";
            this.Text = "ThongTinCaNhan_BanHang";
            this.Load += new System.EventHandler(this.ThongTinCaNhan_BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txb_MKCu;
        private System.Windows.Forms.TextBox txb_MKMoi;
        private System.Windows.Forms.TextBox txb_NLMK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}