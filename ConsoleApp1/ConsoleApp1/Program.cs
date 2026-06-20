

namespace StudentManagementSystem
{
    public class Student
    {
        public string Name;
        public List<int> Grades;

        public Student(string name, List<int> grades)
        {
            Name = name;
            Grades = grades;
        }

        public double Average()
        {
            return Grades.Count == 0 ? 0.0 : Grades.Average();
        }
    }
}
