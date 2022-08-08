
namespace Coffee_Management_Software.GUI
{
    partial class Directional
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Directional));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Profile = new System.Windows.Forms.Label();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbl_Time = new System.Windows.Forms.Label();
            this.tbl_date = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Shift = new System.Windows.Forms.Button();
            this.btn_Sale = new System.Windows.Forms.Button();
            this.btn_System = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_Profile);
            this.panel1.Controls.Add(this.btn_Logout);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbl_Time);
            this.panel1.Controls.Add(this.tbl_date);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Shift);
            this.panel1.Controls.Add(this.btn_Sale);
            this.panel1.Controls.Add(this.btn_System);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 340);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_Profile
            // 
            this.txt_Profile.AutoSize = true;
            this.txt_Profile.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Profile.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.txt_Profile.Location = new System.Drawing.Point(525, 231);
            this.txt_Profile.Name = "txt_Profile";
            this.txt_Profile.Size = new System.Drawing.Size(141, 24);
            this.txt_Profile.TabIndex = 11;
            this.txt_Profile.Text = "Thông tin cá nhân";
            this.txt_Profile.Click += new System.EventHandler(this.txt_Profile_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Logout.Image = global::Coffee_Management_Software.Properties.Resources.logout__1_;
            this.btn_Logout.Location = new System.Drawing.Point(525, 273);
            this.btn_Logout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(129, 44);
            this.btn_Logout.TabIndex = 10;
            this.btn_Logout.Text = "ĐĂNG XUẤT";
            this.btn_Logout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(47, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(688, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "CHÀO MỪNG BẠN ĐẾN VỚI PHẦN MÊM QUẢN LÝ CỬA HÀNG";
            // 
            // tbl_Time
            // 
            this.tbl_Time.AutoSize = true;
            this.tbl_Time.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_Time.Location = new System.Drawing.Point(130, 273);
            this.tbl_Time.Name = "tbl_Time";
            this.tbl_Time.Size = new System.Drawing.Size(37, 22);
            this.tbl_Time.TabIndex = 8;
            this.tbl_Time.Text = "time";
            // 
            // tbl_date
            // 
            this.tbl_date.AutoSize = true;
            this.tbl_date.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_date.Location = new System.Drawing.Point(130, 237);
            this.tbl_date.Name = "tbl_date";
            this.tbl_date.Size = new System.Drawing.Size(37, 22);
            this.tbl_date.TabIndex = 7;
            this.tbl_date.Text = "date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(47, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "THỜI GIAN:";
            // 
            // btn_Shift
            // 
            this.btn_Shift.Enabled = false;
            this.btn_Shift.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Shift.Location = new System.Drawing.Point(464, 92);
            this.btn_Shift.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Shift.Name = "btn_Shift";
            this.btn_Shift.Size = new System.Drawing.Size(190, 121);
            this.btn_Shift.TabIndex = 5;
            this.btn_Shift.Text = "ĐIỂM DANH";
            this.btn_Shift.UseVisualStyleBackColor = true;
            this.btn_Shift.Click += new System.EventHandler(this.btn_Shift_Click);
            // 
            // btn_Sale
            // 
            this.btn_Sale.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Sale.Location = new System.Drawing.Point(254, 92);
            this.btn_Sale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Sale.Name = "btn_Sale";
            this.btn_Sale.Size = new System.Drawing.Size(190, 121);
            this.btn_Sale.TabIndex = 4;
            this.btn_Sale.Text = "QUẢN LÝ BÁN HÀNG";
            this.btn_Sale.UseVisualStyleBackColor = true;
            this.btn_Sale.Click += new System.EventHandler(this.btn_Sale_Click);
            // 
            // btn_System
            // 
            this.btn_System.Enabled = false;
            this.btn_System.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_System.Location = new System.Drawing.Point(47, 92);
            this.btn_System.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_System.Name = "btn_System";
            this.btn_System.Size = new System.Drawing.Size(190, 121);
            this.btn_System.TabIndex = 3;
            this.btn_System.Text = "QUẢN LÝ HỆ THỐNG";
            this.btn_System.UseVisualStyleBackColor = true;
            this.btn_System.Click += new System.EventHandler(this.btn_System_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Directional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 343);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Directional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Directional";
            this.Load += new System.EventHandler(this.Direction_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txt_Profile;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tbl_Time;
        private System.Windows.Forms.Label tbl_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Shift;
        private System.Windows.Forms.Button btn_Sale;
        private System.Windows.Forms.Button btn_System;
        private System.Windows.Forms.Timer timer1;
    }
}