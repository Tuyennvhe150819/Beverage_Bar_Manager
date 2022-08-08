
namespace Coffee_Management_Software.GUI
{
    partial class frmBill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBill));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbl_star = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbn_Cancel = new System.Windows.Forms.Button();
            this.tbn_CreateBill = new System.Windows.Forms.Button();
            this.txt_Cash = new System.Windows.Forms.TextBox();
            this.txt_ExcessCash = new System.Windows.Forms.TextBox();
            this.txt_Guest = new System.Windows.Forms.TextBox();
            this.txt_Table = new System.Windows.Forms.TextBox();
            this.txt_Employee = new System.Windows.Forms.TextBox();
            this.tbl_Time = new System.Windows.Forms.Label();
            this.tbl_date = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 39);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(142, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "YÊU CẦU THANH TOÁN";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbl_star);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbn_Cancel);
            this.panel2.Controls.Add(this.tbn_CreateBill);
            this.panel2.Controls.Add(this.txt_Cash);
            this.panel2.Controls.Add(this.txt_ExcessCash);
            this.panel2.Controls.Add(this.txt_Guest);
            this.panel2.Controls.Add(this.txt_Table);
            this.panel2.Controls.Add(this.txt_Employee);
            this.panel2.Controls.Add(this.tbl_Time);
            this.panel2.Controls.Add(this.tbl_date);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 312);
            this.panel2.TabIndex = 1;
            // 
            // tbl_star
            // 
            this.tbl_star.AutoSize = true;
            this.tbl_star.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbl_star.ForeColor = System.Drawing.Color.Red;
            this.tbl_star.Location = new System.Drawing.Point(150, 131);
            this.tbl_star.Name = "tbl_star";
            this.tbl_star.Size = new System.Drawing.Size(17, 21);
            this.tbl_star.TabIndex = 40;
            this.tbl_star.Text = "*";
            this.tbl_star.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(371, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 19);
            this.label10.TabIndex = 39;
            this.label10.Text = "(vnđ)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(371, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 19);
            this.label9.TabIndex = 38;
            this.label9.Text = "(vnđ)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(371, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 19);
            this.label8.TabIndex = 37;
            this.label8.Text = "(vnđ)";
            // 
            // tbn_Cancel
            // 
            this.tbn_Cancel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbn_Cancel.Location = new System.Drawing.Point(288, 268);
            this.tbn_Cancel.Name = "tbn_Cancel";
            this.tbn_Cancel.Size = new System.Drawing.Size(77, 35);
            this.tbn_Cancel.TabIndex = 36;
            this.tbn_Cancel.Text = "Hủy";
            this.tbn_Cancel.UseVisualStyleBackColor = true;
            this.tbn_Cancel.Click += new System.EventHandler(this.tbn_Cancel_Click);
            // 
            // tbn_CreateBill
            // 
            this.tbn_CreateBill.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbn_CreateBill.Location = new System.Drawing.Point(157, 268);
            this.tbn_CreateBill.Name = "tbn_CreateBill";
            this.tbn_CreateBill.Size = new System.Drawing.Size(117, 35);
            this.tbn_CreateBill.TabIndex = 35;
            this.tbn_CreateBill.Text = "Xuất hóa đơn";
            this.tbn_CreateBill.UseVisualStyleBackColor = true;
            this.tbn_CreateBill.Click += new System.EventHandler(this.tbn_CreateBill_Click);
            // 
            // txt_Cash
            // 
            this.txt_Cash.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Cash.Location = new System.Drawing.Point(173, 217);
            this.txt_Cash.Name = "txt_Cash";
            this.txt_Cash.ReadOnly = true;
            this.txt_Cash.Size = new System.Drawing.Size(192, 26);
            this.txt_Cash.TabIndex = 34;
            this.txt_Cash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_ExcessCash
            // 
            this.txt_ExcessCash.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_ExcessCash.Location = new System.Drawing.Point(173, 172);
            this.txt_ExcessCash.Name = "txt_ExcessCash";
            this.txt_ExcessCash.ReadOnly = true;
            this.txt_ExcessCash.Size = new System.Drawing.Size(192, 26);
            this.txt_ExcessCash.TabIndex = 33;
            this.txt_ExcessCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Guest
            // 
            this.txt_Guest.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Guest.Location = new System.Drawing.Point(173, 128);
            this.txt_Guest.Name = "txt_Guest";
            this.txt_Guest.Size = new System.Drawing.Size(192, 26);
            this.txt_Guest.TabIndex = 32;
            this.txt_Guest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Guest.TextChanged += new System.EventHandler(this.txt_Guest_TextChanged);
            this.txt_Guest.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Guest_KeyPress);
            // 
            // txt_Table
            // 
            this.txt_Table.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Table.Location = new System.Drawing.Point(173, 85);
            this.txt_Table.Name = "txt_Table";
            this.txt_Table.ReadOnly = true;
            this.txt_Table.Size = new System.Drawing.Size(192, 26);
            this.txt_Table.TabIndex = 31;
            // 
            // txt_Employee
            // 
            this.txt_Employee.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Employee.Location = new System.Drawing.Point(173, 42);
            this.txt_Employee.Name = "txt_Employee";
            this.txt_Employee.ReadOnly = true;
            this.txt_Employee.Size = new System.Drawing.Size(192, 26);
            this.txt_Employee.TabIndex = 30;
            // 
            // tbl_Time
            // 
            this.tbl_Time.AutoSize = true;
            this.tbl_Time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_Time.ForeColor = System.Drawing.Color.Black;
            this.tbl_Time.Location = new System.Drawing.Point(240, 10);
            this.tbl_Time.Name = "tbl_Time";
            this.tbl_Time.Size = new System.Drawing.Size(34, 19);
            this.tbl_Time.TabIndex = 29;
            this.tbl_Time.Text = "time";
            // 
            // tbl_date
            // 
            this.tbl_date.AutoSize = true;
            this.tbl_date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_date.ForeColor = System.Drawing.Color.Black;
            this.tbl_date.Location = new System.Drawing.Point(173, 10);
            this.tbl_date.Name = "tbl_date";
            this.tbl_date.Size = new System.Drawing.Size(34, 19);
            this.tbl_date.TabIndex = 28;
            this.tbl_date.Text = "time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(90, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 27;
            this.label7.Text = "Phải trả:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(112, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "Bàn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(29, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Số tiền của khách:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(81, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tiền thừa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(75, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(81, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ngày lập:";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 370);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill";
            this.Load += new System.EventHandler(this.Bill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button tbn_Cancel;
        private System.Windows.Forms.Button tbn_CreateBill;
        private System.Windows.Forms.TextBox txt_Cash;
        private System.Windows.Forms.TextBox txt_ExcessCash;
        private System.Windows.Forms.TextBox txt_Guest;
        private System.Windows.Forms.TextBox txt_Table;
        private System.Windows.Forms.TextBox txt_Employee;
        private System.Windows.Forms.Label tbl_Time;
        private System.Windows.Forms.Label tbl_date;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label tbl_star;
    }
}