using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
    public static class StudentLogic
    {
        public static void AddStudent(List<Student> students, string name, List<int> grades)
        {
            students.Add(new Student(name, grades));
        }

        public static string ViewAllStudents(List<Student> students)
        {
            if (students.Count == 0)
                return "No students found.";

            var lines = new List<string>();

            for (int i = 0; i < students.Count; i++)
            {
                Student s = students[i];

                lines.Add("Name: " + s.Name);
                lines.Add("Grades: " + string.Join(", ", s.Grades));
                lines.Add("Average: " + s.Average().ToString("0.00"));

                if (i < students.Count - 1)
                    lines.Add(""); // blank line between students
            }

            return string.Join(Environment.NewLine, lines);
        }

        public static double ComputeClassAverage(List<Student> students)
        {
            if (students.Count == 0) return 0.00;

            var allGrades = students.SelectMany(s => s.Grades).ToList();
            if (allGrades.Count == 0) return 0.00;

            return allGrades.Average();
        }

        public static (string topStudent, int highestGrade) FindHighestGrade(List<Student> students)
        {
            if (students.Count == 0) return ("", 0);

            int highest = int.MinValue;
            string top = "";

            foreach (var s in students)
            {
                if (s.Grades.Count == 0) continue;

                int max = s.Grades.Max();
                if (max > highest)
                {
                    highest = max;
                    top = s.Name;
                }
            }

            if (highest == int.MinValue) return ("", 0);
            return (top, highest);
        }
    }
}