
namespace Coffee_Management_Software.GUI
{
    partial class frmSale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbl_Time = new System.Windows.Forms.Label();
            this.tbl_date = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lv_Food = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.pan_Cate = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Table = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_TotalPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_TT = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_Bill = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flp_Table = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bill)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkOrange;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1648, 37);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(665, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quản lý bán hàng";
            // 
            // tbl_Time
            // 
            this.tbl_Time.AutoSize = true;
            this.tbl_Time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_Time.ForeColor = System.Drawing.Color.Black;
            this.tbl_Time.Location = new System.Drawing.Point(876, 92);
            this.tbl_Time.Name = "tbl_Time";
            this.tbl_Time.Size = new System.Drawing.Size(34, 19);
            this.tbl_Time.TabIndex = 9;
            this.tbl_Time.Text = "time";
            // 
            // tbl_date
            // 
            this.tbl_date.AutoSize = true;
            this.tbl_date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbl_date.ForeColor = System.Drawing.Color.Black;
            this.tbl_date.Location = new System.Drawing.Point(782, 92);
            this.tbl_date.Name = "tbl_date";
            this.tbl_date.Size = new System.Drawing.Size(34, 19);
            this.tbl_date.TabIndex = 8;
            this.tbl_date.Text = "time";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lv_Food
            // 
            this.lv_Food.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lv_Food.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lv_Food.HideSelection = false;
            this.lv_Food.Location = new System.Drawing.Point(185, 115);
            this.lv_Food.Name = "lv_Food";
            this.lv_Food.Size = new System.Drawing.Size(500, 667);
            this.lv_Food.TabIndex = 1;
            this.lv_Food.UseCompatibleStateImageBehavior = false;
            this.lv_Food.View = System.Windows.Forms.View.Tile;
            this.lv_Food.SelectedIndexChanged += new System.EventHandler(this.lv_Food_SelectedIndexChanged);
            this.lv_Food.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lv_Food_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(40, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 49);
            this.label2.TabIndex = 2;
            this.label2.Text = "Categories";
            // 
            // pan_Cate
            // 
            this.pan_Cate.AutoScroll = true;
            this.pan_Cate.Location = new System.Drawing.Point(40, 115);
            this.pan_Cate.Name = "pan_Cate";
            this.pan_Cate.Size = new System.Drawing.Size(139, 667);
            this.pan_Cate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(691, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bàn số:";
            // 
            // txt_Table
            // 
            this.txt_Table.Location = new System.Drawing.Point(781, 49);
            this.txt_Table.Name = "txt_Table";
            this.txt_Table.ReadOnly = true;
            this.txt_Table.Size = new System.Drawing.Size(119, 23);
            this.txt_Table.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(692, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thời gian:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(691, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tổng tiền:";
            // 
            // txt_TotalPrice
            // 
            this.txt_TotalPrice.Location = new System.Drawing.Point(781, 133);
            this.txt_TotalPrice.Name = "txt_TotalPrice";
            this.txt_TotalPrice.ReadOnly = true;
            this.txt_TotalPrice.Size = new System.Drawing.Size(138, 23);
            this.txt_TotalPrice.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(925, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "(VNĐ)";
            // 
            // btn_Pay
            // 
            this.btn_Pay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btn_Pay.Location = new System.Drawing.Point(993, 130);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(187, 30);
            this.btn_Pay.TabIndex = 12;
            this.btn_Pay.Text = "Thanh toán";
            this.btn_Pay.UseVisualStyleBackColor = true;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = global::Coffee_Management_Software.Properties.Resources.logout__1_;
            this.button2.Location = new System.Drawing.Point(1515, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 42);
            this.button2.TabIndex = 17;
            this.button2.Text = "Thoát";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_TT
            // 
            this.btn_TT.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.btn_TT.Location = new System.Drawing.Point(993, 88);
            this.btn_TT.Name = "btn_TT";
            this.btn_TT.Size = new System.Drawing.Size(187, 30);
            this.btn_TT.TabIndex = 19;
            this.btn_TT.Text = "Tạm tính";
            this.btn_TT.UseVisualStyleBackColor = true;
            this.btn_TT.Click += new System.EventHandler(this.btn_TT_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_Bill);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(692, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 604);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh mục order sản phẩm";
            // 
            // dgv_Bill
            // 
            this.dgv_Bill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Bill.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Bill.Location = new System.Drawing.Point(6, 34);
            this.dgv_Bill.Name = "dgv_Bill";
            this.dgv_Bill.RowHeadersWidth = 51;
            this.dgv_Bill.RowTemplate.Height = 25;
            this.dgv_Bill.Size = new System.Drawing.Size(476, 564);
            this.dgv_Bill.TabIndex = 15;
            this.dgv_Bill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Bill_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flp_Table);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(1193, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 653);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin bàn";
            // 
            // flp_Table
            // 
            this.flp_Table.AutoScroll = true;
            this.flp_Table.Location = new System.Drawing.Point(6, 31);
            this.flp_Table.Name = "flp_Table";
            this.flp_Table.Size = new System.Drawing.Size(410, 616);
            this.flp_Table.TabIndex = 19;
            // 
            // frmSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1648, 818);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_TT);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_TotalPrice);
            this.Controls.Add(this.tbl_Time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbl_date);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Table);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pan_Cate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lv_Food);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale";
            this.Load += new System.EventHandler(this.Sale_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bill)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbl_Time;
        private System.Windows.Forms.Label tbl_date;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListView lv_Food;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pan_Cate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Table;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TotalPrice;
        private System.Windows.Forms.Button btn_Pay;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_TT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flp_Table;
        private System.Windows.Forms.DataGridView dgv_Bill;
    }
}