using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class BucketAndExternalSort
    {
        public int[] BucketSort(int[] array)
        {
            var a = new List<int>();
            var b = new List<int>();
            var c = new List<int>();
            var d = new List<int>();
            var e = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 20)                
                    a.Add(array[i]);                
                else if (array[i] >= 20 && array[i] < 40)                
                    b.Add(array[i]);                
                else if (array[i] >= 40 && array[i] < 60)                
                    c.Add(array[i]);                
                else if (array[i] >= 60 && array[i] < 80)                
                    d.Add(array[i]);                
                else                
                    e.Add(array[i]);                
            }

            if (a.Count != 0)
                QuickSort(a, 0, a.Count - 1);
            if (b.Count != 0)
                QuickSort(b, 0, b.Count - 1);
            if (c.Count != 0)
                QuickSort(c, 0, c.Count - 1);
            if (d.Count != 0)
                QuickSort(d, 0, d.Count - 1);
            if (e.Count != 0)
                QuickSort(e, 0, e.Count - 1);
           
            var list1 = Merge(a, b);
            var list2 = Merge(c, d);
            var list3 = Merge(list1, list2);
            var list4 = Merge(list3, e);

            return ArrayFromList(list4);

        }
        public void QuickSort(List<int> list, int first, int last)
        {
            int i = first, j = last, x = list[(first + last) / 2];
            do
            {
                while (list[i] < x)
                    i++;
                while (list[j] > x)
                    j--;

                if (i <= j)
                {
                    if (list[i] > list[j])
                    {
                        var tmp = list[i];
                        list[i] = list[j];
                        list[j] = tmp;
                    }
                    i++;
                    j--;
                }
            } 
            while (i <= j);

            if (i < last)
                QuickSort(list, i, last);
            if (first < j)
                QuickSort(list, first, j);
        }
        
        public void QuickSort(int[] array, int first, int last)
        {
            int i = first, j = last, x = array[(first + last) / 2];
            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (array[i] > array[j])
                    {
                        var tmp = array[i];
                        array[i] = array[j];
                        array[j] = tmp;
                    }

                    i++;
                    j--;
                }
            } 
            while (i <= j);

            if (i < last)
                QuickSort(array, i, last);
            if (first < j)
                QuickSort(array, first, j);
        }

        public List<int> Merge(List<int> left, List<int> right)
        {
            List<int> list = new List<int>();
            int leftItem = 0;
            int rightItem = 0;
            while (leftItem < left.Count)
            {
                while (rightItem < right.Count)
                {
                    if (left[leftItem] < right[rightItem])
                    {
                        list.Add(left[leftItem]);
                        leftItem++;
                        break;
                    }
                    else
                    {
                        list.Add(right[rightItem]);
                        rightItem++;
                    }
                }
                if (rightItem == right.Count || leftItem == left.Count)
                    break;
            }

            if (leftItem != left.Count)
            {
                for (int k = leftItem; k < left.Count; k++)
                {
                    list.Add(left[k]);
                }
            }

            if (rightItem != right.Count)
            {
                for (int k = rightItem; k < right.Count; k++)
                {
                    list.Add(right[k]);
                }
            }

            return list;
        }

        public int[] Merge(int[] left, int[] right)
        {
            int[] arr = new int[left.Length + right.Length];
            int leftItem = 0;
            int rightItem = 0;
            while (leftItem < left.Length)
            {
                while (rightItem < right.Length)
                {
                    if (left[leftItem] < right[rightItem])
                    {
                        arr[leftItem + rightItem] = left[leftItem];
                        leftItem++;
                        break;
                    }
                    else
                    {
                        arr[leftItem + rightItem] = right[rightItem];
                        rightItem++;
                    }
                }
                if (rightItem == right.Length || leftItem == left.Length)
                    break;
            }

            if (leftItem != left.Length)
            {
                for (int k = leftItem; k < left.Length; k++)
                {
                    arr[right.Length + k] = left[k];
                }
            }

            if (rightItem != right.Length)
            {
                for (int k = rightItem; k < right.Length; k++)
                {
                    arr[left.Length + k] = right[k];
                }
            }

            return arr;
        }

        public int[] ArrayFromList(List<int> list)
        {
            int[] arr = new int[list.Count];
            for(int i = 0; i < list.Count; i++)
            {
                arr[i] = list[i];
            }
            return arr;
        }
    }
}
