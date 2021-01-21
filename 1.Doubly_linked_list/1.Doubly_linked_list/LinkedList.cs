using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Doubly_linked_list
{
    class LinkedList : ILinkedList
    {
        Node firstNode;
        Node endNode;
        int count = 0; 
        public void AddNode(int value)
        {
            var node = firstNode;
            var newNode = new Node { Value = value };
            if (firstNode != null)
            {
                while (node.NextNode != null)
                {
                    node = node.NextNode;
                }                
                node.NextNode = newNode;
                endNode = newNode;
                endNode.PrevNode = node;
            }
            else
            {
                firstNode = newNode;
                endNode = newNode;
            }
            count++; 
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node != null)
            {
                var newNode = new Node { Value = value };
                var nextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextNode;
                newNode.PrevNode = node;
                count++;
            }
        }

        public Node FindNode(int searchValue)
        {
            var searchNode = firstNode;
            while (searchNode.Value != searchValue)
            {
                searchNode = searchNode.NextNode;
                if (searchNode == null)
                {
                    Console.WriteLine("Такого элемента нет в списке.");
                    return null;
                }
            }
            return searchNode;
        }

        public int GetCount()
        {
            return count; 
        }

        public void RemoveNode(int index)
        {
            if (index < 0 || index > count - 1)
                Console.WriteLine("Индекс вышел за пределы списка.");
            else if (count == 0)
                Console.WriteLine("В списке нет элементов.");
            else
            {
                var node = firstNode;
                if (index == 0)
                {
                    node.NextNode.PrevNode = null;
                    firstNode = node.NextNode;
                }
                else if (index == count - 1)
                {
                    endNode.PrevNode.NextNode = null;
                    endNode = endNode.PrevNode;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (i == index)
                        {
                            node.PrevNode.NextNode = node.NextNode;
                            node.NextNode.PrevNode = node.PrevNode;
                            break;
                        }
                        node = node.NextNode;
                    }
                }
                count--;
            }
        }
        public void RemoveNode(Node node)
        {
            var searchNode = firstNode;
            if (count == 0)
            {
                Console.WriteLine("В списке нет элементов.");
            }
            else
            {
                while (searchNode != node)
                {
                    searchNode = searchNode.NextNode;
                    if (searchNode == null)
                    {
                        return;
                    }
                }
                if (searchNode == firstNode)
                {
                    searchNode.NextNode.PrevNode = null;
                    firstNode = searchNode.NextNode;
                }
                else if (searchNode.NextNode == null)
                {
                    searchNode.PrevNode.NextNode = null;
                    endNode = searchNode.PrevNode;
                }
                else 
                {
                    searchNode.PrevNode.NextNode = searchNode.NextNode;
                    searchNode.NextNode.PrevNode = searchNode.PrevNode;
                }
                count--;
            }
        }
    }
}
