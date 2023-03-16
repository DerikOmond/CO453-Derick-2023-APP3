using System;

namespace ConsoleApp3
{
    class Program
    {
        public static void Main(string[] args) 
        {
            List<Student> studentList = new List<Student>
            {
                new Student("Thato", "Dior", 58, 'C'),
                new Student("Pemphero", "Zima", 49, 'D'),
                new Student("Jin", "Lane", 43, 'D'),
                new Student("Wei", "Delacroix", 76, 'A'),
                new Student("Claude", "Deniau", 57, 'C'),
                new Student("Munashe", "Joubert", 33, 'F'),
                new Student("Léonce", "Isaev", 13, 'F'),
                new Student("Jawdat", "Fosse", 82, 'A'),
                new Student("Guanyu", "Chauvin", 91, 'A'),
                new Student("Mphatso", "Lémieux", 63, 'B')
            };

            Student.Intro();

            Student.SelectRoute(Student.option, studentList);
        }
    }

}