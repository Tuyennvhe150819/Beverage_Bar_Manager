using Coffee_Management_Software.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Management_Software
{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            progressBar1.Value = startPoint;
            if(progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                timer1.Stop();
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {

        }
    }
}
