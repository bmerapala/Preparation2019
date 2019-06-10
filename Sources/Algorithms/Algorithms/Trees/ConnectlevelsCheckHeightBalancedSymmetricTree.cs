using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class ConnectlevelsCheckHeightBalancedSymmetricTree :IAlgorithm
    {
        Node root;

        public class Node
        {
            public int key;
            public Node right, left, nextRight;

            public Node(int item)
            {
                key = item;
                right = null;
                left = null;
                nextRight = null;
            }


        }

        public void Execute()
        {
            Insert(15);
            Insert(13);
            Insert(13);
            Insert(12);
            Insert(14);
            Insert(14);
            Insert(12);
           // Insert(17);

            // ConnectLevels(root);
            // Console.WriteLine("nextRight of " + root.left.right.key + " is " +
            //((root.left.right.nextRight != null) ? root.left.right.nextRight.key : -1));
            // isBalanced(root);
            Console.WriteLine(SymmetricTree(root));
        }

        public bool isBalanced(Node node)
        {
            if (node == null)
            return true;

           int lh = height(node.left);
           int rh = height(node.right);

            if (Math.Abs(lh - rh) <= 1 && isBalanced(node.left) && isBalanced(node.right))
            return true;

            return false;
        }
        public int height(Node node)
        {
            
            if (node == null)
            return 0;
            
            return 1 + Math.Max(height(node.left), height(node.right));
        }
        public Boolean SymmetricTree(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root.left);
            q.Enqueue(root.right);

            while (q.Count != 0)
            {
                Node templeft = q.Dequeue();
                Node tempright = q.Dequeue();

                if(templeft==null || tempright == null)
                {
                    continue;
                }
                else if(templeft ==null && tempright!=null || tempright == null && templeft != null)
                {
                    return false;
                }
                else if (templeft.key != tempright.key)
                {
                    return false;
                }

                q.Enqueue(templeft.left);
                q.Enqueue(tempright.right);
                q.Enqueue(templeft.right);
                q.Enqueue(tempright.left);

            }
            return true;
        }
        public void ConnectLevels(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
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
                    temp.nextRight = q.Peek();

                    if (temp.left!=null)
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
            root = InsertData(root, key);
        }
        public Node InsertData(Node root, int key)
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
                    root.left = InsertData(root.left, key);
                }
                else if (key > root.key)
                {
                    root.right = InsertData(root.right, key);
                }

            }
            return root;
        }
    }
}