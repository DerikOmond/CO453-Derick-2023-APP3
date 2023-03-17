using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int mark;
        private char grade;

        public static int option;

         public Student(String firstName, String lastName, int mark, char grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mark = mark;
            this.grade = grade;
        }

        public static void Intro()
        {

            DisplayHeader();
            DisplayMenu();

            Console.ReadLine();
        }

        public static void SelectRoute(int option, List<Student> list)
        {
            if (option == 1)
            {
                DisplayStudent(list);
                UpdateMark(list);
            }
            else if (option == 2) 
            {
                AddStudent(list);
                DisplayStudent(list);

            }
            else if (option == 3)
            {
                //OutputMarks();
            }
            else if (option == 4)
            {
                //OutputStats();
            }
            else if (option == 5)
            {
                //OutputGradeProfile();
            }
        }

        private static void DisplayHeader()
        {
            Console.WriteLine($@"
==========================================================================================
========                           App03 Student Marks                            =======
========                             By Derick Omondi                             =======
==========================================================================================

Press enter to begin...");

            Console.ReadLine();
        }

        private static void DisplayMenu()
        {
            Console.Write(@"
MENU:
1. Input Marks
2. Add Student
3. Output Marks
4. Output Stats
5. Output Grade Profile
5. Exit
Enter the number corrsoponding the the options shown > ");
            option = Int16.Parse(Console.ReadLine());
            Console.WriteLine(option);
        }

        public static void DisplayStudent(List<Student> list)
        {
            foreach (var student in list) 
            {
                int index = list.IndexOf(student);

                Console.WriteLine($"Index: {index  + 1}\n" +
                    $"First Name: {student.firstName}\n" +
                    $"Last Name: {student.lastName}\n" +
                    $"Mark: {student.mark}\n" +
                    $"Grade: {student.grade}\n");
            }
            Console.ReadLine();
        }

        public static void UpdateMark(List<Student> list)
        {
            Console.Write("Select the index of the student you would" +
                "like to change the mark of.\n> ");
            int studentIndex = int.Parse(Console.ReadLine()) - 1;

            if (studentIndex < 0 || studentIndex >= list.Count)
            {
                Console.WriteLine("That is an invalid value for the student index.");
                return;
            }

            Student selectedStudent = list[studentIndex];

            Console.WriteLine($"You have chosen {selectedStudent.firstName}" +
                $" {selectedStudent.lastName} who currently has {selectedStudent.mark}.");

            Console.WriteLine("Enter the new mark for the student.\n> ");
            selectedStudent.mark = int.Parse(Console.ReadLine());

            DisplayStudent(list);
        }

        public static void AddStudent(List<Student> list)
        {
            Console.Write("First name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("Last name: ");
            string newLastName = Console.ReadLine();

            Console.Write("Mark: ");
            int mark = Int16.Parse(Console.ReadLine());

            list.Add(new Student(newFirstName, newLastName, SetMark(mark), SetGrade(SetMark(mark))));
        }

        public static int SetMark(int studentMark)
        {
            if (studentMark < 0 || studentMark > 100)
            {
                Console.WriteLine("That isn't a valid value!!!");
                return 0;
            }
            else
            {
                return studentMark;
            }
        }

        public static char SetGrade(int getMarkMethod)
        {
            bool repeat = false;

            do
            {
                if (getMarkMethod >= 0 && getMarkMethod <= 39)
                {
                    return 'F';
                }
                else if (getMarkMethod >= 40 && getMarkMethod <= 49)
                {
                    return 'D';
                }
                else if (getMarkMethod >= 50 && getMarkMethod <= 59)
                {
                    return 'C';
                }
                else if (getMarkMethod >= 60 && getMarkMethod <= 69)
                {
                    return 'B';
                }
                else if (getMarkMethod >= 70)
                {
                    return 'A';
                }
                else
                {
                    return 'U';
                }
            }
            while (repeat);

        }
    }
}