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

            if (students.Count == 0) return "No students to display.";

            var lines = new List<string>();

            foreach (var s in students)

            {

                lines.Add("Name: " + s.Name);

                lines.Add("Grades: " + string.Join(", ", s.Grades));

                lines.Add("Average: " + s.Average().ToString("0.00"));

            }

            return string.Join(Environment.NewLine, lines);

        }

        public static double ComputeClassAverage(List<Student> students)

        {

            if (students.Count == 0) return 0.0;

            var allGrades = students.SelectMany(s => s.Grades).ToList();

            return allGrades.Count == 0 ? 0.0 : allGrades.Average();

        }

        public static (string topStudent, int highestGrade) FindHighestGrade(List<Student> students)

        {

            if (students.Count == 0) return ("", 0);

            int highest = int.MinValue;

            string topStudent = "";

            foreach (var s in students)

            {

                int studentMax = s.Grades.Count > 0 ? s.Grades.Max() : int.MinValue;

                if (studentMax > highest)

                {

                    highest = studentMax;

                    topStudent = s.Name;

                }

            }

            return (highest == int.MinValue) ? ("", 0) : (topStudent, highest);

        }

    }

}

