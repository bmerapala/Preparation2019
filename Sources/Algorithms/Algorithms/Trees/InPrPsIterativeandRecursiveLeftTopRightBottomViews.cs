using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class InPrPsIterativeandRecursiveLeftTopRightBottomViews:IAlgorithm
    {
        Node root;
        public int currentLevel = 0;
        public class Node
        {
            public int key;
            public Node right, left, parent;
            
            public Node(int item)
            {
                key = item;
                right = null;
                left = null;
                parent = null;
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
            // IInorder();
            // IPreorder();
            // IPostorder();
            //RInorder(root);
            // RPreorder(root);
            // RPostorder(root);
            //TopView();
            // BottomView(root);
            IBottomView();
           // LeftView();
           //RightView();
           //int Nextlevel = 1;
           //RLeftRightView(root,Nextlevel);

        }

        public void LeftView()
        {
            Queue<Node> q = new Queue<Node>();
            if (root != null)
            {

                q.Enqueue(root);
                Console.WriteLine(root.key);
                q.Enqueue(null);

            }
            while (q.Count != 0)
            {
                Node temp = q.Dequeue();
                if (temp == null)
                {
                    if (q.Count > 0) { 
                    Console.WriteLine(q.Peek().key);
                    q.Enqueue(null);
                    }
                }
                else {
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
        public void RLeftRightView(Node root, int nextLevel)
        {
            if (root == null) return;
            if (this.currentLevel < nextLevel)
            {
                Console.WriteLine( "  " + root.key);
                currentLevel = nextLevel;
            }
            RLeftRightView(root.left, nextLevel + 1);
            RLeftRightView(root.right, nextLevel + 1);
            //Recursive right
            //RLeftRightView(root.right, nextLevel + 1);
            //RLeftRightView(root.left, nextLevel + 1);
        }
    
        public void RightView()
        {
            Queue<Node> q = new Queue<Node>();
            if (root != null)
            {
                q.Enqueue(root);
                q.Enqueue(null);

            }
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
                    if (q.Peek() == null)
                    {
                        Console.WriteLine(temp.key);
                    }
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

        public void TopView()
        {
            Node temp = root.left;
            Stack<Node> stack = new Stack<Node>();

            while (temp != null)
            {
                stack.Push(temp);
                temp = temp.left;
            }
            while (stack.Count!=0)
                Console.WriteLine("top" + stack.Pop().key);

            Console.WriteLine("top"+root.key);
            temp = root.right;
            while (temp != null)
            {
                Console.WriteLine("top"+temp.key);
                temp = temp.right;
            }
        }
        public void BottomView(Node root)
        {
            if (root != null)
            {
                BottomView(root.left);
                BottomView(root.right);
              

                if (root.left == null && root.right == null)
                {
                    Console.WriteLine(root.key);
                }
            }
        }
        public void IBottomView()
        {
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();
            s1.Push(root);
            while (s1.Count != 0)
            {
                Node curr = s1.Peek();
                s1.Pop();
                if (curr.left!=null) {
                    s1.Push(curr.left);
                }
               
                if (curr.right!= null)
                {
                    s1.Push(curr.right);
                }
                else if (curr.left==null && curr.right==null)
                    s2.Push(curr);
            }
            while (s2.Count!=0)
            {
                Console.WriteLine(s2.Pop().key);
                
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

        public void RInorder(Node root)
        {
            if (root != null)
            {
                RInorder(root.left);
                Console.WriteLine(root.key);
                RInorder(root.right);
            }
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
        public void RPostorder(Node root)
        {
            if (root != null)
            {
                RPostorder(root.left);
                RPostorder(root.right);
                Console.WriteLine(root.key);
            }
        }
        public void IInorder()
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp;
            while (stack.Count!=0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    temp = stack.Pop();
                    Console.WriteLine(temp.key + " ");
                    root = temp.right;
                }
            }

        }
        public void IPreorder()
        {
            Stack<Node> stack = new Stack<Node>();
            Node temp;
            while (stack.Count != 0 || root != null)
            {
                if (root != null)
                {
                    Console.WriteLine(root.key + " ");
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    temp = stack.Pop();
                    root = temp.right;
                }
            }
        }
        public void IPostorder()
        {
            Stack<Node> s1 = new Stack<Node>();
            Stack<Node> s2 = new Stack<Node>();
            s1.Push(root);
            while (s1.Count != 0)
            {
                Node temp = s1.Pop();
                s2.Push(temp);
                if (temp.left != null)
                {
                    s1.Push(temp.left);
                }
                if (temp.right != null)
                {
                    s1.Push(temp.right);
                }
            }

            while (s2.Count != 0)
            {
             Console.WriteLine(s2.Pop().key);
                
            }
        }

       

    }
}
