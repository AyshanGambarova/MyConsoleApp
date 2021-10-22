using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp
{
    class Group
    {
        public int Number { get; set; }

        public List<Student> Students;
        
        public readonly int id;

        public static int count;
        public int MaxStudentCount { get; set; }


        public Group()
        {
            count++;
            id = count;
            Students = new List<Student>();
        }
        public Group(int Number,int MaxStudentCount):this()
        {
            this.Number = Number;
            this.MaxStudentCount = MaxStudentCount;
        }

        public override string ToString()
        {
            return $" Group: {id} - Number: {Number} - Max. student count: {MaxStudentCount} ";
        }

        public override bool Equals(object obj)
        {
            return Number == ((Group)obj).Number;
        }

        public bool AddStudent(Student student)
        {
            if (!(MaxStudentCount > Students.Count))
            {
                return false;
            }
            if (Students.Contains(student))
            {
                return false;
            }

            Students.Add(student);
            return true;

        }


        public void PrintAllStudent()
        {
            foreach (Student item in Students)
            {
                Console.WriteLine(item);
            }
        }

        public void FindStudent(string infoName, string infoSurname)
        {
            bool QueryFound = false;

            foreach (Student item in Students)
            {

                if (item.Name.Contains(infoName) && item.Surname.Contains(infoSurname))
                {
                    Console.WriteLine(item);
                    QueryFound = true;
                }
              
            }
            if (!QueryFound)
            {
                Console.WriteLine("Query not found");
            }
        }
        public bool RemoveStudent(int id)
        {
            int count = Students.Count;
            for (int i = 0; i < count; i++)
            {
                if (Students[i].id==id)
                {
                    Students.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
       
        
        
        
    }
}
