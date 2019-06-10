using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class RotateByKthSLLCRUD:IAlgorithm
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
            RotateByKthSLLCRUD list = new RotateByKthSLLCRUD();
           

            list.head = new Node(1);
            list.head.Next = new Node(2);
            list.head.Next.Next = new Node(3);
            list.head.Next.Next.Next = new Node(4);
            list.head.Next.Next.Next.Next = new Node(5);
            list.head.Next.Next.Next.Next.Next = new Node(0);
            list.head.Next.Next.Next.Next.Next.Next = new Node(12);
            list.head.Next.Next.Next.Next.Next.Next.Next = new Node(11);

           // RotateKthnode(list.head,5);
            CRUD(list.head);
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
        public void RotateKthnode(Node head,int k)
        {
            Node current = head;
            Node KthNode;
            if (k == 0)
            return;

            int count = 1;
            while(count<k && current != null)
            {
                current = current.Next;
                count++;
            }

            KthNode = current;


            if (current == null) {
                return;
                    }
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = head;
            head = KthNode.Next;
            KthNode.Next = null;
           
            PrintList(head);
           
        }

        public void CRUD(Node head)
        {

        }
    }
}
