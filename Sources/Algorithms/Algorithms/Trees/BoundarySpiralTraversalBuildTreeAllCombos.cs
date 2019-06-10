using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BoundarySpiralTraversalBuildTreeAllCombos : IAlgorithm
    {
        Node root;
        int index = 0;
        int InPostindex = 6;
        int PostPreindex = 0;
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

            Insert(60);
            Insert(40);
            Insert(20);
            Insert(50);
            Insert(80);
            Insert(70);
            Insert(100);
            Insert(75);
            //  InandPost();
            // InandPre();
            // PostandPre();
            //printBoundary(root);
              SpiralTraversal(root);
           
        }

        public virtual void printLeaves(Node node)
        {
            if (node != null)
            {
                printLeaves(node.left);

                // Print it if it is a leaf node  
                if (node.left == null && node.right == null)
                {
                    Console.Write(node.key + " ");
                }
                printLeaves(node.right);
            }
        }

        // A function to print all left boundry  
        // nodes, except a leaf node. Print the 
        // nodes in TOP DOWN manner  
        public virtual void printBoundaryLeft(Node node)
        {
            if (node != null)
            {
                if (node.left != null)
                {

                    // to ensure top down order, print the node  
                    // before calling itself for left subtree  
                    Console.Write(node.key + " ");
                    printBoundaryLeft(node.left);
                }
                else if (node.right != null)
                {
                    Console.Write(node.key + " ");
                    printBoundaryLeft(node.right);
                }

                // do nothing if it is a leaf node,  
                // this way we avoid duplicates in output  
            }
        }

        // A function to print all right boundry  
        // nodes, except a leaf node. Print the 
        // nodes in BOTTOM UP manner  
        public virtual void printBoundaryRight(Node node)
        {
            if (node != null)
            {
                if (node.right != null)
                {
                    // to ensure bottom up order,  
                    // first call for right subtree,  
                    // then print this node  
                    printBoundaryRight(node.right);
                    Console.Write(node.key + " ");
                }
                else if (node.left != null)
                {
                    printBoundaryRight(node.left);
                    Console.Write(node.key + " ");
                }
                // do nothing if it is a leaf node,  
                // this way we avoid duplicates in output  
            }
        }

        // A function to do boundary traversal 
        // of a given binary tree  
        public virtual void printBoundary(Node node)
        {
            if (node != null)
            {
                Console.Write(node.key + " ");

                // Print the left boundary in 
                // top-down manner.  
                printBoundaryLeft(node.left);

                // Print all leaf nodes  
                printLeaves(node.left);
                printLeaves(node.right);

                // Print the right boundary in  
                // bottom-up manner  
                printBoundaryRight(node.right);
            }
        }
        public void SpiralTraversal(Node node)
        {
            if (node == null)
            {
                return; 
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            q.Enqueue(null);

            while (q.Count != 0)
            {
                Node temp = q.Dequeue();
                
                
                if (temp == null)
                {
                    if (q.Count > 0)
                    {
                        q.Enqueue(null);
                    }
                }
               

               else
                {
                    Console.WriteLine(temp.key);
                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);
                    }
                }
            }

            
        }
        public void Insert(int key)
        {
            root = Insertkey(root, key);
        }
        public Node Insertkey(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            else
            {
                if (key < root.key)
                {
                    root.left = Insertkey(root.left, key);
                }
                else if (key > root.key)
                {
                    root.right = Insertkey(root.right, key);
                }

            }
            return root;
        }
        public void InandPost()
        {
            int[] Inorder = { 20, 40, 50, 60, 70, 80, 100 };
            int[] Postorder = { 20,50,40,70,100,80,60};
           Node temp1= InorderandPostorder(Inorder, Postorder, 0, Inorder.Length - 1);
            RInorder(temp1);
        }
        public void InandPre()
        {
            int[] Inorder = { 20, 40, 50, 60, 70, 80, 100 };
            int[] Preorder = { 60, 40, 20, 50, 80, 70, 100 };

            Node temp = InorderandPreorder(Inorder, Preorder, 0, Inorder.Length - 1);
            RInorder(temp);
        }
        public void PostandPre()
        {
            int[] Preorder = { 60, 40, 20, 50, 80, 70, 100 };
            int[] Postorder = { 20, 50, 40, 70, 100, 80, 60 };
            int size = Postorder.Length;
            Node temp = PostorderandPreorder(Postorder, Preorder, 0, Preorder.Length - 1);
            RInorder(temp);
        }
        public Node InorderandPreorder(int[] Inorder, int[] Preorder, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            Node tnode = new Node(Preorder[this.index++]);

            if (start == end)
            {
                return tnode;
            }

            int searchIndex = this.search(Inorder, start, end, tnode);

            tnode.left = InorderandPreorder(Inorder, Preorder, start, searchIndex - 1);
            tnode.right= InorderandPreorder(Inorder, Preorder, searchIndex + 1, end);

            return tnode;
        }

        public Node InorderandPostorder(int[] Inorder, int[] Postorder, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            Node tnode = new Node(Postorder[this.InPostindex--]);

            if (start == end)
            {
                return tnode;
            }

            int searchIndex = this.search(Inorder, start, end, tnode);

            tnode.right = InorderandPostorder(Inorder, Postorder, searchIndex + 1, end);
            tnode.left = InorderandPostorder(Inorder, Postorder, start, searchIndex - 1);
            

            return tnode;
        }

        public Node PostorderandPreorder(int[] Postorder, int[] Preorder, int start, int end)
        {
            int size = Postorder.Length;
            if (start > end || this.PostPreindex>=size)
            {
                return null;
            }

            Node tnode = new Node(Preorder[this.PostPreindex]);
            PostPreindex++;
            if (start == end|| this.PostPreindex >= size)
            {
                return tnode;
            }
            int i;
            for (i = start; i <= end; i++)
            {
                if (Postorder[i] == Preorder[PostPreindex])
                {
                    break;
                }

            }
            if (i <= end)
            {
                tnode.left = PostorderandPreorder(Postorder, Preorder, start, i);
                tnode.right = PostorderandPreorder(Postorder, Preorder, i + 1, end);
            }
            return tnode;

        }
        public int search(int[] Inorder, int start, int end, Node tnode)
        {
                 int i;
                 for (i = start; i < end; i++){
                    if(Inorder[i]== tnode.key)
                    {
                    break;
                    }
               
            }
            return i;
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
    }
}
