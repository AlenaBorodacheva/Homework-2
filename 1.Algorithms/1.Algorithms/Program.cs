using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SimpleNumer(10));
            Console.WriteLine(SimpleNumer(5));
            Console.ReadLine();
        }
        static string SimpleNumer(int n)
        {
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }
            if (d == 0)
                return "Простое";
            else
                return "Не простое";
        }
    }
}
