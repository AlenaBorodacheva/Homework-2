using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_and_BFS
{
    public class Node<T> : IComparable<T> where T : IComparable
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; set; }
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
    }
}
