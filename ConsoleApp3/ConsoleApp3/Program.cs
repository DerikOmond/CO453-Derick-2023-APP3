using System;

namespace ConsoleApp3
{
    class Program
    {
        public static void Main(string[] args) 
        {
            List<Student> studentList = new List<Student>();

            Student Student1 = new Student("Thato", "Dior", 58, 'C');
            Student Student2 = new Student("Pemphero", "Zima", 49, 'D');
            Student Student3 = new Student("Jin", "Lane", 43, 'D');
            Student Student4 = new Student("Wei", "Delacroix", 76, 'A');
            Student Student5 = new Student("Claude", "Deniau", 57, 'C');
            Student Student6 = new Student("Munashe", "Joubert", 33, 'F');
            Student Student7 = new Student("Léonce", "Isaev", 13, 'F');
            Student Student8 = new Student("Jawdat", "Fosse", 82, 'A');
            Student Student9 = new Student("Guanyu", "Chauvin", 91, 'A');
            Student Student10 = new Student("Mphatso", "Lémieux", 63, 'B');

            studentList.Add(Student1);
            studentList.Add(Student2);
            studentList.Add(Student3);
            studentList.Add(Student4);
            studentList.Add(Student5);
            studentList.Add(Student6);
            studentList.Add(Student7);
            studentList.Add(Student8);
            studentList.Add(Student9);
            studentList.Add(Student10);

            Student.Intro();
            Student.DisplayStudent(studentList);

        }
    }

}