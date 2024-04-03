////1/1
//using System;
//class Members
//{
//    private readonly string _surname;
//    private readonly string _community;
//    private readonly double _result1;
//    private readonly double _result2;
//    private bool _disqualified;
//    public string Surname { get { return _surname; } }
//    public string Community { get { return _community; } }
//    public double Result1 { get { return _result1; } }
//    public double Result2 { get { return _result2; } }
//    public bool IsDisqualified { get { return _disqualified; } }

//    public Members(string surname, string community, double result1, double result2)
//    {
//        _surname = surname;
//        _community = community;
//        _result1 = result1;
//        _result2 = result2;
//        _disqualified = false;
//    }

//    public double GetTotalResult()
//    {
//        return Result1 + Result2;
//    }
//    public void Disqualify()
//    {
//        _disqualified = true;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        List<Members> participants = new List<Members>();

//        participants.Add(new Members("Adams", "Community 1", 1.5, 1.1));
//        participants.Add(new Members("Kennedy", "Community 2", 1.2, 1.3));
//        participants.Add(new Members("Black", "Community 3", 1.3, 1.1));
//        participants.Add(new Members("Harrison", "Community 4", 1.4, 1.4));
//        participants.Add(new Members("Daniels", "Community 5", 1.2, 1.4));
//        participants[2].Disqualify();

//        participants.Sort((p1, p2) => p2.GetTotalResult().CompareTo(p1.GetTotalResult()));

//        Console.WriteLine("Place \tSurname \tCommunity\tResult");
//        for (int i = 0; i < participants.Count; i++)
//        {
//            Members participant = participants[i];
//            if (participants[i].IsDisqualified != true)
//            {
//                Console.WriteLine($"{i + 1}\t{participant.Surname}\t{participant.Community}\t{participant.GetTotalResult()}");
//            }

//        }
//    }
//}
//2/1
using System;
using System.Collections.Generic;
class Person
{
    private string _name;
    public string Name { get { return _name; } set { _name = value; } }
}

class Students : Person
{
    private string _studbilet;
    private List<double> _mark;

    public string Studbilet { get { return _studbilet; } set { _studbilet = value; } }

    public List<double> Mark { get { return _mark; } set { _mark = value; } }

    public double GetAverageMark()
    {
        double sum = 0;
        foreach (double score in _mark)
        {
            sum += score;
        }
        return sum / _mark.Count;
    }
}


class Program
{
    static void Main()
    {
        List<Students> students = new List<Students>();

        students.Add(new Students { Name = "Ellis", Studbilet = "1", Mark = new List<double> { 4.3, 4.1, 4.2, 4.1 } });
        students.Add(new Students { Name = "Alan", Studbilet = "2", Mark = new List<double> { 3.3, 4.0, 3.8, 3.9 } });
        students.Add(new Students { Name = "Bernard", Studbilet = "3", Mark = new List<double> { 5, 5, 4.5, 4.2 } });
        students.Add(new Students { Name = "Effy", Studbilet = "4", Mark = new List<double> { 3.1, 3.2, 3.4, 3.5 } });
        students.Add(new Students { Name = "Karen", Studbilet = "5", Mark = new List<double> { 5, 4.9, 5, 5 } });
        students.Add(new Students { Name = "Hanna", Studbilet = "6", Mark = new List<double> { 3, 4, 2, 2 } });


        List<Students> filteredStudents = new List<Students>();
        foreach (Students student in students)
        {
            if (student.GetAverageMark() >= 4)
            {
                filteredStudents.Add(student);
            }
        }

        filteredStudents.Sort((s1, s2) => s2.GetAverageMark().CompareTo(s1.GetAverageMark()));

        Console.WriteLine("Student\t\tНомер билета\t\tMark");
        foreach (Students student in filteredStudents)
        {
            Console.WriteLine($"{student.Name}\t\t{student.Studbilet}\t\t{student.GetAverageMark()}");
        }
    }
}