using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Tree
{
    class Node<T> : IComparable<T> where T : IComparable 
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> left, Node<T> right)
        {
            Left = left;
            Right = right;
            Data = data;
        }
        public int CompareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
                throw new Exception("Несовпадение типов");
        }
        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }
        public string Str { get; set; }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                    Console.Write($"{Str}({Left.Data}){Str}");
                }
                else
                {
                    Left.Add(data);
                }
                Str = Str + "   ";
            }
            else
            {
                if(Right == null)
                {
                    Right = node;
                    Console.Write($"{Str}({Right.Data}){Str}");
                }
                else
                {
                    Right.Add(data);
                }
                Str = Str + "   ";
                Console.WriteLine();
            }
        }
    }
}

