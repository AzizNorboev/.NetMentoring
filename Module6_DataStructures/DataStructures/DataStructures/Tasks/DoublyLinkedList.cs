using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public int Length { get; set; }

        Node<T> head;
        Node<T> tail;

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);
            if (tail == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
            }

            tail = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            Node<T> newNode = new Node<T>(e);

            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            //add new head data
            else if (index == 0)
            {
                newNode.Next = head;

                if (head == null)
                {
                    tail = newNode;
                }
                else
                {
                    head.Previous = newNode;
                }
                head = newNode;
                Length++;
            }
            // add new tail data
            else if (index == Length)
            {
                Add(newNode.Data);
            }
            //if index is between 0 and last index
            else
            {
                GetIndexAndSaveData(index, newNode);
                Length++;
            }        

        }

        public void GetIndexAndSaveData(int index, Node<T> newNode)
        {
            int currentIndex = 0;
            var currentNode = head;
            if (index >= 0)
            {
                while (currentNode != null && currentIndex <= index)
                {
                    if (currentIndex == index)
                    {
                        newNode.Next = currentNode;
                        newNode.Previous = currentNode.Previous;
                        currentNode.Previous.Next = newNode;
                        currentNode.Previous = newNode;
                    }
                    currentIndex++;
                    currentNode = currentNode.Next;
                }
            }
        }

        public T ElementAt(int index)
        {
            Node<T> node = head;
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException("index");
            }
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Data;
        }



        public void Remove(T item)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.ToString() == item.ToString())
                {
                    if (current.Next == null)
                    {
                        tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    if (current.Previous == null)
                    {
                        head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    Length--;
                    break;
                }

                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            Node<T> removedNode = null;

            if (index < 0 || index > Length - 1 || Length == 0)
            {
                throw new IndexOutOfRangeException();
            }
            //removing head
            else if (index == 0)
            {
                removedNode = head;
                head = removedNode.Next;
                head.Previous = null;
            }
            //removing tail
            else if (index == Length - 1)
            {
                removedNode = tail;
                tail = removedNode.Previous;
                tail.Next = null;
            }
            //if index is between 0 and last index
            else
            {
                int currentIndex = 0;
                var currentNode = head;
                if (index >= 0)
                {
                    while (currentNode != null && currentIndex <= index)
                    {               
                        if (currentIndex == index)
                        {
                            currentNode.Next.Previous = currentNode.Previous;
                        }
                        currentIndex--;
                    }
                }
            }
            Length--;
            return removedNode.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            List<T> list = new List<T>();

            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }

            return list.GetEnumerator();
        }
    }
}
