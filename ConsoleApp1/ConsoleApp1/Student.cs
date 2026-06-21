using System;
using System.Collections.Generic;

class Student
{
    private string name;
    private List<double> grades;

    public Student(string name)
    {
        this.name = name;
        grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }

    public string GetName()
    {
        return name;
    }

    public double GetAverage()
    {
        if (grades.Count == 0)
            return 0;

        double total = 0;

        for (int i = 0; i < grades.Count; i++)
            total += grades[i];

        return total / grades.Count;
    }
}