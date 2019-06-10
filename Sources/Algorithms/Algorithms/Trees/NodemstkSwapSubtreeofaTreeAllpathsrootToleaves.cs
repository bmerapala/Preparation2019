using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class NodemstkSwapSubtreeofaTreeAllpathsrootToleaves : IAlgorithm
    {
        int[] arr = new int[5];
        int index = 0;
        int index1 = 0;
        Node prev = null;
        Node cur=null;
        bool flag = false;
        Node A, B;
        public class Node
        {
            public int key;
            public Node right, left;

            public Node(int item)
            {
                key = item;
                right = null;
                left = null;

            }
        }
        public void Execute()
        {
            Node root = new Node(6);
            root.left = new Node(10);
            root.right = new Node(2);
            root.left.left = new Node(1);
            root.left.right = new Node(3);
            root.right.left = new Node(7);
            root.right.right = new Node(12);
            

            Node root1 = new Node(5);
            root1.left = new Node(2);
            root1.right = new Node(20);

            //  NodesSwappedByMstk(root);
            //2nd method
            Console.WriteLine("Inorder before");
            RInorder(root);
            NodesSwappedByMstkPart1(root);
            NodesSwappedByMstkPart2( root, A.key,  B.key);
            Console.WriteLine("Inorder after");
            RInorder(root);


            Console.WriteLine(isSubtree(root, root1));
        }

        public Boolean isSubtree(Node t, Node s)
        {
            String inOrderT = inOrderTraversal(t, false);
            String inOrderS = inOrderTraversal(s, false);
            return inOrderT.Contains(inOrderS);
        }
        private String inOrderTraversal(Node node, Boolean left)
        {
            if (node == null)
            {
                return left ? "l" : "r";
            }

            return ":" + inOrderTraversal(node.left, true) + node.key + inOrderTraversal(node.right, false) + ":";
        }
        public void NodesSwappedByMstk(Node root)
        {
            arr = Inorder(root);
            Array.Sort(arr);
            Node temp = TreeInorder(arr, root);
            Console.WriteLine(temp);


        }

        public void NodesSwappedByMstkPart1(Node root)
        {

            if (root == null) { return; }

            NodesSwappedByMstkPart1(root.left);
            cur = root;
            if (prev != null)
            {
                if (prev.key > cur.key && flag==false)
                {
                     A = prev;
                     flag = true;

                }
                else if(prev.key > cur.key && flag == true)
                {
                     B = cur;
                }
            }
           
            prev = cur;
            NodesSwappedByMstkPart1(root.right);
            
      
        }

        public void NodesSwappedByMstkPart2(Node root, int A, int B)
        {
          
            if (root == null) { return ; }

            NodesSwappedByMstkPart2(root.left, A, B);
            if(root.key == A)
            {
                root.key = B;
            }
            else if (root.key == B)
            {
                root.key = A;
            }
            NodesSwappedByMstkPart2(root.right, A, B);

           
        }

        public void RInorder(Node root)
        {
            if (root != null)
            {
                RInorder(root.left);
                Console.WriteLine(root.key);
                RInorder(root.right);
            }
        }
        public Node TreeInorder(int[] arr, Node root)
        {
            if (root != null)
            {
                TreeInorder(arr, root.left);
                root.key = arr[index1++];
                TreeInorder(arr, root.right);
            }
            return root;
        }
        public int[] Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.left);
                arr[index++]=root.key;
                Inorder(root.right);
            }
            return arr;
        }
    }
}
