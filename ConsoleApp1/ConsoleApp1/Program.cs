using System;
using System.Collections.Generic;

class Program
{
    static List<string> studentNames = new List<string>();
    static List<double[]> studentGrades = new List<double[]>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== STUDENT SYSTEM =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View all Students");
            Console.WriteLine("3. Compute Average Grade");
            Console.WriteLine("4. Find Highest Grade");
            Console.WriteLine("5. Exit");
            Console.WriteLine("==========================");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

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
                    Console.WriteLine("\nExiting program...");
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 5);
    }

    static void AddStudent()
    {
        Console.Write("\nEnter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter grade 1: ");
        double grade1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter grade 2: ");
        double grade2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter grade 3: ");
        double grade3 = Convert.ToDouble(Console.ReadLine());

        studentNames.Add(name);
        studentGrades.Add(new double[] { grade1, grade2, grade3 });

        Console.WriteLine("Student added successfully!");
    }

    static void ViewAllStudents()
    {
        if (studentNames.Count == 0)
        {
            Console.WriteLine("\nNo students found.");
            return;
        }

        Console.WriteLine("\n===== STUDENT LIST =====");

        for (int i = 0; i < studentNames.Count; i++)
        {
            double average =
                (studentGrades[i][0] +
                 studentGrades[i][1] +
                 studentGrades[i][2]) / 3;

            Console.WriteLine($"\nName: {studentNames[i]}");
            Console.WriteLine($"Grades: {studentGrades[i][0]}, {studentGrades[i][1]}, {studentGrades[i][2]}");
            Console.WriteLine($"Average: {average:F2}");
        }
    }

    static void ComputeClassAverage()
    {
        if (studentNames.Count == 0)
        {
            Console.WriteLine("\nNo students available.");
            return;
        }

        double totalAverage = 0;

        for (int i = 0; i < studentNames.Count; i++)
        {
            double studentAverage =
                (studentGrades[i][0] +
                 studentGrades[i][1] +
                 studentGrades[i][2]) / 3;

            totalAverage += studentAverage;
        }

        double classAverage = totalAverage / studentNames.Count;

        Console.WriteLine("\n===== CLASS AVERAGE =====");
        Console.WriteLine($"Overall Average Grade: {classAverage:F2}");
    }

    static void FindHighestGrade()
    {
        if (studentNames.Count == 0)
        {
            Console.WriteLine("\nNo students available.");
            return;
        }

        string topStudent = "";
        double highestGrade = 0;

        for (int i = 0; i < studentNames.Count; i++)
        {
            foreach (double grade in studentGrades[i])
            {
                if (grade > highestGrade)
                {
                    highestGrade = grade;
                    topStudent = studentNames[i];
                }
            }
        }

        Console.WriteLine("\n===== HIGHEST GRADE =====");
        Console.WriteLine($"Top Student: {topStudent}");
        Console.WriteLine($"Highest Grade: {highestGrade}");
    }
}