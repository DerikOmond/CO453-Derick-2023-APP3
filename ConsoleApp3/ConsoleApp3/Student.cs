﻿using System;
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
        private char? grade;

        public static int option;

         public Student(String firstName, String lastName, int mark, char? grade)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mark = mark;
            this.grade = grade;
        }

        public static void Intro()
        {
            DisplayHeader();
            do
            {
                DisplayMenu();
                SelectRoute(option, Program.studentList);
            }
            while (true);
            
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
                DisplayStudent(list);
            }
            else if (option == 4)
            {
                OutputStats(list);
            }
            else if (option == 5)
            {
                DisplayGradeProfile(list, 'A');
                DisplayGradeProfile(list, 'B');
                DisplayGradeProfile(list, 'C');
                DisplayGradeProfile(list, 'D');
                DisplayGradeProfile(list, 'E');
                DisplayGradeProfile(list, 'F');
            }
            else if(option == 6)
            {
                Console.WriteLine("Goodbye...");
                Console.ReadLine();
                Environment.Exit(0);
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
1. Update Marks
2. Add Student
3. Output Marks
4. Output Stats
5. Output Grade Profile
6. Exit

Enter the number corrsoponding the the options shown.");
            Console.Write("\n> ");
            option = Int16.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        public static void DisplayStudent(List<Student> list)
        {
            Console.WriteLine();
            Console.WriteLine("{0, -5} {1, -14} {2, -14} {3, -7} {4,-4}", "Index", 
                "First Name", "Last Name", "Marks", "Grade");
            foreach (var student in list) 
            {
                Console.WriteLine("{0, -5} {1, -14} {2, -14} {3, -7} {4, -4}", list.IndexOf(student) + 1,
                    student.firstName, student.lastName, student.mark, student.grade);
            }
            Console.WriteLine();
        }

        public static void UpdateMark(List<Student> list)
        {
            Console.Write("Select the index of the student you would " +
                "like to change the mark of.\n> ");
            int studentIndex = int.Parse(Console.ReadLine()) - 1;

            if (studentIndex < 0 || studentIndex >= list.Count)
            {
                Console.WriteLine("That is an invalid value for the student index.");
                return;
            }

            Student selectedStudent = list[studentIndex];

            Console.WriteLine($"\nYou have chosen {selectedStudent.firstName}" +
                $" {selectedStudent.lastName} who currently has {selectedStudent.mark}.");

            Console.Write("\nEnter the new mark for the student.\n> ");
            selectedStudent.mark = int.Parse(Console.ReadLine());

            selectedStudent.grade = SetGrade(selectedStudent.mark);

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

        private static void OutputStats(List<Student> list)
        {
            Console.WriteLine($"Mean mark: {CalculateMean(list)}\n" +
                $"Lowest Mark: {FindMinimum(list)}\n" +
                $"Highest Mark: {FindMaximum(list)}\n");
        }

        private static double CalculateMean(List<Student> list)
        {
            int total = 0;

            foreach (var student in list)
            {
                total += student.mark;
            }

            double mean = total / list.Count;

            return mean;
        }

        private static int FindMinimum(List<Student> list)
        {
            int lowestMark = 101;

            foreach (var student in list) 
            {
                if (student.mark < lowestMark)
                {
                    lowestMark = student.mark;
                }
            }

            return lowestMark;
        }

        private static int FindMaximum(List<Student> list)
        {
            int highestMark = -1;

            foreach(var student in list)
            {
                if (student.mark > highestMark)
                {
                    highestMark = student.mark;
                }
            }

            return highestMark;
        }

        private static void DisplayGradeProfile(List<Student> list, char gradeValue)
        {
            Console.WriteLine($"{FindProfile(list, gradeValue)}% of students achieved a grade {gradeValue}.");
        }

        private static double FindProfile(List<Student> list, char gradeValue)
        {
            int count = 0;

            foreach(var student in list)
            {
                if(student.grade == gradeValue)
                {
                    count++;
                }
            }
            
            double percentage = ((double)count / list.Count) * 100;
            return percentage;
        }
    }
}