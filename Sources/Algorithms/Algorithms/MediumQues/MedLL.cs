using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MedLL : IAlgorithm
    {
        Node head;



        public class Node
        {
            public int Data;
            public Node Next;
            //public Node Random;
            public Node(int d)
            {
                Data = d;
                Next = null;
                //Random = null;

            }
        }

        public void Execute()
        {
            MedLL list = new MedLL();
            MedLL list2 = new MedLL();



            list.head = new Node(0);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(4);
            list.head.Next.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next.Next = new Node(6);
            list.head.Next.Next.Next.Next.Next.Next = new Node(7);
            list.head.Next.Next.Next.Next.Next.Next.Next = new Node(8);
            list.head.Next.Next.Next.Next.Next.Next.Next.Next = new Node(9);
            list.head.Next.Next.Next.Next.Next.Next.Next.Next.Next = new Node(10);


            list2.head = new Node(12);
            list2.head.Next = new Node(13);
            list2.head.Next.Next = new Node(14);
            list2.head.Next.Next.Next = new Node(15);

            //Mergealternatenodes(list.head, list2.head);
            //Splitintotwolinkedlists(list.head);

            //MedLL list = new MedLL();
            //list.push(5);
            //list.push(4);
            //list.push(3);
            //list.push(2);
            //list.push(1);

            // Setting up Random references. 
            //list.head.Random = list.head.Next.Next;
            //list.head.Next.Random =
            //    list.head.Next.Next.Next;
            //list.head.Next.Next.Random =
            //    list.head.Next.Next.Next.Next;
            //list.head.Next.Next.Next.Random =
            //    list.head.Next.Next.Next.Next;
            //list.head.Next.Next.Next.Next.Random =
            //    list.head.Next;

            //print(list.head);
            //Node temp=Clone(list.head);
            //Console.WriteLine(temp.Data);

            // sortedInsert(newnode);

            Node dump = Reversealternatekgroupnodes(list.head, 3);
            PrintList(dump);

            //Reverseknodes(list.head,3) (Geeksforgeeks)

            // sortzeroonetwos(list.head);
            //Node temp10 = reverselist(list.head);
            //PrintList(temp10);

        }

        public Node reverselist(Node node)
        {
            Node prev = null, curr = node, next=null;
            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            node = prev;
            return node;
        }

        public void sortzeroonetwos(Node head)
        {
            int[] count = { 0, 0, 0 };

            Node ptr = head;

            /* count total number of '0', '1' and '2' 
            * count[0] will store total number of '0's 
            * count[1] will store total number of '1's 
            * count[2] will store total number of '2's */
            while (ptr != null)
            {
                count[ptr.Data]++;
                ptr = ptr.Next;
            }

            int i = 0;
            ptr = head;

            /* Let say count[0] = n1, count[1] = n2 and count[2] = n3 
            * now start traversing list from head node, 
            * 1) fill the list with 0, till n1 > 0 
            * 2) fill the list with 1, till n2 > 0 
            * 3) fill the list with 2, till n3 > 0 */
            while (ptr != null)
            {
                if (count[i] == 0)
                   i++;
                else
                {
                    ptr.Data = i;
                    --count[i];
                    ptr = ptr.Next;
                }
            }

        }

        public Node Reversealternatekgroupnodes(Node head, int k)
        {
            Stack<Node> st = new Stack<Node>();
            Queue<Node> Q = new Queue<Node>();
            Node current = head;
            Node prev = null;

            if (head == null || head.Next ==null)
            {
                return head;
            }
            
            while (current != null)
            {
                int count = 0;
               
                while (current != null && count < k)
                {
                    st.Push(current);
                    current = current.Next;
                    count++;

                }
                count = 0;

                while (current != null && count < k)
                {
                    Q.Enqueue(current);
                    current = current.Next;
                    count++;
                }

                //count = 0;
                //while (current != null && count<k)
                //{
                //    current = current.Next;
                //    count++;
                //}
               
                while (st.Count > 0)
                {
                    if (prev == null)
                    {
                        prev = st.Peek();
                        head = prev;
                        st.Pop();
                    }
                    else
                    {
                        prev.Next = st.Peek();
                        prev = prev.Next;
                        st.Pop();
                    }
                }
                while (Q != null && Q.Count > 0)
                {
                    if (prev != null)
                    {
                        prev.Next = Q.Peek();
                        prev = prev.Next;
                        Q.Dequeue();

                    }
                }

            }
            prev.Next = null;
            return head;

        }
        public void insert(Node prev_node, int new_Data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node cannot be null");
                return;
            }

            /* 2. Allocate the Node & 
               3. Put in the Data*/
            Node new_node = new Node(new_Data);

            /* 4. Make Next of new Node as Next of prev_node */
            new_node.Next = prev_node.Next;

            /* 5. make Next of prev_node as new_node */
            prev_node.Next = new_node;

        }

        public void Mergealternatenodes(Node head1, Node head2){

            Node head1cur = head1, head2cur = head2;
            Node head1Next, head2Next ;

            while(head1cur != null && head2cur != null)
            {
                head1Next = head1cur.Next;
                head2Next = head2cur.Next;

                head1cur.Next = head2cur;
                head2cur.Next = head1Next;

                head1cur = head1Next;
                head2cur = head2Next;

            }
         

            PrintList(head1);
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
        public void Splitintotwolinkedlists(Node head)
        {
            Node current = head;
            Node head1 = new Node(current.Data);
            Node head2 = new Node(current.Next.Data);
            current = current.Next.Next;

            while (current != null)
            {
              insert(head1,current.Data);
              insert(head2,current.Next.Data);
               current = current.Next.Next;
            }
            PrintList(head1);
            PrintList(head2);

        }
        public void sortedInsert(Node new_node)
        {
            Node current;

            /* Special case for head node */
            if (head == null || head.Data >= new_node.Data)
            {
                new_node.Next = head;
                head = new_node;
            }
            else
            {

                /* Locate the node before  
                point of insertion. */
                current = head;

                while (current.Next != null &&
                    current.Next.Data < new_node.Data)
                    current = current.Next;

                new_node.Next = current.Next;
                current.Next = new_node;
            }
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
        public void push(int Data)
        {
            Node node = new Node(Data);
            node.Next = this.head;
            this.head = node;
        }

        //public Node Clone(Node head)
        //{
        //    Dictionary<Node, Node> D = new Dictionary<Node, Node>();
        //    Node orghead = head;
        //    Node clonehead =null;

        //    while (orghead != null)
        //    {
        //        clonehead = new Node(orghead.Data);
        //        D[orghead] = clonehead;
        //        orghead = orghead.Next;
        //    }

        //    orghead = head;

        //    while (orghead != null)
        //    {
        //        clonehead = D[orghead];
        //        clonehead.Next = D[orghead.Next];
        //        clonehead.Random = D[orghead.Random];
        //        orghead = orghead.Next;
        //       //clonehead = clonehead.Next;
        //    }
        //    return D[head];

        //    }
        //public void print(Node head)
        //{
        //    Node temp = head;
        //    while (temp != null)
        //    {
        //        Node random = temp.Random;
        //        Node Next = temp.Next;
        //        int randomData = (random != null) ? random.Data : -1;
        //        int NextData = (Next != null) ? Next.Data : -1;
        //        Console.WriteLine("Data = " + temp.Data +
        //                           ", Random Data = " + randomData + " Next Data= " + NextData);
        //        temp = temp.Next;
        //    }
        //}

    }
}
