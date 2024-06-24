using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task2
    {
        public abstract class Rectangle
        {
            private int _a;
            private int _b;

            public int A => _a;
            public int B => _b;

            public Rectangle(int a, int b)
            {
                _a = a;
                _b = b;
            }

            public int Length()
            {
                return 2 * (_a + _b);
            }

            public int Area()
            {
                return _a * _b;
            }

            public abstract double Cost();

            public override string ToString()
            {
                return $"p = {Length()}, s = {Area()}, price = {Cost()}";
            }
        }

        public abstract class Embrasure : Rectangle
        {
            private int _thick;

            public int C => _thick;

            public Embrasure(int a, int b, int thick) : base(a, b)
            {
                _thick = thick;
            }

            public override double Cost()
            {
                return base.Length() * 10;
            }

            public override string ToString()
            {
                return $"Type = {GetType().Name}, {base.ToString()}";
            }
        }

        public class Window : Embrasure
        {
            private int _layers;

            public int Layers => _layers;

            public Window(int a, int b, int thick, int layers) : base(a, b, thick)
            {
                _layers = layers;
            }

            public override double Cost()
            {
                return base.Cost() + _layers / 0.3;
            }
        }

        public class Door : Embrasure
        {
            private string _material;

            public string Material => _material;

            public Door(int a, int b, int thick, string material) : base(a, b, thick)
            {
                _material = material;
            }

            public override double Cost()
            {
                double multiplier = 1;
                switch (_material)
                {
                    case "пластик":
                        multiplier = 1.25;
                        break;
                    case "дерево":
                        multiplier = 1.33;
                        break;
                    case "стекло":
                        multiplier = 1.5;
                        break;
                }
                return base.Cost() * multiplier;
            }
        }

        
            private Embrasure[] _embrasures;

            public Embrasure[] Embrasures => _embrasures;

            public Task2(Embrasure[] embrasures)
            {
                _embrasures = embrasures;
            }

            public void Sorting()
            {
                Array.Sort(_embrasures, (x, y) => x.Cost().CompareTo(y.Cost()));
            }

            public override string ToString()
            {
                string result = "";
                foreach (var embrasure in _embrasures)
                {
                    result += embrasure.ToString() + Environment.NewLine;
                }
                return result;
            }
        
    class Program
        {
            static void Main(string[] args)
            {
                Embrasure[] embrasures = new Embrasure[]
                {
        new Window(2, 3, 5, 2),
        new Door(4, 1, 3, "дерево"),
        new Window(1, 5, 2, 3)
                };

                Task2 task = new Task2(embrasures);

                Console.WriteLine(task.ToString());
               
                task.Sorting();

                Console.WriteLine("\nОтсортированные проемы:");
                Console.WriteLine(task.ToString());

                Console.ReadKey();
            }
        }
    }


}


