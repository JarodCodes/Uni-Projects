using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Lecturer : Human, IComparable
    {
        private string campus;
        private string empID;
        private int endKM;
        private int startKM;
        private double subTotal;
        private string transMode;
        private double fare;

        public Lecturer() { }

        public Lecturer(string empID, string fullName, string campus, string transMode, double fare, int startKM, int endKM) : base(fullName)
        {
            this.Campus = campus;
            this.EmpID = empID;
            this.StartKM = startKM;
            this.EndKM = endKM;
            this.TransMode = transMode;
            this.Fare = fare;
            this.SubTotal = subTotal;
        }

        public string EmpID { get => empID; set => empID = value; }
        public string Campus { get => campus; set => campus = value; }
        public double Fare { get => fare; set => fare = value; }
        public int StartKM { get => startKM; set => startKM = value; }
        public int EndKM { get => endKM; set => endKM = value; }
        public string TransMode { get => transMode; set => transMode = value; }
        public double SubTotal { get => subTotal; set => subTotal = value; }

        public void Populate(string empID, string fullName, string campus, string tranport) 
        {
            if (empID == "" | fullName == "" | campus == "" | tranport == "")
            {
                throw (new CustomException("Something went wrong!"));
            }
            else 
            {
                this.EmpID = empID;
                this.Campus = campus;
                this.TransMode = tranport;
                for (int i = 0; i < fullName.Length; i++)
                {
                    char c = fullName[i];
                    if (!Char.IsLetter(c))
                    {
                        throw (new CustomException("Something went wrong!"));
                    }
                }
                this.FullName = fullName;
            }
        }
        public override void Fareprice(string fare)
        {
            try
            {
                if (this.TransMode == "Car" && double.Parse(fare) > 0)
                {
                    throw (new CustomException("Something went wrong!"));
                }
                else
                {
                    this.Fare = double.Parse(fare);
                }
            }
            catch (Exception)
            {
                throw (new CustomException("Something went wrong!"));
            }
        }

        public override void kmDifference(string start, string end)
        {
            try
            {
                if (this.TransMode != "Car" && (int.Parse(start) > 0 || int.Parse(end) > 0))
                {
                    throw (new CustomException("Something went wrong!"));
                }
                else
                {
                    this.StartKM = int.Parse(start);
                    this.EndKM = int.Parse(end);
                }
            }
            catch (Exception)
            {
                throw (new CustomException("Something went wrong!"));
            }
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
