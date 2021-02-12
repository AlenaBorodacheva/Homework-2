using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            BucketAndExternalSort sort = new BucketAndExternalSort();
            Random rnd = new Random();

            var arr = CreateArr(12, rnd);
            Console.WriteLine("Изначальный массив:");
            Print(arr);

            var BucketSortArr = sort.BucketSort(arr);
            Console.WriteLine("Отсортированный с помощью Bucket Sort:");
            Print(BucketSortArr);

            //Не до конца поняла, чем в домашке должны отличаться BucketSort от ExternalSort. 
            //У ExternalSort алгоритм такой:

            var block1 = CreateArr(12, rnd);
            var block2 = CreateArr(10, rnd);
            var block3 = CreateArr(8, rnd);

            Console.WriteLine("Три массива, взятых со стороннего файла:");
            Print(block1);
            Print(block2);
            Print(block3);

            sort.QuickSort(block1, 0, block1.Length - 1);
            sort.QuickSort(block2, 0, block2.Length - 1);
            sort.QuickSort(block3, 0, block3.Length - 1);

            var arr1 = sort.Merge(block1, block2);
            var result = sort.Merge(arr1, block3);
            Console.WriteLine("Отсортированный с помощью External Sort:");
            Print(result);

            Console.ReadLine();
        }
        static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        static int[] CreateArr(int size, Random rnd)
        {
            
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(100);
            }
            return arr;
        }
    }
}
