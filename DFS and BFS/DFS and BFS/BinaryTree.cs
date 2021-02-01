using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFS_and_BFS
{
    class BinaryTree<T> where T : IComparable
    {
        public Node<T> Parent { get; set; }
        public int Count { get; set; }
        public Queue<Node<T>> q = new Queue<Node<T>>();
        public Stack<Node<T>> s = new Stack<Node<T>>();
        public void Add(T data)
        {
            if (Parent == null)
            {
                Parent = new Node<T>(data);
            }
            else
            {
                AddTo(Parent, data);
            }
            Count++;
        }
        public void AddTo(Node<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                }
                else
                {
                    AddTo(node.Left, data);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
                }
                else
                {
                    AddTo(node.Right, data);
                }
            }
        }
        public bool Contains(T data)
        {
            Node<T> parent;
            return FindWithParent(data, out parent) != null;
        }
        public Node<T> FindWithParent(T data, out Node<T> parent)
        {
            Node<T> current = Parent;
            parent = null;
            while (current != null)
            {
                int result = current.CompareTo(data);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }
        public bool Remove(T data)
        {
            Node<T> current, parent;

            current = FindWithParent(data, out parent);

            if (current == null)
            {
                return false;
            }
            Count--;
            // Случай 1: Если нет детей справа, левый ребенок встает на место удаляемого.
            if (current.Right == null)
            {
                if (parent == null)
                {
                    Parent = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);

                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // левый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        // Если значение родителя меньше текущего, 
                        // левый ребенок текущего узла становится правым ребенком родителя. 
                        parent.Right = current.Left;
                    }
                }
            }
            // Случай 2: Есть правый ребенок. Если у правого ребенка нет детей слева 
            // то он занимает место удаляемого узла. 
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null)
                {
                    Parent = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // правый ребенок текущего узла становится левым ребенком родителя.
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        // Если значение родителя меньше текущего, 
                        // правый ребенок текущего узла становится правым ребенком родителя. 
                        parent.Right = current.Right;
                    }
                }
            }
            // Случай 3: Если у правого ребенка есть дети слева, крайний левый ребенок 
            // из правого поддерева заменяет удаляемый узел. 
            else
            {
                // Найдем крайний левый узел. 
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;
                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }
                // Левое поддерево родителя становится правым поддеревом крайнего левого узла. 
                leftmostParent.Left = leftmost.Right;
                // Левый и правый ребенок текущего узла становится левым и правым ребенком крайнего левого. 
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;
                if (parent == null)
                {
                    Parent = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Data);
                    if (result > 0)
                    {
                        // Если значение родителя больше текущего,
                        // крайний левый узел становится левым ребенком родителя.
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        // Если значение родителя меньше текущего,
                        // крайний левый узел становится правым ребенком родителя.
                        parent.Right = leftmost;
                    }
                }
            }
            return true;
        }
        public void Clear()
        {
            Parent = null;
            Count = 0;
        }
        public void BFS(Node<T> node)
        {
            Console.WriteLine();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                for (int i = 0; i < q.Count; i++)
                {
                    var qItem = q.Dequeue();

                    if (qItem.Left != null)
                        q.Enqueue(qItem.Left);
                    if (qItem.Right != null)
                        q.Enqueue(qItem.Right);
                    
                    Console.Write(qItem.Data + "  ");
                }
            }
            return;
        }
        public void DFS(Node<T> node)
        {
            Console.WriteLine("\n");
            s.Push(node);
            while (s.Count > 0)
            {
                for (int i = 0; i < s.Count; i++)
                {
                    var sItem = s.Pop();

                    if (sItem.Right != null)
                        s.Push(sItem.Right);
                    if (sItem.Left != null)
                        s.Push(sItem.Left);

                    Console.Write(sItem.Data + "  ");
                }
            }
            return;
        }
    }
}
