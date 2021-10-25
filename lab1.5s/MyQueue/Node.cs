using System;
using System.Collections.Generic;
using System.Text;

namespace MyQueue
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
