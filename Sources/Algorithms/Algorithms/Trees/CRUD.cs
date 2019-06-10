using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class CRUD : IAlgorithm
    {

        Node root;
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

        public CRUD()
        {
            root = null;
        }

        public void Execute()
        {
            CRUD tree = new CRUD();

            Insert(60);
            Insert(40);
            Insert(20);
            Insert(50);
            Insert(80);
            Insert(70);
            Insert(100);
       
            //inorderRec(root);

            //Delete(40);
            // inorderRec(root);
           // Console.WriteLine(Contains(root,50));
        }
        public void Delete(int key)
        {
            root = deleteRec(root, key);
 
        }
        public Node deleteRec(Node root, int key)
        {
            if (key < root.key)
                root.left = deleteRec(root.left, key);
            else if (key > root.key)
                root.right = deleteRec(root.right, key);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.key = minValue(root.right);
                root.right = deleteRec(root.right, root.key);
            }
            return root;
        }
        public int minValue(Node root)
        {
            int minv = root.key;
            while (root.left != null)
            {
                minv = root.left.key;
                root = root.left;
            }
            return minv;
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
        public void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.WriteLine(root.key);
                inorderRec(root.right);
            }
        }
        public Boolean Contains(Node root,int key)
        {
            while (root!=null)
            {
                if (key == root.key)
                {
                    return true;
                }
                if (key < root.key)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }
            }
            return false;
        }
       
    }
}
