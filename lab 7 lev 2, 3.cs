////7/2/1
//using System;
//using System.Collections.Generic;

//class Person
//{
//    private string _name;
//    public string Name { get { return _name; } set { _name = value; } }
//}

//class Students : Person
//{
//    private static int _studbiletCounter = 0;
//    private string _studbilet;
//    private List<double> _mark;

//    public Students()
//    {
//        _studbilet = (++_studbiletCounter).ToString();
//    }

//    public string Studbilet { get { return _studbilet; } }

//    public List<double> Mark { get { return _mark; } }

//    public double GetAverageMark()
//    {
//        double sum = 0;
//        foreach (double score in _mark)
//        {
//            sum += score;
//        }
//        return sum / _mark.Count;
//    }

//    public void SetMarks(List<double> marks)
//    {
//        _mark = marks;
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        List<Students> students = new List<Students>();

//        students.Add(new Students { Name = "Ellis" });
//        students[0].SetMarks(new List<double> { 4.3, 4.1, 4.2, 4.1 });

//        students.Add(new Students { Name = "Alan" });
//        students[1].SetMarks(new List<double> { 3.3, 4.0, 3.8, 3.9 });

//        students.Add(new Students { Name = "Bernard" });
//        students[2].SetMarks(new List<double> { 5, 5, 4.5, 4.2 });

//        students.Add(new Students { Name = "Effy" });
//        students[3].SetMarks(new List<double> { 3.1, 3.2, 3.4, 3.5 });

//        students.Add(new Students { Name = "Karen" });
//        students[4].SetMarks(new List<double> { 5, 4.9, 5, 5 });

//        students.Add(new Students { Name = "Hanna" });
//        students[5].SetMarks(new List<double> { 3, 4, 2, 2 });

//        List<Students> filteredStudents = new List<Students>();
//        foreach (Students student in students)
//        {
//            if (student.GetAverageMark() >= 4)
//            {
//                filteredStudents.Add(student);
//            }
//        }

//        filteredStudents.Sort((s1, s2) => s2.GetAverageMark().CompareTo(s1.GetAverageMark()));

//        Console.WriteLine("Student\t\tНомер билета\t\tMark");
//        foreach (Students student in filteredStudents)
//        {
//            Console.WriteLine($"{student.Name}\t\t{student.Studbilet}\t\t{student.GetAverageMark()}");
//        }
//    }
//}
///7/3/4
using System;
using System.Collections.Generic;

public class Program
{
    abstract class Athlete
    {
        public string Name { get; }
        public int Result { get; }

        protected Athlete(string name, int result)
        {
            Name = name;
            Result = result;
        }

        public abstract void PrintInfo();
    }

    class Skier : Athlete
    {
        public Skier(string name, int result) : base(name, result) { }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Result: {Result}");
        }
    }

    class SkierWoman : Skier
    {
        public SkierWoman(string name, int result) : base(name, result) { }
    }

    class SkierMan : Skier
    {
        public SkierMan(string name, int result) : base(name, result) { }
    }

    static void Main(string[] args)
    {
        List<Athlete> team1Women = new List<Athlete>();
        List<Athlete> team1Men = new List<Athlete>();
        List<Athlete> team2Women = new List<Athlete>();
        List<Athlete> team2Men = new List<Athlete>();

        Console.WriteLine("Enter the number of women skiers for team 1:");
        int numWomenTeam1 = int.Parse(Console.ReadLine());

        for (int i = 0; i < numWomenTeam1; i++)
        {
            Console.WriteLine($"Enter name and result for skier {i + 1} for team 1:");
            string name = Console.ReadLine();
            int result = int.Parse(Console.ReadLine());
            team1Women.Add(new SkierWoman(name, result));
        }

        Console.WriteLine("Enter the number of men skiers for team 1:");
        int numMenTeam1 = int.Parse(Console.ReadLine());

        for (int i = 0; i < numMenTeam1; i++)
        {
            Console.WriteLine($"Enter name and result for skier {i + 1} for team 1:");
            string name = Console.ReadLine();
            int result = int.Parse(Console.ReadLine());
            team1Men.Add(new SkierMan(name, result));
        }

     
        team1Women.Sort((x, y) => y.Result.CompareTo(x.Result));
        team1Men.Sort((x, y) => y.Result.CompareTo(x.Result));

        Console.WriteLine("Team 1 Women:");
        foreach (var skier in team1Women)
        {
            skier.PrintInfo();
        }

     
        List<Athlete> allAthletes = new List<Athlete>();
        allAthletes.AddRange(team1Women);
        allAthletes.AddRange(team1Men);
        allAthletes.Sort((x, y) => y.Result.CompareTo(x.Result));

    
        Console.WriteLine("Combined Results:");
        foreach (var skier in allAthletes)
        {
            skier.PrintInfo();
        }
    }
}
