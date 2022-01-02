
namespace Employee
{
    partial class Home_BanHang
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
            this.label_XinChao = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_chinhanh = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_XinChao
            // 
            this.label_XinChao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_XinChao.AutoSize = true;
            this.label_XinChao.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_XinChao.ForeColor = System.Drawing.Color.Red;
            this.label_XinChao.Location = new System.Drawing.Point(23, 19);
            this.label_XinChao.Name = "label_XinChao";
            this.label_XinChao.Size = new System.Drawing.Size(115, 29);
            this.label_XinChao.TabIndex = 0;
            this.label_XinChao.Text = "Xin chào";
            this.label_XinChao.Click += new System.EventHandler(this.label_XinChao_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(347, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên bán hàng";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(339, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 66);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hóa Đơn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(612, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 66);
            this.button2.TabIndex = 3;
            this.button2.Text = "Xem Thông Tin Khách Hàng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_chinhanh
            // 
            this.label_chinhanh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_chinhanh.AutoSize = true;
            this.label_chinhanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chinhanh.ForeColor = System.Drawing.Color.Red;
            this.label_chinhanh.Location = new System.Drawing.Point(702, 19);
            this.label_chinhanh.Name = "label_chinhanh";
            this.label_chinhanh.Size = new System.Drawing.Size(141, 29);
            this.label_chinhanh.TabIndex = 4;
            this.label_chinhanh.Text = "Chi Nhánh ";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(481, 484);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 66);
            this.button3.TabIndex = 5;
            this.button3.Text = "Thoát";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Location = new System.Drawing.Point(339, 359);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 66);
            this.button4.TabIndex = 6;
            this.button4.Text = "Xem Thông Tin Cá Nhân";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Location = new System.Drawing.Point(612, 359);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 66);
            this.button5.TabIndex = 7;
            this.button5.Text = "Điểm Danh";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Home_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 599);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label_chinhanh);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_XinChao);
            this.Name = "Home_BanHang";
            this.Text = "Home_ThanhToan";
            this.Load += new System.EventHandler(this.Home_BanHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_XinChao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_chinhanh;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}