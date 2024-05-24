using System;
using System.Linq;
abstract class Task
{
    public Task(string text) { }
    public abstract char FindMostCommonLetter(string text);
    public abstract int CountPalindromes(string text);
}

class Task_1 : Task
{
    private string _text;
    public Task_1(string text) : base(text)
    {
        _text = text;
    }

    public override char FindMostCommonLetter(string text)
    {
        var letterCounts = text.ToLower().Where(char.IsLetter).GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        char mostCommonLetter = letterCounts.OrderByDescending(pair => pair.Value).First().Key;
        return mostCommonLetter;
    }

    public override int CountPalindromes(string text)
    {
        return 0;
    }

    public override string ToString()
    {
        char mostCommonLetter = FindMostCommonLetter(_text);
        return $"Самая часто встречающаяся буква в тексте: {mostCommonLetter}";
    }
}

class Task_2 : Task
{
    private string _text;
    public Task_2(string text) : base(text)
    {
        _text = text;
    }

    public override int CountPalindromes(string text)
    {
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        int count = 0;
        foreach (string word in words)
        {
            if (word.Length > 1 && IsPalindrome(word))
            {
                count++;
            }
        }
        return count;
    }
    public override char FindMostCommonLetter(string text)
    {
        return ' ';
    }

    private bool IsPalindrome(string word)
    {
        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            if (word[left] != word[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public override string ToString()
    {
        int palindromeCount = CountPalindromes(_text);
        return $"Количество палиндромов в тексте: {palindromeCount}";
    }
}

class Program
{
    public static void Main()
    {
        string text = "Набор слов палиндромов: потоп, шалаш, дед, тут, мадам, мим, шиш";
        Task task = new Task_1(text);
        Console.WriteLine(task.ToString());
        Task task2 = new Task_2(text);
        Console.WriteLine(task2.ToString());
        string path = @"C:\Users\m2303780";
        string folderName = "Solution";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";
    }
}