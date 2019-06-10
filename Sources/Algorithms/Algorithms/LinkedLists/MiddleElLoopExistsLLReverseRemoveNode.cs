using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MiddleElLoopExistsLLReverseRemoveNode : IAlgorithm
    {
        Node head;
        Node head2;
        Node RevNewHead;
        Boolean isloop;
        Node dup;

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
            MiddleElLoopExistsLLReverseRemoveNode list = new MiddleElLoopExistsLLReverseRemoveNode();
            MiddleElLoopExistsLLReverseRemoveNode Rlist = new MiddleElLoopExistsLLReverseRemoveNode();
            list.head = new Node(1);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(4);
            list.head.Next.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next.Next = new Node(6);
            list.head.Next.Next.Next.Next.Next.Next = new Node(7);
            list.head.Next.Next.Next.Next.Next.Next.Next = new Node(8);
            //for (int i = 7; i > 0; i--)
            //{
            //    Node new_node = new Node(i);
            //    new_node.Next = head;
            //    head = new_node;
            //}
            // Console.WriteLine(MiddleElement().Data);
            // MainMethodforLoopExists();
            // PrintList();
           // ReverseLL(list.head,Rlist.head2);
            RemoveNode(list.head,5);

        }
        public void RemoveNode(Node head, int pos)
        {
            Node temp = head;
            if (pos == 0)
            {
                head = head.Next;

            }
            else {
                for (int i = 0; i < pos - 1; i++)
                {
                    temp = temp.Next;
                }
                temp.Next = temp.Next.Next;
            }
           
            PrintList(head);

        }
        public void ReverseLL(Node head1, Node head2)
        {
            Console.WriteLine("Original Linked list ");
            PrintList(head1);

            //Recusrion Reverse LL
            // Node Rll= RecursionReveseLL(list.head);
            // PrintList(Rll);

            //Iterative efficient
            // ReverseList(head1);


            //Iteration Naive
            Stack<Node> st = new Stack<Node>();
            while (head1 != null)
            {
                st.Push(head1);
                head1 = head1.Next;
            }

            head2 = new Node(st.Pop().Data);
            RevNewHead = head2;

            while (st.Count > 0)
            {
                head2.Next = new Node(st.Pop().Data);
                head2 = head2.Next;
            }
            Console.WriteLine("Reversed Linked list ");
            PrintList(RevNewHead);
        }
        public void ReverseList(Node head)
        {
            Node prev = null, current = head, Next = null;
            while (current != null)
            {
                Next = current.Next;
                current.Next = prev;
                prev = current;
                current = Next;
            }
            head = prev;
            PrintList(head);
        }
        public Node RecursionReveseLL(Node head)
        {

            if (head == null || head.Next == null)
            return head;

            Node newHeadNode = RecursionReveseLL(head.Next);

            head.Next.Next = head;
            head.Next = null;
            return newHeadNode;

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
        public Node MiddleElement()
        {
            Node slowptr = head;
            Node fastptr = head;

            if (head == null || head.Next == null)
            {
                //Console.WriteLine(head.Data);
                return head;
            }
            else if (head != null)
            {
                while(fastptr != null && fastptr.Next!= null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next.Next;
                }
               return slowptr;
            }
            return slowptr;
        }
        public void MainMethodforLoopExists()
        {
             head = new Node(1);
            LinkedList<Node> LL = new LinkedList<Node>();

            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);
            Node node8 = new Node(8);


            head.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node2;
            node6.Next = node7;
            node7.Next = node8;
            node8.Next = null;
           
            LoopExists(head);
        }
        public void LoopExists(Node head)
        {

            //another solution using hashap by storing nodes address
            //{ yet to do}

            //normal solution
            Node p1 = head;
            Node p2 = head;
            
            while(p2.Next.Next!= null)
            {
                p1 = p1.Next;
                p2 = p2.Next.Next;
                if (p1 == p2)
                {
                    isloop = true;
                    break;
                }
            }
            Console.WriteLine("Loop Exists " + isloop);
            if(isloop == true)
            {
                p1 = head;

                while (p1 != p2)
                {
                    dup= p2;
                    p1 = p1.Next;
                    p2 = p2.Next;
                  
                }
                Console.WriteLine("result " +p1.Data);

                //Remove Loop
                dup.Next = null;
                PrintList(head);
            }
           
        }
    }
}
