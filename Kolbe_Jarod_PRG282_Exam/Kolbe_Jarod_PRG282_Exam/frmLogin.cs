using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kolbe_Jarod_PRG282_Exam
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        DataHandler dh = new DataHandler();
        FileHandler fh = new FileHandler();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (dh.credentialCheck(fh.getSchools(), txtUsername.Text, txtPassword.Text))
            {
                this.Hide();
                frmMain main = new frmMain();
                main.Show();
            }
        }
    }
}
