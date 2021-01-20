using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Doubly_linked_list
{
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.AddNode(5);
            list.AddNode(7);
            list.AddNodeAfter(list.FindNode(5), 6);
            list.AddNodeAfter(list.FindNode(9), 6);
            Console.WriteLine(list.GetCount());
            list.RemoveNode(0);
            list.RemoveNode(list.FindNode(9));
            Console.WriteLine(list.GetCount());
            Console.ReadLine(); 
        }
    }
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
}
