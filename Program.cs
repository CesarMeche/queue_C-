using System;

namespace Structure {
    public class Node<T> {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data) {
            Data = data;
            Next = null;
        }
    }

    public class MyQueue<T> {
        private Node<T> front;
        private Node<T> last;

        public void Push(T data) {
            if (last == null && front == null) {
                last = new Node<T>(data);
                front = last;
            } else {
                Node<T> newData = new Node<T>(data);
                last.Next = newData;
                last = newData;
            }
        }

        public T Poll() {
            if (front == null) return default(T);
            
            T output = front.Data;
            front = front.Next;
            
            if (front == null) {
                last = null;
            }
            
            return output;
        }

        public T Peek() {
            return front != null ? front.Data : default(T);
        }

        public bool IsEmpty() {
            return front == null;
        }
    }

    class Program {
        static void Main(string[] args) {
            MyQueue<int> queue = new MyQueue<int>();
            
            queue.Push(10);
            queue.Push(20);
            queue.Push(30);
            
            Console.WriteLine("Peek: " + queue.Peek()); // Debería imprimir 10
            Console.WriteLine("Poll: " + queue.Poll()); // Debería imprimir 10
            Console.WriteLine("Poll: " + queue.Poll()); // Debería imprimir 20
            Console.WriteLine("Is Empty: " + queue.IsEmpty()); // Debería imprimir False
            Console.WriteLine("Poll: " + queue.Poll()); // Debería imprimir 30
            Console.WriteLine("Is Empty: " + queue.IsEmpty()); // Debería imprimir True
        }
    }
}
