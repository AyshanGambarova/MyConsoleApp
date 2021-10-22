using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    class Student
    {
        public string  Name { get; set; }
        public string Surname { get; set; }
    
        public readonly int id;

        public static int count;

        public List<int> Marks;
        

        public Student()
        {
            count++;
            id = count;
            Marks = new List<int>();
        }
        public Student(string Name,string Surname):this()
        {
            this.Name = Name;
            this.Surname = Surname;
            
        }

        public override string ToString()
        {
            return $" Student {id} Name: {Name} - Surname: {Surname} - GroupId: {Group.count} ";
        }
        public override bool Equals(object obj)
        {
            return id == ((Student)obj).id;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} Surname: {Surname} Average:{AverageOfMarks()}");

        }

        public double AverageOfMarks()
        {
            int average = 0;
            foreach (int item in Marks)
            {
                average += item / Marks.Count ;
            }
            return average;
        }
       
        public bool AddStudentMark(int mark)
        {
            if (!(mark>0&&mark<=100))
            {
                return false;
            }
            Marks.Add(mark);
            return true;
        }
    }
}
