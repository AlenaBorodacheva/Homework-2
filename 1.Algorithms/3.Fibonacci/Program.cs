using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите положительный индекс члена числа Фибоначчи: \t");
            int number = int.Parse(Console.ReadLine());

            //Закомментируйте одну из двух следующих строчек:

            //Console.WriteLine(WithRecursion(number));
            Console.WriteLine(WithoutRecursion(number));

            Console.ReadLine();
        }
        static string WithRecursion(int number)
        {
            int num1 = 0;
            int num2 = 1;
            if (number == 1)
                return $"{num1}";
            else if (number == 2)
                return $"{num2}";
            else
                return WithRecursion(number - 1) + WithRecursion(number - 2);
        }
        static string WithoutRecursion(int number)
        {
            int num1 = 0;
            int num2 = 1;
            int n = 0;
            if (number == 1)
                return $"{num1}";
            else if (number == 2)
                return $"{num2}";
            else
            {
                for (int i = 2; i < number; i++)
                {
                    n = num1 + num2;
                    num1 = num2;
                    num2 = n;
                }
                return $"{n}";
            }
        }
    }
}
