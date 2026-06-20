using System;

class Program
{
    static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== STUDENT MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. View Student Average");
            Console.WriteLine("4. View Class Average");
            Console.WriteLine("5. View Top Student");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddStudent();
                    break;

                case "2":
                    manager.ViewStudents();
                    break;

                case "3":
                    manager.ViewStudentAverage();
                    break;

                case "4":
                    manager.ViewClassAverage();
                    break;

                case "5":
                    manager.ViewTopStudent();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
