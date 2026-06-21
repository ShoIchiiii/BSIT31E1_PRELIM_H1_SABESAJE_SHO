using System;

class Program
{
    static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
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
                    manager.ViewClassAverage();
                    break;

                case "4":
                    manager.ViewTopStudent();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Exiting program... \nGoodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}