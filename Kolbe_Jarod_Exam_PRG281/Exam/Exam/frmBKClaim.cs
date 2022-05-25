using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class frmBKClaim : Form
    {
        public frmBKClaim()
        {
            InitializeComponent();
        }
        BindingSource source = new BindingSource();
        List<Lecturer> lecturers = new List<Lecturer>();
        private void frmBKClaim_Load(object sender, EventArgs e)
        {
            DataHandler datahand = new DataHandler();
            lecturers = datahand.Populate();
            lecturers = datahand.CheckClaim(lecturers);
            lecturers.Sort();
            source.DataSource = lecturers;
            dgbLecturers.DataSource = source;
            dgbLecturers.Columns[2].DefaultCellStyle.Format = "c";
            dgbLecturers.Columns[6].DefaultCellStyle.Format = "c";
            cmbCampus.SelectedIndex = 0;
            cmbTransport.SelectedIndex = 0;
            dgbLecturers.Columns["FullName"].DisplayIndex = 1;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string empID = txtSearch.Text;
            bool found = false;
            List<Lecturer> searched = new List<Lecturer>();

            foreach (Lecturer lecturer in lecturers)
            {
                if (lecturer.EmpID == empID)
                {
                    searched.Add(lecturer);
                    found = true;
                }
            }
            if (found)
            {
                source.DataSource = searched;
            }
            else 
            {
                MessageBox.Show("Lecturer not found");
            }
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            try
            {
                DataHandler datah = new DataHandler();
                Lecturer lecturer = new Lecturer();
                lecturer.Populate(txtEmpID.Text, txtFullName.Text, cmbCampus.Text, cmbTransport.Text);
                lecturer.Fareprice(txtFare.Text);
                lecturer.kmDifference(txtStartkm.Text, txtEndkm.Text);
                MessageBox.Show(datah.SubTotalClaim(lecturer));
                lecturers.Add(lecturer);
                source.DataSource = null;
                source.DataSource = lecturers;
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            source.MovePrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            source.MoveNext();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
