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
            int num = Start();
            while (num != 0)
            {
                if (num == 1)
                {
                    Console.WriteLine("Введите значение:");
                    int value = int.Parse(Console.ReadLine());
                    tree.Add(value);
                    Console.WriteLine("Значение добавлено.\n");
                }
                else if (num == 2)
                {
                    Console.WriteLine("Введите значение, которое хотите удалить:");
                    int value = int.Parse(Console.ReadLine());
                    tree.Remove(value);
                    Console.WriteLine("Значение удалено.");
                }
                else
                {
                    PrintTree.Print(tree.Parent);
                    Console.WriteLine();
                }
                num = Start();
            }

            Console.ReadLine();
        }
        public static int Start()
        {
            int num;
            try 
            {
                do
                {
                    Console.WriteLine("Если хотите добавить элементы в дерево, нажмите 1. \n" +
                                      "Если хотите удалить элементы из дерева, нажмите 2.\n" +
                                      "Если хотите вывести дерево на экран, нажмите 3.\n" +
                                      "Если хотите закончить, нажмите 0.");
                    num = int.Parse(Console.ReadLine());
                }
                while (num != 0 && num != 1 && num != 2 && num != 3);
            }
            catch
            {
                num = Start();
            }
            return num;
        }
    }
}
