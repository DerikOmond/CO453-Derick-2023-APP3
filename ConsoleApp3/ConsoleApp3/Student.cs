/// <summary>
/// This console application converts a student object's mark into a grade.
/// It displays it into a readable table where it updates with the user made changes.
/// </summary>
/// <author>
/// Derick Omondi version 1.0
/// </author>

//dependancies
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
    //Student class
    public class Student
    {
        //Student object attributes
        private string firstName;
        private string lastName;
        private int mark;
        private char? grade;
        private string? gradeClass;

        //User assigned option for route to take
        private static int option;

        //Student constructor
        public Student(String firstName, String lastName, int mark, char? grade, string? gradeClass)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.mark = mark;
            this.grade = grade;
            this.gradeClass = gradeClass;
        }

        //Method used to run program on a list of Student class objects.
        public static void Run(List<Student> list)
        {
            DisplayHeader();
            do
            {
                DisplayMenu();
                SelectRoute(option, list);
            }
            while (true);
            
        }

        //Depending on the option the user chooses, different paths of methods will be followed.
        private static void SelectRoute(int option, List<Student> list)
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

        //Simply displays the title and author and a short explination of what the program does.
        private static void DisplayHeader()
        {
            Console.WriteLine($@"
==========================================================================================
========                            App03 Student Marks                            =======
========                              By Derick Omondi                             =======
==========================================================================================

This application lists students and their grades. More students can be added and the basic
can be viewed. If changes are made to the marks of already existing students are changed,
or more students are added, the stats will be updated alongside in order to accuratley
represent the data.

Press enter to begin...");

            Console.ReadLine();
        }

        //Shows the options available for the user's choice.
        //The variable 'option' is updated when the user makes a decision.
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

        //After printing the headers, a for each loop goes through all the student
        //and prints each attribute into the table
        public static void DisplayStudent(List<Student> list)
        {
            Console.WriteLine();
            Console.WriteLine("{0, -5} {1, -14} {2, -14} {3, -7} {4,-7} {5, -10}", "Index",
                "First Name", "Last Name", "Marks", "Grade", "Classification");
            foreach (var student in list)
            {
                Console.WriteLine("{0, -5} {1, -14} {2, -14} {3, -7} {4, -7} {5, -10}", list.IndexOf(student) + 1,
                    student.firstName, student.lastName, student.mark, student.grade, student.gradeClass);
            }
            Console.WriteLine();
        }

        //The user is prompted to select an index from the displayed table and input a
        //new value for that student.
        private static void UpdateMark(List<Student> list)
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
            selectedStudent.gradeClass = SetClass(selectedStudent.mark);

            DisplayStudent(list);
        }

        //User inputs the basic details (name and marks) to be added to the Student list.
        public static void AddStudent(List<Student> list)
        {
            Console.Write("First name: ");
            string newFirstName = Console.ReadLine();

            Console.Write("Last name: ");
            string newLastName = Console.ReadLine();

            Console.Write("Mark: ");
            int mark = Int16.Parse(Console.ReadLine());

            list.Add(new Student(newFirstName, newLastName, SetMark(mark), SetGrade(SetMark(mark)), SetClass(mark)));
        }

        //Returns a value if it fits in the range available for the marks.
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

        //Depending on the value of the argument, a grade will be slected.
        //When changing the mark of a student, the new grade will need to 
        //be selected.
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

        //Method takes in a mark and assigns a classification for it.
        public static string SetClass(int getMarkMethod)
        {
            if (getMarkMethod >= 0 && getMarkMethod <= 39)
            {
                return "Fail";
            }
            else if (getMarkMethod >= 40 && getMarkMethod <= 49)
            {
                return "Third Class";
            }
            else if (getMarkMethod >= 50 && getMarkMethod <= 59)
            {
                return "Lower Second Class";
            }
            else if (getMarkMethod >= 60 && getMarkMethod <= 69)
            {
                return "Upper Second Class";
            }
            else if (getMarkMethod >= 70)
            {
                return "First Class";
            }
            else
            {
                return "N/A";
            }
        }

        //Displays the mean, highest and lowest values of marks in the list.
        private static void OutputStats(List<Student> list)
        {
            Console.WriteLine($"Mean mark: {CalculateMean(list)}\n" +
                $"Lowest Mark: {FindMinimum(list)}\n" +
                $"Highest Mark: {FindMaximum(list)}\n");
        }

        //Sums up all the marks in the list and divides it by the
        //total number of objects int the list.
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

        //Goes through all the student objects and checks if their
        //value is less that the previous.
        //If a lesser value is found, the minimum is updated to that
        //value.
        private static int FindMinimum(List<Student> list)
        {
            int lowestMark = list[0].mark;

            foreach (var student in list) 
            {
                if (student.mark < lowestMark)
                {
                    lowestMark = student.mark;
                }
            }

            return lowestMark;
        }

        //Goes through all the student objects and checks if their
        //value is higher that the previous.
        //If a higher value is found, the minimum is updated to that
        //value.
        private static int FindMaximum(List<Student> list)
        {
            int highestMark = list[0].mark;

            foreach(var student in list)
            {
                if (student.mark > highestMark)
                {
                    highestMark = student.mark;
                }
            }

            return highestMark;
        }

        //Shows the percentage of student's that achieved a certain grade
        private static void DisplayGradeProfile(List<Student> list, char gradeValue)
        {
            Console.WriteLine($"{FindProfile(list, gradeValue)}% of students achieved a grade {gradeValue}.");
        }

        //Iterates through all the student objects
        //If a grade value matches the one specified,
        //the variable 'count' is incrimented.
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