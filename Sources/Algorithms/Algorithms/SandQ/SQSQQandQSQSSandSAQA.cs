using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SQSQQandQSQSSandSAQA:IAlgorithm
    {
        Node head;
        bool first = true;
        int top = -1;
        int max = 5;
        int front = 0;
        int rear = -1;

        public class Node
        {
            public int Data;
            public Node Next;

            public Node(int d)
            {
                Data = d;
                Next = null;
            }
        }
        public void Execute()
        {

            //StackusingQueue();
            //QueueusingStack();
            //StackusingtwoQ();
            //QueueusingtwoS();
            //StackusingArray();
            //QueueusingArray();
            //StackusingLL();
           // QueueusingLL();

            Stack<int> s1 = new Stack<int>();
            s1.Push(1);
            s1.Push(2);
            s1.Push(3);
            s1.Push(4);
          Stack<int> dummy=  ReverseStackRecursion(s1);
            foreach(int item in dummy)
            {
                Console.WriteLine(item);
            }
        }

        public void QueueusingLL()
        {
            SQSQQandQSQSSandSAQA list = new SQSQQandQSQSSandSAQA();
            //list.head.Next = new Node(2);
            //list.head.Next.Next = new Node(3);
            //list.head.Next.Next.Next = new Node(4);
            //list.head.Next.Next.Next.Next = new Node(5);

            Enqueue3(6);
            Enqueue3(5);
            Dequeue3();
            Enqueue3(8);
            Enqueue3(9);
            Dequeue3();
            Dequeue3();
            Dequeue3();
            Enqueue3(60);
            Enqueue3(50);
            Dequeue3();
            Enqueue3(65);
            PrintList(head);
        }
        public void Enqueue3(int d)
        {
            Node newnode = new Node(d);
            if (head == null)
            {
                head = newnode;

            }
            else
            {
                newnode.Next = null;
                Node current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newnode;
            }
        }
        public void Dequeue3()
        {
            head = head.Next;

        }
        public void StackusingLL()
        {
            SQSQQandQSQSSandSAQA list = new SQSQQandQSQSSandSAQA();
            //list.head.Next = new Node(2);
            //list.head.Next.Next = new Node(3);
            //list.head.Next.Next.Next = new Node(4);
            //list.head.Next.Next.Next.Next = new Node(5);
            
            Push3(6);
            Push3(5);
            Pop3();
            Push3(8);
            Push3(9);
            PrintList(head);
          }
        public void Push3(int d)
        {
           
            Node newnode = new Node(d);
            if (head == null)
            {
                head = newnode;
               
            }
            else {
                newnode.Next = null;
                Node current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newnode;
            }
            }
        public void Pop3()
        {
            if(head == null)
            {
                return;
            }
            if (head.Next == null)
            {
                head = null;
                return;
            }
            if (head.Next.Next == null)
            {
                head.Next = null;
                return;
            }
            Node current = head;
            while (current.Next.Next != null)
                current = current.Next;

            current.Next = null;
     }
        public void PrintList(Node head)
        {

            Node tnode = head;
            while (tnode != null)
            {
                Console.WriteLine(tnode.Data + "->");
                tnode = tnode.Next;
            }
            //  Console.WriteLine("NULL");

        }
        public void QueueusingArray()
        {
            int[] arr = new int[5];
            Enqueue2(arr, 3);
            Enqueue2(arr, 13);
            Dequeue2(arr);
            Enqueue2(arr, 30);
            Enqueue2(arr, 35);
            Dequeue2(arr);
            Dequeue2(arr);
            Enqueue2(arr, 63);

            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }

        }
        public void Enqueue2(int[] arr, int d)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("Queue Overflow");
                return;
            }
            else
            {
                arr[++rear] = d;
            }
        }
        public void Dequeue2(int[] arr)
        {

            if (front == rear + 1)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {
                arr[front++] = 0;
            }
           
        }
        public void StackusingArray()
        {
            int[] arr = new int[5];
           
            Push2(arr,3);
            Push2(arr, 13);
            Pop2(arr);
            Push2(arr, 30);
            Push2(arr, 35);
            Pop2(arr);
            Pop2(arr);
            Push2(arr, 63);

            foreach(int item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public void Push2(int[] arr,int d)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                arr[++top] = d;
            }
        }
        public void Pop2(int[] arr)
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return ;
            }
            else
            {
                arr[top--]=0;
            }

        }
        public void QueueusingtwoS()
        {
            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();
            Enqueue1(s1,s2,20);
            Enqueue1(s1,s2, 30);
            Dequeue1(s1, s2);
            Enqueue1(s1, s2, 60);
            Dequeue1(s1, s2);
            Enqueue1(s1, s2, 40);
            Dequeue1(s1, s2);
            Enqueue1(s1, s2, 80);
            Enqueue1(s1, s2, 70);
            Dequeue1(s1, s2);
            Dequeue1(s1, s2);
            Dequeue1(s1, s2);
            Enqueue1(s1, s2, 90);
            Dequeue1(s1, s2);
            Enqueue1(s1, s2, 40);

            foreach (int item in s1)
            {
                Console.WriteLine(item);
            }
            foreach (int item in s2)
            {
                Console.WriteLine(item);
            }


        }
        public void Enqueue1(Stack<int> s1, Stack<int>s2,int d)
        {
            bool first = true;
            if(first==true || (s1.Count==0 && s2.Count == 0))
            {
                s1.Push(d);
                first = false;
                return;
            }
            if (s2.Count != 0)
            {
                s2.Push(d);
            }
            if (s1.Count != 0)
            {
                s1.Push(d);
            }


        }
        public void Dequeue1(Stack<int> s1, Stack<int>s2)
        {
            int temp = s1.Count;
            if (s1.Count != 0)
            {
                if (temp == 1)
                {
                    s1.Pop();
                    return;
                }
                while (temp > 1)
                {
                    s2.Push(s1.Pop());
                    temp--;
                }
                s1.Pop();
            }
            else if (s2.Count != 0)
            {
                temp = s2.Count;
                if (temp == 1)
                {
                    s2.Pop();
                    return;
                }
                while (temp > 1)
                {
                    s1.Push(s2.Pop());
                    temp--;
                }
                s2.Pop();

            }
        }
        public void StackusingtwoQ()
        {
            Queue<int> q1 = new Queue<int>();
            Queue<int> q2 = new Queue<int>();
            Push1(q1,q2, 1);
            Push1(q1, q2, 2);
            Pop1(q1, q2);
            Pop1(q1, q2);
            Push1(q1, q2, 1);
            Push1(q1, q2, 2);
            Push1(q1, q2, 2);
            Pop1(q1, q2);




            foreach (int item in q1)
            {
                Console.WriteLine(item);
            }
            foreach (int item in q2)
            {
                Console.WriteLine(item);
            }

        }
        public void Push1(Queue<int> Q1, Queue<int> Q2, int d)
        {
           if (first == true || (Q1.Count == 0 && Q2.Count == 0))
            {
                Q1.Enqueue(d);
                first = false;
                return;
            }
           
                if (Q1.Count != 0)
                {
                    Q1.Enqueue(d);
                }
                if (Q2.Count != 0)
                {
                    Q2.Enqueue(d);
                }

            
          
            
        }
        public void Pop1(Queue<int> Q1, Queue<int> Q2)
        {
            
            int temp = Q1.Count;
            if(Q1.Count != 0) {
                if (temp == 1)
                {
                    Q1.Dequeue();
                    return;
                }
                while (temp > 1)
                {
                    Q2.Enqueue(Q1.Dequeue());
                    temp--;
                }

                Q1.Dequeue();
                return;
            }

            else if(Q2.Count != 0) {
                temp = Q2.Count;
                if (temp == 1)
                {
                    Q2.Dequeue();
                    return;
                }
                while (temp > 1)
                {
                    Q1.Enqueue(Q2.Dequeue());
                    temp--;
                }

                Q2.Dequeue();
                return;
            }

            
        }
        public void QueueusingStack()
        {
            Stack<int> s = new Stack<int>();
            Enqueue(s, 10);
            Enqueue(s, 20);
            Dequeue(s);
            Enqueue(s, 30);
            Dequeue(s);
            Dequeue(s);
            Dequeue(s);
            Enqueue(s, 80);
            Enqueue(s, 70);
            Enqueue(s, 90);
            Dequeue(s);

            foreach (int item in s)
            {
                Console.WriteLine(item);
            }
        }
        public void Enqueue(Stack<int> s, int d)
        {
            s.Push(d);
        }
        public void Dequeue(Stack<int> s)
        {
            if (s.Count < 1)
            {
                Console.WriteLine("Nothing to dequeue");
                return;
            }
            else if (s.Count == 1)
            {
                s.Pop();
            }
            else
            {
                int data = s.Pop();
                Dequeue(s);
                s.Push(data);
            }
        }
        public Stack<int> ReverseStackRecursion(Stack<int> s1)
        {
            if (s1.Count < 1)
            {
                return null;
            }
            else
            {
                int data = s1.Pop();
                ReverseStackRecursion(s1);
                s1.Push(data);
            }
            return s1;
        }
        public void StackusingQueue()
        {
            Queue<int> q = new Queue<int>();
            Push(q,10);
            Push(q,20);
            Pop(q);
            Push(q,30);
            Pop(q);
            Pop(q);
            Pop(q);
            Push(q, 20);


            foreach (int item in q)
            {
                Console.WriteLine(item);
            }

           
        }
        public void Push(Queue<int> q,int d)
        {
            q.Enqueue(d);

        }
        public void Pop(Queue<int> q)
        {
            int temp = q.Count;
            if (q.Count < 1)
            {
                Console.WriteLine("Nothing to pop");
                return;
            }
            while (temp >= 1)
            {
                q.Enqueue(q.Dequeue());
               temp--;
            }
            q.Dequeue();
            return;
        }
    }
}
