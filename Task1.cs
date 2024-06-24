using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Variant_5.Task1;

namespace Variant_5
{
    public class Task1

    {
        public class Rectangle
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

            public int C(Rectangle other)
            {
                if (this.Area() > other.Area())
                {
                    return 1;
                }
                else if (this.Area() < other.Area())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }



            public override string ToString()
            {
                return $"a = {A}, b = {B}, p = {Length()}, s = {Area()}";
            }

            
            private Rectangle[] _rectangles;

            public Rectangle[] Rectangles => _rectangles;



            public void Sorting()
            {
                Array.Sort(_rectangles, (x, y) => x.Length() - y.Length());
            }

            public override string ToString()
            {
                string result = "";
                foreach (var rectangle in _rectangles)
                {
                    result += rectangle.ToString() + Environment.NewLine;
                }
                return result;
            }
        }
    }
        
        
    
    
    }












