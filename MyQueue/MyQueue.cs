using System;
using System.Collections;
using System.Collections.Generic;

namespace MyQueue
{
    public class MyQueue<T>: IEnumerable <T>
    {
        public delegate void Delegate(string mes);
        public event Delegate Updated;
        private Node<T> _head { get; set; }

        private Node<T> _tail { get; set; }

        // додавання до черги
        public void Enqueue(T value)
        {
            if (value == null)
                throw new Exception("Некоректний ввод");

            Node<T> newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            Updated?.Invoke($"Додавання нового елементу до черги: {newNode.Value}");

        }
        //видалення з черги
        public void Dequeue()
        {
            if (_head == null)
                throw new Exception("Видалення єлементу з пустої черги");

            _head = _head.Next;
            if (_head != null)
                Updated?.Invoke($"Перший елеменет вишов з черги, тепер перший: {_head.Value}");
            else
                Updated?.Invoke("Видалення останього елементу, черга пуста");
        }

        //Видалення черги
        public void Clear()
        {
            _head = null;
            _tail = null;
            Updated?.Invoke("Очищення черги, черга пуста");
        }

        //повернення значення 1 элементу черги
        public T Peek()
        {
            if (_head == null)
                throw new InvalidOperationException("Перший елемент вiдсутнiй, черга пуста");

            return _head.Value;      
        }
        public (bool check, int count) Contains(T value)
        {
            if (_head == null) throw new NullReferenceException();
            Node<T> current = _head;
            int count = 0;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return (true,count);
                count++;
                current = current.Next;
            }
            return (false, count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
