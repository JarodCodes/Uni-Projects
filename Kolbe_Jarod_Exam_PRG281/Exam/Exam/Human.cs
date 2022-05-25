using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public abstract class Human : IComparable
    {
        private string fullName;

        public Human() { }
        public Human(string fullName)
        {
            this.FullName = fullName;
        }

        public string FullName { get => fullName; set => fullName = value; }

        public int CompareTo(object obj) 
        {
            Human human = obj as Human;
            return this.FullName.CompareTo(human.FullName);
        }
        public abstract void Fareprice(string fare);
        public abstract void kmDifference(string start, string end);
        public abstract string ToString();
    }
}
