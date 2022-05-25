using System;
using System.Collections.Generic;
using System.Text;

namespace Practical
{
    public delegate double Tracker(double val);
    class Citizen : IComparable
    {
        public event Tracker TrackGrant;
        private string name;
        private string surname;
        private int age;
        private bool kids;
        private string status;
        private double amount;
        private const int grant = 350;

        public Citizen(string name, string surname, int age, bool kids)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.kids = kids;
        }

        public Citizen() { }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public bool Kids { get => kids; set => kids = value; }
        public string Status { get => status; set => status = value; }
        public double Amount 
        { 
            get => amount;
            set 
            {
                amount = value;
                if (TrackGrant(value) > 3500)
                {
                    Console.WriteLine("Reached the limit");
                };
            }
        }

        public void generateCitizen()
        {
            if (Age >= 0 && Age <= 17)
            {
                Status = "Minor";
            }
            else if (Age >= 18 && Age <= 59)
            {
                Status = "Unemployed";
                if (Kids == true)
                {
                    Amount = Math.Round(grant*1.60);
                }
                else
                {
                    Amount = grant;
                }
            }
            else 
            {
                Status = "Senior Citizen";
                Amount = Math.Round(grant * 1.4);
            }
        }
        public override string ToString()
        {
            return string.Format("{0}\t {1}\t {2}\t {3}\t {4}\t {5}", Name, Surname, Age, Kids, Status, Amount); 
        }
        public int CompareTo(object obj)
        {
            Citizen otherCitizen = obj as Citizen;
            if (Name.CompareTo(otherCitizen.Name) == 0)
            {
                return Amount.CompareTo(otherCitizen.Amount);
            }
            else
            {
                return Name.CompareTo(otherCitizen.Name);
            }
        }
    }
}
