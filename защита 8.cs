using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;

internal class Program
{
    abstract class Task
    {
        protected string input;
        protected string output;
        protected Task(string text)
        {
            input = text;
        }
        public override string ToString()
        {
            return output;
        }
    }
    class Task1 : Task
    {
        public Task1(string text) : base(text)
        {
            var top = new Dictionary<char, int>();
            foreach (char x in text)
            {
                char sym = char.ToLower(x);
                if (char.IsLetter(sym))
                {
                    if (top.ContainsKey(sym)) { top[sym]++; }
                    else { top.Add(sym, 1); }
                }
            }
            int all = 0;
            foreach (int x in top.Values) { all += x; }
            foreach (var x in top)
            {
                output += $"{x.Key}: {(float)x.Value * 100 / all}%\n";
            }
        }
    }
   

        struct CharCount
        {
            public char Symbol { get; private set; }
            public int Count { get; private set; }

            public CharCount(char symbol)
            {
                Symbol = symbol; 
                Count = 1;
            }

            public void Increment()
            {
                Count++;
            }
        
        }

        class Task5 : Task
        {
            public Task5(string text) : base(text)
            {
                string nums = "0123456789";
                string[] words = text.Split(' ');
                List<CharCount> charCounts = new List<CharCount>();

                foreach (string word in words)
                {
                    char sym = char.ToLower(word[0]);
                    if (!nums.Contains(sym))
                    {
                        CharCount? e = charCounts.Find(c => c.Symbol == sym);
                        if (e != null)
                    {
                        CharCount existingChar = charCounts.Find(c => c.Symbol == sym);
                        existingChar.Increment();
                    }
                    else { charCounts.Add(new CharCount(sym)); }
                    }
                }

                var sorted = charCounts.OrderByDescending(x => x.Count);
                int all = sorted.Sum(c => c.Count);
                foreach (var charCount in sorted)
                {
                    output += $"{charCount.Symbol}: {(float)charCount.Count * 100 / all}%\n";
                }
            }
        }
        static void Main(string[] args)
        {
            string s = "1 июля 2015 года Греция объявила о дефолте по государственному долгу, став первой развитой страной в истории, которая не смогла выплатить свои долговые обязательства в полном объеме. Сумма дефолта составила порядка 1,6 миллиарда евро. Этому предшествовали долгие переговоры с международными кредиторами, такими как Международный валютный фонд (МВФ), Европейский центральный банк (ЕЦБ) и Европейская комиссия (ЕК), о программах финансовой помощи и реструктуризации долга. Основными причинами дефолта стали недостаточная эффективность реформ, направленных на улучшение финансовой стабильности страны, а также политическая нестабильность, что вызвало потерю доверия со стороны международных инвесторов и кредиторов. Последствия дефолта оказались глубокими и долгосрочными: сокращение кредитного рейтинга страны, увеличение затрат на заемный капитал, рост стоимости заимствований и утрата доверия со стороны международных инвесторов.";
            string last_names = "Иванов, Петров, Смирнов, Соколов, Кузнецов, Попов, Лебедев, Волков, Козлов, Новиков, Иванова, Петрова, Смирнова, Ivanov, Petrov, Smirnov, Sokolov, Kuznetsov, Popov, Lebedev, Volkov, Kozlov, Novikov, Ivanova, Petrova, Smirnova";
            string[] nums = { "Задание 1", "Задание 3", "Задание 5", "Задание 7", "Задание 11", "Задание 14" };
            Task[] tasks = {
            new Task1(s),
           // new Task3(s),
            new Task5(s),
            //new Task7(s, "ро"),
            //new Task11(last_names),
           // new Task14(s)
        };
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine(nums[i]);
                Console.WriteLine(tasks[i]);
            }
        }
    }
   