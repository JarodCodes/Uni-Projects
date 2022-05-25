using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kolbe_Jarod_PRG282_Exam
{
    class FileHandler
    {
        public FileHandler() { }

        public List<string> getSchools()
        {
            StreamReader reader = new StreamReader("Username.txt");
            string line;
            List<string> schools = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                schools.Add(line);
            }

            return schools;
        }

        public void registerSchool(string name, string username)
        {
            string final = name + '#' + username;
            using (StreamWriter sw = File.AppendText("Username.txt"))
            {
                sw.WriteLine(final);
            }
        }
    }
}
