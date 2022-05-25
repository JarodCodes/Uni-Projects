using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    delegate double CheckClaimFare();
    public class DataHandler
    {
        public List<Lecturer> Populate()
        {
            List<Lecturer> lecturers = new List<Lecturer>();
            lecturers.Add(new Lecturer("KP08", "Eddie Chetty", "Kempton", "Car", 0, 15040, 15349));
            lecturers.Add(new Lecturer("KP04", "Themba Mpofu", "Kempton", "Bus", 350, 0, 0));
            lecturers.Add(new Lecturer("PR17", "Anila Joy", "Pretoria", "Car", 0, 23457, 23457));
            lecturers.Add(new Lecturer("PR45", "Inna Ngubane", "Pretoria", "Bus", 370, 0, 0));
            lecturers.Add(new Lecturer("EC01", "Simba Zen", "Eastern Cape", "Flight", 1020, 0, 0));
            lecturers.Add(new Lecturer("EC89", "Nsuku Ckoko", "Eastern Cape", "Car", 0, 89700, 91100));
            return lecturers;
        }
        public List<Lecturer> CheckClaim(List<Lecturer> lecturers) 
        {
            foreach (Lecturer lecturer in lecturers)
            {
                SubTotalClaim(lecturer);
            }
            return lecturers;
        }
        public string SubTotalClaim(Lecturer lecturer) 
        {
            if (lecturer.TransMode == "Car")
            {
                lecturer.SubTotal = (lecturer.EndKM - lecturer.StartKM) * 6;
            }
            else
            {
                lecturer.SubTotal = lecturer.Fare * 2;
            }
            if (lecturer.SubTotal > 5000)
            {
                lecturer.SubTotal = 5000;
                return "Subtotal was above 5000";
            }
            else
            {
                return "Lecturer added successfully";
            }
        }
    }
}
