using System;
using System.Collections.Generic;

class StudentManager
{
    private List<Student> students;

    public StudentManager()
    {
        students = new List<Student>();
    }

    public void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Student student = new Student(name);

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            double grade = Convert.ToDouble(Console.ReadLine());
            student.AddGrade(grade);
        }

        students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\n===== STUDENT LIST =====");

        for (int i = 0; i < students.Count; i++)
        {
            Student s = students[i];

            Console.WriteLine("Name: " + s.GetName());
            Console.WriteLine("Grades: " + s.GetGradesText());
            Console.WriteLine("Average: " + s.GetAverage().ToString("F2"));
            Console.WriteLine();
        }
    }

    public void ViewStudentAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.Write("Enter student name: ");
        string search = Console.ReadLine();

        for (int i = 0; i < students.Count; i++)
        {
            Student s = students[i];

            if (string.Equals(s.GetName(), search, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Average: " + s.GetAverage().ToString("F2"));
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    public void ViewClassAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        double total = 0;

        for (int i = 0; i < students.Count; i++)
            total += students[i].GetAverage();

        double overallAverage = total / students.Count;

        Console.WriteLine("\n===== CLASS AVERAGE =====");
        Console.WriteLine("Overall Average Grade: " + overallAverage.ToString("F2"));
    }

    public void ViewTopStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Student topStudent = students[0];
        double topAverage = topStudent.GetAverage();

        for (int i = 1; i < students.Count; i++)
        {
            double avg = students[i].GetAverage();
            if (avg > topAverage)
            {
                topAverage = avg;
                topStudent = students[i];
            }
        }

        Console.WriteLine("\n===== TOP STUDENT =====");
        Console.WriteLine("Name: " + topStudent.GetName());
        Console.WriteLine("Average: " + topStudent.GetAverage().ToString("F2"));
    }
}
