using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Student
    {
        public void Run()
        {
            DisplayHeader();
            DisplayMenu();
        }

        private void DisplayHeader()
        {
            Console.WriteLine("\n==========================================================================================");
            Console.WriteLine("========                           App03 Student Marks                            ========");
            Console.WriteLine("========                             By Derick Omondi                             ========");
            Console.WriteLine("==========================================================================================\n");
            Console.Write("Press enter to begin > ");
            Console.ReadLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("1. Input Marks");
            Console.WriteLine("2. Output Marks");
            Console.WriteLine("3. Output Stats");
            Console.WriteLine("4. Output Grade Profile");
            Console.WriteLine("5. Exit");
        }
    }
}
