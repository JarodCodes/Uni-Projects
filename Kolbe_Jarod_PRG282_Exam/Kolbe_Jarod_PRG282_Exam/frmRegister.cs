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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        DataHandler dh = new DataHandler();
        FileHandler fh = new FileHandler();
        private void btnRegister_Click(object sender, EventArgs e)
        {
            fh.registerSchool(txtSName.Text, dh.schoolRegister(dh.connect(), txtSName.Text, txtSLocation.Text));
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }
    }
}
