using System;
using System.Collections.Generic;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> Groups = new List<Group>();
            List<Student> Students = new List<Student>();
            List<int> Marks = new List<int>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Menu: 1 - Add group | 2 - Add student | 3 - Add student mark | 4 - View student list | 5 - Find student | 6 - Delete group | 7 - View group list | Exit");
                Console.ResetColor();

                string query = Console.ReadLine();
                if (query.ToLower() == "exit")
                {
                    break;
                }

                int selection;
                bool SelectionIsValid = int.TryParse(query, out selection);
                if (SelectionIsValid&&selection>=1&&selection<=7)
                {
                    switch (selection)
                    {
                        case (int)MenuBaR.AddGroup:
                            Console.Write("Enter the group number:");
                            int number;
                            bool NumberIsValid = int.TryParse(Console.ReadLine(), out number);
                            if (!NumberIsValid)
                            {
                                Console.WriteLine("Group number is invalid");
                                break;
                            }

                            Console.Write("Enter the max. student count:");
                            int count;
                            bool CountIsValid = int.TryParse(Console.ReadLine(), out count);
                            if (!CountIsValid)
                            {
                                Console.WriteLine("Student count is invalid");
                                break;
                            }
                            
                            Group group = new Group(number,count);

                            if (Groups.Contains(group))
                            {
                                Console.WriteLine("Group already exist.");
                                break;
                            }

                            Groups.Add(group);
                            break;

                        case (int)MenuBaR.AddStudent:
                            if (Groups.Count<=0)
                            {
                                Console.WriteLine("Firstly add a group");
                                break;
                            }

                            Console.WriteLine("Enter student name:");
                            string name = Console.ReadLine();
                            Console.WriteLine(name.ToLower()); 
                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Student name is invalid.");
                                break;
                            }

                            Console.WriteLine("Enter student surname:");
                            string surname = Console.ReadLine();
                            if (string.IsNullOrEmpty(surname))
                            {
                                Console.WriteLine("Surname is invalid.");
                                break;
                            }

                            Console.WriteLine("Enter the ID of group which you want to add this student:");
                            int groupid;
                            bool GroupIdIsValid = int.TryParse(Console.ReadLine(), out groupid);
                            if (!GroupIdIsValid)
                            {
                                Console.WriteLine("ID is invalid.");
                            }

                            Group GroupYouWantToAddStudent = null;
                            foreach (Group item in Groups)
                            {
                                if (item.id==groupid)
                                {
                                    GroupYouWantToAddStudent = item;
                                }
                            }
                            if (GroupYouWantToAddStudent==null)
                            {
                                Console.WriteLine("Group doesn't found.");
                                break;
                            }

                            Student student = new Student(name,surname);
                            if (!GroupYouWantToAddStudent.AddStudent(student))
                            {
                                Console.WriteLine("Student doesn't added.");
                                break;
                            }

                            Console.WriteLine("Student added.");

                            break;
                        case (int)MenuBaR.AddStudentMark:
                            Console.WriteLine("Enter the mark:");
                            int mark;
                            bool MarkIsValid = int.TryParse(Console.ReadLine(), out mark);
                            if (!MarkIsValid)
                            {
                                Console.WriteLine("Mark is invalid.");
                                break;
                            }
                            Console.WriteLine("Enter the student ID which you want to add this mark:");
                            int studentid;
                            bool StudentIdIsValid = int.TryParse(Console.ReadLine(), out studentid);
                            if (!StudentIdIsValid)
                            {
                                Console.WriteLine("Student ID is invalid.");
                                break;
                            }

                            Student StudentYouAddMark = null;

                            foreach (Group item in Groups)
                            {
                                //Console.WriteLine(item.Students);
                                foreach (Student itemStudent in item.Students)
                                {
                                    //Console.WriteLine(itemStudent);
                                    if (itemStudent.id == studentid)
                                    {
                                        StudentYouAddMark = itemStudent;
                                    }
                                }
                            }
                            if (StudentYouAddMark==null)
                            {
                                Console.WriteLine("Student doesn't exists.");
                                break;
                            }

                            if (!(StudentYouAddMark.AddStudentMark(mark)))
                            {
                                Console.WriteLine("Mark doesn't added.");
                                break;
                            }
                            Console.WriteLine("Mark added");

                            break;
                        case (int)MenuBaR.ViewStudentList:
                            foreach (Group item in Groups)
                            {
                                item.PrintAllStudent();
                            }
                            break;
                        case (int)MenuBaR.FindStudent:
                            Console.WriteLine("Enter name:");
                            string infoName = Console.ReadLine();
                            Console.WriteLine("Enter Surname:");
                            string infoSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(infoName) && string.IsNullOrEmpty(infoSurname))
                            {
                                Console.WriteLine("Info is invalid.");
                                break;
                            }
                            foreach (Group item in Groups)
                            {
                                item.FindStudent(infoName,infoSurname);
                            }
                            break;
                        case (int)MenuBaR.DeleteGroup:
                            Console.WriteLine("Enter ID of group you want to delete:");
                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group ID is invalid.");
                                break;
                            }
                            Group GroupYouWantToDelete = null;
                            foreach (Group item in Groups)
                            {
                                if (item.id==deleteGroupId)
                                {
                                    GroupYouWantToDelete = item;
                                }
                            }
                            if (GroupYouWantToDelete==null)
                            {
                                Console.WriteLine("Group doesn't exists.");
                                break;
                            }
                            Groups.Remove(GroupYouWantToDelete);
                            Console.WriteLine("Group deleted.");

                            break;

                        case (int)MenuBaR.ViewGroupList:
                            
                            foreach (Group item in Groups)
                            {
                                Console.WriteLine($"Group id: {item.id} - Number: {item.Number}");
                            }
                            break;


                    }
                }

            }
            
            
        }
    }
}
