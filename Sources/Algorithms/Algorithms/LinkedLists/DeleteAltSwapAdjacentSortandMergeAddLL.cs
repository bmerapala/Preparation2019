using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class DeleteAltSwapAdjacentSortandMergeAddLL : IAlgorithm
    {
        Node head;
        bool borrow;

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
            DeleteAltSwapAdjacentSortandMergeAddLL list = new DeleteAltSwapAdjacentSortandMergeAddLL();
            DeleteAltSwapAdjacentSortandMergeAddLL list2 = new DeleteAltSwapAdjacentSortandMergeAddLL();

            list.head = new Node(4);
            list.head.Next = new Node(0);
            list.head.Next.Next = new Node(9);
            list.head.Next.Next.Next = new Node(4);
            //list.head.Next.Next.Next.Next = new Node(2);
            //list.head.Next.Next.Next.Next.Next = new Node(0);
            //list.head.Next.Next.Next.Next.Next.Next = new Node(12);
            //list.head.Next.Next.Next.Next.Next.Next.Next = new Node(11);

            list2.head = new Node(9);
            list2.head.Next = new Node(6);
            list2.head.Next.Next = new Node(7);
            //list2.head.Next.Next.Next = new Node(4);
            //list2.head.Next.Next.Next.Next = new Node(2);
            //list2.head.Next.Next.Next.Next.Next = new Node(8);


            //DeleteAlternate(list.head);
            //SwapAdjacentNodes(list.head);
            // Node temp = MergeSortedLL(list.head, list2.head);
            // PrintList(temp);
            //recursion 
            //Node temp1 = RecursionMergeSortedLL(list.head, list2.head);
            //PrintList(temp1);
            //Node temp2= AddLLs(list.head,list2.head);
            //PrintList(temp2);

            //Node temp3 = MultiplyLLs(list.head, list2.head);
            //Node temp4 = ReverseList(temp3);
            //PrintList(temp4);

            Node temp5 = subtractLinkedList(list.head, list2.head);
            PrintList(temp5);


        }

        public int getLength(Node node)
        {
            int size = 0;
            while (node != null)
            {
                node = node.Next;
                size++;
            }
            return size;
        }

      public  Node paddZeros(Node sNode, int diff)
        {
            if (sNode == null)
                return null;

            Node zHead = new Node(0);
            diff--;
            Node temp = zHead;
            while ((diff--) != 0)
            {
                temp.Next = new Node(0);
                temp = temp.Next;
            }
            temp.Next = sNode;
            return zHead;
        }
      public  Node subtractLinkedListHelper(Node l1, Node l2)
        {
            if (l1 == null && l2 == null && borrow == false)
                return null;

            Node previous = subtractLinkedListHelper((l1 != null) ?
                                    l1.Next : null, (l2 != null) ?
                                    l2.Next : null);

            int d1 = l1.Data;
            int d2 = l2.Data;
            int sub = 0;
            if (borrow)
            {
                d1--;
                borrow = false;
            }
            if (d1 < d2)
            {
                borrow = true;
                d1 = d1 + 10;
            }
            sub = d1 - d2;
            Node current = new Node(sub);
            current.Next = previous;

            return current;
        }
       public Node subtractLinkedList(Node l1, Node l2)
        {
            // Base Case. 
            if (l1 == null && l2 == null)
                return null;
 
            int len1 = getLength(l1);
            int len2 = getLength(l2);

            Node lNode = null, sNode = null;

            if (len1 != len2)
            {
                lNode = len1 > len2 ? l1 : l2;
                sNode = len1 > len2 ? l2 : l1;
                sNode = paddZeros(sNode, Math.Abs(len1 - len2));
            }

            else
            {
               
                while (l1 != null && l2 != null && l1.Data != l2.Data)
                {
                  lNode = l1.Data > l2.Data ? l1 : l2;
                  sNode = l1.Data > l2.Data ? l2 : l1;
                  break;
                 }
            }
            borrow = false;
            return subtractLinkedListHelper(lNode, sNode);
        }
        public Node MultiplyLLs(Node n1, Node n2)
        {
            int total = 0;
            while (n2 != null)
            {
                Node head = n1;
                total *= 10;
                int product = 0;
                while (n1 != null)
                {
                    product *= 10;
                    product += n1.Data * n2.Data;
                    n1 = n1.Next;
                }
                total += product;
                n1= head;
                n2 = n2.Next;
            }
            Node dup = new Node(0);
            Node dup1 = dup;
            while (total > 0 && dup1 != null)
            {
                var digit = total % 10;
                total /= 10;
                dup1.Next = new Node(digit);
                dup1 = dup1.Next;

            }
            return dup.Next;
        }
        public Node ReverseList(Node head)
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
            return head;
           
        }

        public Node AddLLs(Node first,Node second)
        {
            int sum, carry = 0;
            Node res=null, prev = null, temp = null;
                    
            while(first!=null || second != null)
            {
                sum = carry + (first != null ? first.Data : 0) - (second != null? second.Data:0);
                carry = sum >= 10 ? 1 : 0;
                sum = sum % 10;
                temp = new Node(sum);
                if(res== null)
                {
                    res = temp;
                }
                else
                {
                    prev.Next = temp;
                }

                prev = temp;

                if (first != null)
                first = first.Next;
                
                if (second != null)
                second = second.Next;

                if (carry > 0)
                {
                    temp.Next = new Node(carry);
                }


            }
           return res;

        }
        public Node RecursionMergeSortedLL(Node head1, Node head2)
        {
            if (head1 == null)
            {
                return head2;

            }
            if (head2 == null)
            {
                return head1;
            }

            if (head1.Data < head2.Data)
            {
                head1.Next = RecursionMergeSortedLL(head1.Next, head2);
                return head1;
            }
            else 
            {
                head2.Next = RecursionMergeSortedLL(head1,head2.Next);
                return head2;
            }

        }
        public Node MergeSortedLL(Node head1,Node head2)
        {
            if (head1 == null)
            {
                return head2;
            }
            else if (head2 == null)
            {
                return head1;
            }
            else
            {
                if (head1.Data < head2.Data)
                {
                  return  Merge(head1, head2);
                }
                else
                {
                  return  Merge(head2, head1);
                }
            }
          
        }

        public Node Merge(Node head1,Node head2)
        {
                if(head1.Next == null)
            {
                head1.Next = head2;
                return head1;
            }
            else
            {
                Node cur1 = head1, Next1 = head1.Next;
                Node cur2 = head2, Next2 = head2.Next;
                //cur1->cur2->Next1
                while(cur1.Next!=null && cur2.Next != null) {
                    if (cur2.Data > cur1.Data && cur2.Data < Next1.Data)
                    {
                        Next2 = cur2.Next;
                        cur1.Next = cur2;
                        cur2.Next = Next1;

                        cur1 = cur2;
                        cur2 = Next2;
                    }
                    else
                    {
                        // if more nodes in first list 
                        if (Next1.Next != null)
                        {
                            Next1 = Next1.Next;
                            cur1 = cur1.Next;
                        }

                        // else point the last node of first list 
                        // to the remaining nodes of second list 
                        else
                        {
                            Next1.Next = cur2;
                            return head1;
                        }
                    }


                }
                return head1;
               
            }


        }
        public void SwapAdjacentNodes(Node head)
        {
            Node h1 = head;
            Node temp = head;

            /* Traverse only till there are atleast 2 nodes left */
            while (temp != null && temp.Next != null)
            {

              
                int k = temp.Data;
                temp.Data = temp.Next.Data;
                temp.Next.Data = k;
                temp = temp.Next.Next;
            }
            PrintList(h1);
        }
        public void DeleteAlternate(Node head)
        {
            if (head == null)
                return;
            Node temp = head;
            Node prev = head;
            Node now = head.Next;

            while (prev != null && now != null)
            {
                /* Change Next link of previus node */
                prev.Next = now.Next;

                /* Free node */
                now = null;

                /*Update prev and now */
                prev = prev.Next;
                if (prev != null)
                    now = prev.Next;
            }
            PrintList(temp);
        }
        public void PrintList(Node head)
        {

            Node tnode = head;
           
            while (tnode != null)
            {
                
                Console.WriteLine(tnode.Data + "->");
                tnode = tnode.Next;
            }
            Console.WriteLine("NULL");

        }
        
          

        
    }
}
