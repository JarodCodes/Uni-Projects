using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kolbe_Jarod_PRG282_Exam
{
    class DataHandler
    {
        
        public DataHandler() { }

        string con = "Server=(local); Initial Catalog=Education; Integrated Security= SSPI";

        public SqlConnection connect()
        {
            SqlConnection cn = new SqlConnection(con);

            try
            {
                cn.Open();
                MessageBox.Show("Connection successful");
            }
            catch (Exception)
            {

                MessageBox.Show("Connection error");
            }
            return cn;
        }
        public string schoolRegister(SqlConnection cn, string name, string location) 
        {
            string username = name.Substring(0, 3) + location.Substring(0, 2);
            username = username.ToUpper();
            string query = string.Format("INSERT INTO School VALUES({0}, {1}, {2}", name, location, (DateTime.Now).ToString());

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();

            cn.Close();
            return (username);
        }

        public bool credentialCheck(List<string> schools, string username, string password) 
        {
            foreach (string school in schools)
            {
                string[] schoolPart = school.Split('#');
                if (schoolPart[1] == username && password == "123")
                {
                    MessageBox.Show("Login succesful");
                    return true;
                }
            }
            MessageBox.Show("Login Failed");
            return false;
        }

        public DataTable getStudents()
        {
            string query = @"SELECT * FROM Student";

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }
        public void addStudent(SqlConnection cn, string surname, string name, string grade, int average)
        {
            string query = string.Format("INSERT INTO Student VALUES({0}, {1}, {2}, {3})", surname, name, grade, average);

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public string getCert(string average)
        {
            int number = Int32.Parse(average);
            if (number > 60 && number < 79)
            {
                return "Certificate";
            }
            else if (number > 80 && number < 89)
            {
                return "Certificate and Medal";
            }
            else if (number > 90 && number < 100)
            {
                return "Certificate, Medal and Trophy";
            }
            else 
            {
                return "None";
            }
        }

    }
}
