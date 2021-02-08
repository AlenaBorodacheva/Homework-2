using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPr
{
    class Program
    {
        const int N = 8;
        const int M = 8;

        static void Print(int n, int m, int[,] a)
        {
            Console.WriteLine("Матрица с количеством маршрутов:");
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (a[i, j] > 999)
                        Console.Write(a[i, j] + "  ");
                    else if (a[i, j] > 99)
                        Console.Write(a[i, j] + "   ");
                    else if(a[i, j] > 9)
                        Console.Write(a[i, j] + "    ");
                    else
                        Console.Write(a[i, j] + "     ");
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            int[,] A = new int[N, M];
            int i, j, k;
            for (j = 0; j < M; j++)
                A[0, j] = 1; 
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }
            k = A[N-1, M-1];
            Print(N, M, A);

            Console.WriteLine($"Количество путей из верхней левой клетки в правую нижнюю = {k}");
            Console.ReadLine();
        }
    }
}

