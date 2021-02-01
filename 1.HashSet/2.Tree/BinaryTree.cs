using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Tree
{
    class BinaryTree<T> where T:IComparable
    {
        public int Count { get; set; }
        public Node<T> Root { get; set; }
        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Console.WriteLine($"       __({Root.Data})___");
                Console.WriteLine("      /       /");
                Count = 1;
                return;
            }
            Root.Add(data);
            Count++;
        }
        public static string Print(Node<int> root)
        {
            string result = null;
            if (root.Left != null)
                result += Print(root.Left);

            result += root.Data + " ";

            if (root.Right != null)
                result += Print(root.Right);

            return result;
        }
    }
}
