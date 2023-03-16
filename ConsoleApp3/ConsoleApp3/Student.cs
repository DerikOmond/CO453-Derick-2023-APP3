using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int mark;
        private char grade;

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
            Console.WriteLine(@"
MENU:
1. Input Marks
2. Output Marks
3. Output Stats
4. Output Grade Profile
5. Exit");
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
            Console.WriteLine("Select a");
        }
    }
}