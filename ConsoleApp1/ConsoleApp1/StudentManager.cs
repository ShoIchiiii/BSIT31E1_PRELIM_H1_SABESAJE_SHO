
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

        Console.Write("How many grades? ");
        int count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            double grade = Convert.ToDouble(Console.ReadLine());
            student.AddGrade(grade);
        }

        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Console.WriteLine("\nStudent List:");

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine(students[i].GetName());
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
                Console.WriteLine(
                    "Average of " + s.GetName() + ": " + s.GetAverage().ToString("F2")
                );
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

        double classAverage = total / students.Count;

        Console.WriteLine("Class Average: " + classAverage.ToString("F2"));
    }

    public void ViewTopStudent()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.");
            return;
        }

        Student topStudent = students[0];
        double topAvg = topStudent.GetAverage();

        for (int i = 1; i < students.Count; i++)
        {
            double avg = students[i].GetAverage();
            if (avg > topAvg)
            {
                topAvg = avg;
                topStudent = students[i];
            }
        }

        Console.WriteLine("Top Student: " + topStudent.GetName());
        Console.WriteLine("Average Grade: " + topStudent.GetAverage().ToString("F2"));
    }
}
