using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class DuplicatesLengthPalindromeKthnode : IAlgorithm
    {
        Node head;

        public class Node
        {
           public int Data;
           public Node Next;
           public Node(int d)
            {
                Data = d;
            }
        }

        public void Execute()
        {
            DuplicatesLengthPalindromeKthnode list = new DuplicatesLengthPalindromeKthnode();
            DuplicatesLengthPalindromeKthnode list2 = new DuplicatesLengthPalindromeKthnode();
            list.head = new Node(3);
            list.head.Next = new Node(6);
            list.head.Next.Next = new Node(15);
            list.head.Next.Next.Next = new Node(15);
            list.head.Next.Next.Next.Next = new Node(30);
            //list.head.Next.Next.Next.Next.Next = new Node(0);
            //list.head.Next.Next.Next.Next.Next.Next = new Node(12);
            //list.head.Next.Next.Next.Next.Next.Next.Next = new Node(11);

            list2.head = new Node(10);
            list2.head.Next = new Node(15);
            list2.head.Next.Next = new Node(30);
            //list2.head.Next.Next.Next = new Node(5);
            //list2.head.Next.Next.Next.Next = new Node(4);
            //list2.head.Next.Next.Next.Next.Next = new Node(3);
            //list2.head.Next.Next.Next.Next.Next.Next = new Node(2);
            //list2.head.Next.Next.Next.Next.Next.Next.Next = new Node(0);

            //RemoveDuplicates(list.head);
            //Console.WriteLine(LengthofLL(list.head));
            //Console.WriteLine(Palindrome(list.head));
            // kthnodefromend(list.head,7);
          //  IntersectionLL(list.head, list2.head);
            IntersectionTypetwoLL(list.head, list2.head);
        }


        public void IntersectionTypetwoLL(Node head1,Node head2)
        {
            int d1 = LengthofLL(head1);
            int d2 = LengthofLL(head2);

            if (d1 > d2)
            {
                 GetIntersectionNode(d1 - d2, head1, head2);
            }
            else
            {
               GetIntersectionNode(d2 - d1, head2, head1);
            }
        }
        public void GetIntersectionNode(int d,Node node1,Node node2)
        {
            int count = 0;
            Node current1 = node1;
            Node current2 = node2;
            while (count < d)
            {
                current1 = current1.Next;
                count++;
            }

            while(current1!=null && current2 != null)
            {
                if(current1.Data == current2.Data)
                {
                    Console.WriteLine("Intersection Node" +current1.Data);
                    return;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }

            

        }
        public void IntersectionLL(Node head1, Node head2)
        {
            HashSet<int> hs = new HashSet<int>();
            while (head1 != null)
            {
                if (!hs.Contains(head1.Data))
                {
                  hs.Add(head1.Data);
                }
                head1 = head1.Next;
            }
            while (head2 != null)
            {
                if (hs.Contains(head2.Data))
                {
                    Console.WriteLine(head2.Data);
                }
                head2 = head2.Next;
                //Union 
                //    if (!hs.Contains(head2.Data))
                //    {
                //        hs.Add(head2.Data);
                //    }
                //    head2 = head2.Next;

                //}

                //foreach(int item in hs)
                //{
                //    Console.WriteLine(item);
                //}
            }

        }
        public bool Palindrome(Node head)
        {
            Stack<Node> st = new Stack<Node>();
            Node dup = head;
            while (dup != null)
            {
                st.Push(dup);
                dup = dup.Next;
            }
            int temp = st.Pop().Data;
            while (head.Next != null)
            {
               if (head.Data == temp)
                {
                    head = head.Next;
                    temp = st.Pop().Data;

                }
                else
                {
                    return false;
                }
            }
            return true;

            }
        public int LengthofLL(Node head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.Next;
            }
            return count;
        }
        public void RemoveDuplicates(Node head)
        {
            //Naive approach
          Node ptr1 = head;
          Node ptr2;
            while (ptr1 != null)
            {
                ptr2 = ptr1;
                while (ptr2.Next != null)
                {
                    if (ptr1.Data == ptr2.Next.Data)
                    {
                        ptr2.Next = ptr2.Next.Next;
                       
                    }
                    else
                    {
                        ptr2 = ptr2.Next;
                    }
                }
                ptr1 = ptr1.Next;
            }

            //efficient approach
            //HashSet<int> hs = new HashSet<int>();
            //Node current = head;
            //Node prev = null;
            //while(current != null)
            //{
            //    if (!hs.Contains(current.Data)) {
            //        hs.Add(current.Data);
            //        prev = current;
            //    }
            //    else
            //    {
            //        prev.Next = current.Next;
            //    }

            //    current = current.Next;
            //}
            
             PrintList(head);
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

        public void kthnodefromend(Node head,int n)
        {

            //1st method
             printNthFromLast(head, n);
        //2nd method
            //int len = LengthofLL(head);

            //int count = 0;
            //Node temp = head;
            //if (len < n)
            //    return;
            //while (count < len - n)
            //{
            //    temp = temp.Next;
            //    count++;
            //}
            //Console.WriteLine("Kth Node "+temp.Data);

        }

        public void printNthFromLast(Node head,int n)
        {
            Node main_ptr = head;
            Node ref_ptr = head;

            int count = 0;
            if (head != null)
            {
                while (count < n)
                {
                    if (ref_ptr == null)
                    {
                        Console.WriteLine(n + " is greater than the no " +
                                          " of nodes in the list");
                        return;
                    }
                    ref_ptr = ref_ptr.Next;
                    count++;
                }
                while (ref_ptr != null)
                {
                    main_ptr = main_ptr.Next;
                    ref_ptr = ref_ptr.Next;
                }
                Console.WriteLine( n + "th node from last is " +
                                   main_ptr.Data);
            }
        }


    }
}
