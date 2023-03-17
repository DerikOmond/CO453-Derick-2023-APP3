using System;

namespace ConsoleApp3
{
    class Program
    {
        public static List<Student> studentList = new List<Student>
        {
            new Student("Thato", "Dior", Student.SetMark(58), Student.SetGrade(58)),
            new Student("Pemphero", "Zima", Student.SetMark(49), Student.SetGrade(49)),
            new Student("Jin", "Lane", Student.SetMark(43), Student.SetGrade(43)),
            new Student("Wei", "Delacroix", Student.SetMark(76), Student.SetGrade(76)),
            new Student("Claude", "Deniau", Student.SetMark(57), Student.SetGrade(57)),
            new Student("Munashe", "Joubert", Student.SetMark(33), Student.SetGrade(33)),
            new Student("Léonce", "Isaev", Student.SetMark(13), Student.SetGrade(13)),
            new Student("Jawdat", "Fosse", Student.SetMark(82), Student.SetGrade(82)),
            new Student("Guanyu", "Chauvin", Student.SetMark(91), Student.SetGrade(91)),
            new Student("Mphatso", "Lémieux", Student.SetMark(63), Student.SetGrade(63))
        };

        public static void Main(string[] args) 
        {
            Student.Intro();

            Student.SelectRoute(Student.option, studentList);
        }
    }

}