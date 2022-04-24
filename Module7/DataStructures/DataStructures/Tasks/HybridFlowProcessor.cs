using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _linkedList = new DoublyLinkedList<T>();
        public T Dequeue()
        {
            if (_linkedList.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return _linkedList.RemoveAt(0);
            }
        }

        public void Enqueue(T item)
        {
            _linkedList.Add(item);
        }

        public T Pop()
        {
            if (_linkedList.Length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return _linkedList.RemoveAt(0);
            }
        }

        public void Push(T item)
        {
            _linkedList.AddAt(0, item);
        }
    }
}
