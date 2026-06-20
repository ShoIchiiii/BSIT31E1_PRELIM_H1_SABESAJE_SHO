using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                ShowMainMenu();
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
                {
                    Console.Write("Invalid input. Choose an option (1-5): ");
                    input = Console.ReadLine();
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewAllStudents();
                        break;
                    case 3:
                        ComputeClassAverage();
                        break;
                    case 4:
                        FindHighestGrade();
                        break;
                    case 5:
                        ExitProgram();
                        break;
                }

            } while (choice != 5);
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
        }

        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = (Console.ReadLine() ?? "").Trim();

            var grades = new List<int>();
            for (int i = 1; i <= 3; i++)
            {
                int grade;
                while (true)
                {
                    Console.Write($"Enter grade {i}: ");
                    string gInput = Console.ReadLine();

                    if (int.TryParse(gInput, out grade) && grade >= 0 && grade <= 100)
                        break;

                    Console.WriteLine("Please enter a valid grade (0-100).");
                }
                grades.Add(grade);
            }

            StudentLogic.AddStudent(students, name, grades);
            Console.WriteLine("Student added successfully!");
        }

        static void ViewAllStudents()
        {
            Console.WriteLine("===== STUDENT LIST =====");

            string output = StudentLogic.ViewAllStudents(students);
            Console.WriteLine(output);
        }

        static void ComputeClassAverage()
        {
            Console.WriteLine("===== CLASS AVERAGE =====");
            double overall = StudentLogic.ComputeClassAverage(students);
            Console.WriteLine($"Overall Average Grade: {overall:0.00}");
        }

        static void FindHighestGrade()
        {
            Console.WriteLine("===== HIGHEST GRADE =====");
            var result = StudentLogic.FindHighestGrade(students);

            if (result.topStudent == "")
            {
                Console.WriteLine("Top Student: ");
                Console.WriteLine("Highest Grade: 0");
                return;
            }

            Console.WriteLine("Top Student: " + result.topStudent);
            Console.WriteLine("Highest Grade: " + result.highestGrade);
        }

        static void ExitProgram()
        {
            Console.WriteLine("Exiting program...");
            Console.WriteLine("Goodbye!");
        }
    }
}
