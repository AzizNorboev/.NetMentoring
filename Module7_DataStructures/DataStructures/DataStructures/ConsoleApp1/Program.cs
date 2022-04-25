using System;
using Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> node = new(1);
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.AddAt(0, 0);
            list.AddAt(2, 3);
            list.AddAt(7, 8);
            list.RemoveAt(4);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
