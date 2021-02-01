using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_and_BFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            tree.Add(8);
            tree.Add(10);
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);
            tree.Add(11);
            tree.Add(9);
            PrintTree.Print(tree.Parent);
            tree.BFS(tree.Parent);
            tree.DFS(tree.Parent);
            Console.ReadLine();
        }
        
    }
}
