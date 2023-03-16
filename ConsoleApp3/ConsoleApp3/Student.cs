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
            Console.WriteLine("\n==========================================================================================");
            Console.WriteLine("========                           App03 Student Marks                            ========");
            Console.WriteLine("========                             By Derick Omondi                             ========");
            Console.WriteLine("==========================================================================================\n");
            Console.Write("Press enter to begin > ");
            Console.ReadLine();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Input Marks");
            Console.WriteLine("2. Output Marks");
            Console.WriteLine("3. Output Stats");
            Console.WriteLine("4. Output Grade Profile");
            Console.WriteLine("5. Exit");
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

        public static void InputMark(List<Student> list)
        {
            Console.WriteLine("Select a ");
        }
    }
}