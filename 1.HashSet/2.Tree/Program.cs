using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Tree
{
    class Program
    {
        static void Main(string[] args)
        {

            var tree = new BinaryTree<int>();
            tree.Add(6);
            tree.Add(2);
            tree.Add(11);
            tree.Add(3);
            tree.Add(9);
            tree.Add(30);

            Console.ReadLine();
        }
    }
}
