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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        DataHandler dh = new DataHandler();
        public delegate string Mydelegate(string average);
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dh.addStudent(dh.connect(), txtSurname.Text, txtName.Text, txtGrade.Text, Int32.Parse(txtMark.Text));
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            Mydelegate del = dh.getCert;
            foreach (DataRow dr in dh.getStudents().Rows)
            {
                ListViewItem item = new ListViewItem(dr["Surname"].ToString());
                item.SubItems.Add(dr["Name"].ToString());
                item.SubItems.Add(dr["Grade"].ToString());
                item.SubItems.Add(dr["Average"].ToString());
                item.SubItems.Add(del(dr["Average"].ToString()));

                listView1.Items.Add(item);
            }
        }

        private void btnCertificate_Click(object sender, EventArgs e)
        {
            Mydelegate del = dh.getCert;
            foreach (DataRow dr in dh.getStudents().Rows)
            {
                if (del(dr["Average"].ToString()) == "Certificate")
                {
                    ListViewItem item = new ListViewItem(dr["Surname"].ToString());
                    item.SubItems.Add(dr["Name"].ToString());
                    item.SubItems.Add(dr["Grade"].ToString());
                    item.SubItems.Add(dr["Average"].ToString());
                    item.SubItems.Add(del(dr["Average"].ToString()));

                    listView1.Items.Add(item);
                }
            }
        }

        private void btnCertMedal_Click(object sender, EventArgs e)
        {
            Mydelegate del = dh.getCert;
            foreach (DataRow dr in dh.getStudents().Rows)
            {
                if (del(dr["Average"].ToString()) == "Certificate and Medal")
                {
                    ListViewItem item = new ListViewItem(dr["Surname"].ToString());
                    item.SubItems.Add(dr["Name"].ToString());
                    item.SubItems.Add(dr["Grade"].ToString());
                    item.SubItems.Add(dr["Average"].ToString());
                    item.SubItems.Add(del(dr["Average"].ToString()));

                    listView1.Items.Add(item);
                }
            }
        }

        private void btnCertMedTrop_Click(object sender, EventArgs e)
        {
            Mydelegate del = dh.getCert;
            foreach (DataRow dr in dh.getStudents().Rows)
            {
                if (del(dr["Average"].ToString()) == "Certificate, Medal and Trophy")
                {
                    ListViewItem item = new ListViewItem(dr["Surname"].ToString());
                    item.SubItems.Add(dr["Name"].ToString());
                    item.SubItems.Add(dr["Grade"].ToString());
                    item.SubItems.Add(dr["Average"].ToString());
                    item.SubItems.Add(del(dr["Average"].ToString()));

                    listView1.Items.Add(item);
                }
            }
        }
    }
}
