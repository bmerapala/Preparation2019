using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class InvertTreePathsumMaxMinDepthTreeFlattenBTtoLL:IAlgorithm
    {

        
        Node maxleaf = null;
        int maxsum = int.MinValue;
        Node prev = null;
        public Node head;
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
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);

            //InvertTree(root);
            //RPreorder(root);

            //string path = "";
            //PathSum(root, 10, path);

            //int cursum = 0;
            //Node maxleaf = MaxPathsum(root, cursum);
            //string path = "";
            //PrintPath(root, maxleaf, path);

            //Console.WriteLine(minimumDepth(root, 0));

            //Node temp= FlattenBTtoLL(root);

            //BT2DLL(root);
            //Console.WriteLine(root);

            //sumTree(root);
            //RInorder(root);
//print all paths from root to leaves
            int[] path = new int[1000];
            printPathsRecur(root, path, 0);
        }

        public virtual void printPathsRecur(Node node, int[] path, int pathLen)
        {
            if (node == null)
            {
                return;
            }

            /* append this node to the path array */
            path[pathLen] = node.key;
            pathLen++;

            /* it's a leaf, so print the path that led to here  */
            if (node.left == null && node.right == null)
            {
                printArray(path, pathLen);
            }
            else
            {
                /* otherwise try both subtrees */
                printPathsRecur(node.left, path, pathLen);
                printPathsRecur(node.right, path, pathLen);
            }
        }

        /* Utility function that prints out an array on a line. */
        public virtual void printArray(int[] ints, int len)
        {
            int i;
            for (i = 0; i < len; i++)
            {
                Console.Write(ints[i] + " ");
            }
            Console.WriteLine("");
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
        public int sumTree(Node root)
        {
            if (root == null){
                return 0;
            }
          
                int old_val = root.key;
                root.key = sumTree(root.left) +sumTree(root.right);
                return root.key + old_val;
            }

        public void BT2DLL(Node root)
        {
            Node p = root;
            if (p == null)
            {
                return;
            }

            // Recursively convert left subtree  
            BT2DLL(p.left);

            // Now convert this node  
            if (prev == null)
            {
                head = p;
            }
            else
            {
                p.left = prev;
                prev.right = p;
            }
            prev = p;

            // Finally convert right subtree  
            BT2DLL(p.right);
            
        }
        public Node FlattenBTtoLL(Node root)
        {
            Node p = root;
            Stack<Node> stack = new Stack<Node>();
          
            while (p.right != null || stack.Count!=0)
            {
                if (p.right != null)
                {
                    stack.Push(p.right);
                }
                if (p.left != null)
                {
                    p.right = p.left;
                    p.left = null;
                }
                else if (stack.Count != 0)
                {
                    Node temp = stack.Pop();
                    p.right = temp;
                }
                p = p.right;
            }
            return root;
        }
        public int minimumDepth(Node root, int level)
        {

            if (root == null)
                return level;
            level++;

            return Math.Min(minimumDepth(root.left, level),
                    minimumDepth(root.right, level));
        }
        public void PathSum(Node root,int sum,string path)
        {
            

            if (root == null) return;
            else
            {
                if (root.key > sum)
                    return;
                else {
                    path += " " + root.key;
                    sum = sum - root.key;
                    if(sum==0)
                        Console.WriteLine(path);
                PathSum(root.left, sum, path);
                PathSum(root.right, sum, path);
                }
            }
        }
        public Node MaxPathsum(Node root, int sum)
        {
            if (root == null) return null;
            else
            {

                sum += root.key;
                if (sum > maxsum && root.left == null && root.right == null)
                {
                    maxsum = sum;
                    maxleaf = root;
                }
                    
                MaxPathsum(root.left, sum);
                MaxPathsum(root.right, sum);
                return maxleaf; 
            }
        }
        public Boolean PrintPath(Node root, Node dest,string path)
        {
            if (root == null) return false;
            if (root == dest || PrintPath(root.left, dest, path) || PrintPath(root.right, dest, path))
            {
                path += root.key;
                Console.WriteLine(path);
                return true;
            }
            return false;
        }
        public void InvertTree(Node root)
        {
            if (root == null) return;

            swap(root);

            InvertTree(root.left);
            InvertTree(root.right);
        }
        public void swap(Node root)
        {
            if (root == null) return;
            Node temp = root.left;
            root.left = root.right;
            root.right = temp;
        }
        public void RPreorder(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.key);
                RPreorder(root.left);
                RPreorder(root.right);
            }
        }
    }
}
