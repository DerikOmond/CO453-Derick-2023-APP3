using System;

namespace ConsoleApp3
{
    class Program
    {
        public static List<Student> studentList = new List<Student>
        {
            new Student("Thato", "Dior", 58, Student.SetGrade(58),Student.SetClass(58)),
            new Student("Pemphero", "Zima", 49, Student.SetGrade(49), Student.SetClass(49)),
            new Student("Jin", "Lane", 43, Student.SetGrade(43), Student.SetClass(43)),
            new Student("Wei", "Delacroix", 76, Student.SetGrade(76), Student.SetClass(76)),
            new Student("Claude", "Deniau", 57, Student.SetGrade(57), Student.SetClass(57)),
            new Student("Munashe", "Joubert", 33, Student.SetGrade(33), Student.SetClass(33)),
            new Student("Léonce", "Isaev", 13, Student.SetGrade(13), Student.SetClass(13)),
            new Student("Jawdat", "Fosse", 82, Student.SetGrade(82), Student.SetClass(82)),
            new Student("Guanyu", "Chauvin", 91, Student.SetGrade(91), Student.SetClass(91)),
            new Student("Mphatso", "Lémieux", 63, Student.SetGrade(63), Student.SetClass(63))
        };

        public static void Main(string[] args) 
        {            Student.Run(studentList);
        }
    }

}