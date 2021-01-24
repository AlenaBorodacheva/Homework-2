using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сложность: O(log(n))
            var array = new int[] {3, 4, 5, 6, 7 };
            int searchValue = 6;
            int num = BinarySearch(array, searchValue);
            if (num != -1)
                Console.WriteLine($"Индекс элемента равен {num}.");
            else
                Console.WriteLine("Элемент не найден. ");
            Console.ReadLine();
        }
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
