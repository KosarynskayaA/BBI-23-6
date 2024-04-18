using System;
using System.Collections.Generic;

class Person
{
    private string _name;
    public string Name { get { return _name; } protected set { _name = value; } }
}

class Students : Person
{
    private static int _studbiletCounter = 0;
    private string _studbilet;
    private List<double> _mark;

    public Students(string name)
    {
        _studbilet = (++_studbiletCounter).ToString();
        Name = name;
    }

    public string Studbilet { get { return _studbilet; } }

    public List<double> Mark { get { return _mark; } }

    public double GetAverageMark()
    {
        double sum = 0;
        foreach (double score in _mark)
        {
            sum += score;
        }
        return sum / _mark.Count;
    }

    public void SetMarks(List<double> marks)
    {
        _mark = MergeSort(marks);
    }

    public List<Students> MergeSort(List<Students> arr)
    {
        if (arr.Count <= 1)
            return arr;

        int mid = arr.Count / 2;
        List<double> left = new List<double>();
        List<double> right = new List<double>();

        for (int i = 0; i < mid; i++)
            left.Add(arr[i]);
        for (int i = mid; i < arr.Count; i++)
            right.Add(arr[i]);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private List<double> Merge(List<double> left, List<double> right)
    {
        List<double> result = new List<double>();

        while (left.Count > 0 || right.Count > 0)
        {
            if (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
                else
                {
                    result.Add(right[0]);
                    right.Remove(right[0]);
                }
            }
            else if (left.Count > 0)
            {
                result.Add(left[0]);
                left.Remove(left[0]);
            }
            else if (right.Count > 0)
            {
                result.Add(right[0]);
                right.Remove(right[0]);
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        List<Students> students = new List<Students>();

        students.Add(new Students("Ellis")); 
        students[0].SetMarks(new List<double> { 4.3, 4.1, 4.2, 4.1 });

        students.Add(new Students("Alan"));
        students[1].SetMarks(new List<double> { 3.3, 4.0, 3.8, 3.9 });

        students.Add(new Students("Bernard"));
        students[2].SetMarks(new List<double> { 5, 5, 4.5, 4.2 });

        students.Add(new Students("Effy"));
        students[3].SetMarks(new List<double> { 3.1, 3.2, 3.4, 3.5 });

        students.Add(new Students("Karen"));
        students[4].SetMarks(new List<double> { 5, 4.9, 5, 5 });

        students.Add(new Students("Hanna"));
        students[5].SetMarks(new List<double> { 3, 4, 2, 2 });

        List<Students> filteredStudents = new List<Students>();
        foreach (Students student in students)
        {
            if (student.GetAverageMark() >= 4)
            {
                filteredStudents.Add(student);
            }
        }

        filteredStudents=Students.MergeSort(filteredStudents);

        Console.WriteLine("Student\t\tНомер билета\t\tMark");
        foreach (Students student in filteredStudents)
        {
            Console.WriteLine($"{student.Name}\t\t{student.Studbilet}\t\t{student.GetAverageMark()}");
        }
    }
}