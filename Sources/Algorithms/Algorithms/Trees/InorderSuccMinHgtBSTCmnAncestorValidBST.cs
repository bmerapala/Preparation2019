using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class InorderSuccMinHgtBSTCmnAncestorValidBST : IAlgorithm
    {
        Node root;
        Node prev;
        public class Node
        {
            public int key;
            public Node right,left,parent;
            public Node(int item)
            {
                key = item;
                right = null;
                left = null;
                parent = null;
            }
        }

        public InorderSuccMinHgtBSTCmnAncestorValidBST()
        {
            root = null;
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
            // Node temp = root.left.right;
            // Console.WriteLine(InorderSuccessor(temp).key);
            // Console.WriteLine(InorderPredessor(temp).key);
            //inorderRec(root);
            //Node temp1 = root.right.left;
            //Node temp2 = root.right.right;
            //Console.WriteLine(CommonAncestor(temp1,temp2,root).key);
            //Console.WriteLine(CommonAncestor1(temp1, temp2, root).key);

            MinHeightBSTfromArray();
            MinHeightBSTfromLL();

            InorderSuccMinHgtBSTCmnAncestorValidBST tree = new InorderSuccMinHgtBSTCmnAncestorValidBST();
            tree.root = new Node(4);
            tree.root.left = new Node(2);
            tree.root.right = new Node(5);
           // tree.root.left.left = new Node(1);
            tree.root.left.right = new Node(3);
            tree.root.left.right.left = new Node(3);

            if (isBST(tree.root))
                Console.WriteLine("IS BST");
            else
                Console.WriteLine("Not a BST");
        }

        public void MinHeightBSTfromArray()
        {

        }
        public void MinHeightBSTfromLL()
        {

        }
       public Boolean isBST()
        {
            prev = null;
            return isBST(root);
        }
        public Boolean isBST(Node root)
        {
            if (root == null) return true;
            if (!isBST(root.left)) return false;
            if (prev != null && root.key <= prev.key) return false;
            prev = root;
            if (!isBST(root.right)) return false;
            return true;
        }
        public Node CommonAncestor(Node n1, Node n2, Node root)
        {
            if (root == null)
            {
                return root ;
            }
            else
            {
                if(n1.key<root.key && n2.key < root.key)
                {
                    return CommonAncestor(n1, n2, root.left);
                }
                if (n1.key > root.key && n2.key > root.key)
                {
                    return  CommonAncestor(n1, n2, root.right);
                }
            }
            return root;
        }
        public Node CommonAncestor1(Node n1, Node n2, Node root)
        {
            if (root == null)
            {
                return root;
            }
            else
            {
                while (root != null)
                {
                    if (n1.key < root.key && n2.key < root.key)
                    {
                        root = root.left;
                    }
                    else if (n1.key >= root.key && n2.key >= root.key)
                    {
                        root = root.right;
                    }
                    else
                    {
                        return root;
                    }
                }
            }
            return root;
           
        }
        public Node InorderSuccessor(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (node.right != null)
            {
                return minValue(node.right);
            }
            else
            {
                Node p = node.parent;
                while(p!=null && p.left != node)
                {
                    node = p;
                    p = p.parent;
                }
                return p;
            }
        }
        public Node InorderPredessor(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (node.left != null)
            {
                return maxValue(node.left);
            }
            else
            {
                Node p = node.parent;
                while (p != null && p.right != node)
                {
                    node = p;
                    p = p.parent;
                }
                return p;
            }
        }
        public Node minValue(Node node)
        {
            Node current = node;
            while (current.left != null)
            {
                current = current.left;
            }
            return current;
        }
        public Node maxValue(Node node)
        {
            Node current = node;
            while (current.right != null)
            {
                current = current.right;
            }
            return current;
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
                   Node temp = InsertData(root.left, key);
                    root.left = temp;
                    temp.parent = root;
                }
                else if (key > root.key)
                {
                    Node temp = InsertData(root.right, key);
                    root.right = temp;
                    temp.parent = root;
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
    }
}
