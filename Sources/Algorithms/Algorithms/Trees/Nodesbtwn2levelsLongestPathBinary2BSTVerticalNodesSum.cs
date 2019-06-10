using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Nodesbtwn2levelsLongestPathBinary2BSTVerticalNodesSum:IAlgorithm
    {
        public int count = 0;
        int[] arr= new int[7];
        public int index = 0;
        public int index1 = 0;
        Dictionary<int, int> d = new Dictionary<int, int>();
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
            //root.left.left.left = new Node(4);
            //root.left.left.right = new Node(4);
            //root.left.right.left = new Node(4);
            //root.left.right.right = new Node(4);
            //root.right.left.left = new Node(4);
            //root.right.left.right = new Node(4);
            //root.right.right.left = new Node(7);
            //root.right.right.right = new Node(7);


            //Nodesbtwn2levels(root,1,3);
            //DiameterofBT(root);
            //BTtoBST(root);
            //VerticalNodesSum(root,0);
            //foreach(KeyValuePair<int,int> item in d)
            //{
            //    Console.WriteLine(item.Key + " " + item.Value);
            //}


            // Console.WriteLine(Nodesatgivenlevel(root, 1, 3));
            Console.WriteLine(  maxnodeslevel(root));
        }
        public int maxnodeslevel(Node root)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            q.Enqueue(null);
            int level = 1;
            int maxlevel = 0;
            int maxcount = int.MinValue;
            while (q.Count != 0)
            {
                Node temp = q.Dequeue();
                if (temp == null)
                {
                    if (q.Count > 0)
                    {
                       
                        q.Enqueue(null);
                        level++;
                        if(q.Count> maxcount)
                        {
                            maxcount = q.Count;
                            maxlevel = level;
                        }
                    }
                }
                else
                {
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

            return maxlevel;
        }
        public int Nodesatgivenlevel(Node x, int currentLevel, int desiredLevel)
        {
            if (currentLevel == desiredLevel)
                return 1;
            int left = 0;
            int right = 0;
            if (x.left != null)
                left = Nodesatgivenlevel(x.left, currentLevel + 1, desiredLevel);
            if (x.right != null)
                right = Nodesatgivenlevel(x.right, currentLevel + 1, desiredLevel);
            return left + right;
        }
        public void VerticalNodesSum(Node root,int level)
        {
           
            if (root == null)
            return;
            
            VerticalNodesSum(root.left,level+1);

            if (!d.ContainsKey(level)) 
                d[level] = root.key;
            
            else d[level] = d[level] +root.key;
            
            VerticalNodesSum(root.right,level-1);
        }
        public void DiameterofBT(Node root)
        {
            //Ask Santuman
        }   
        public void BTtoBST(Node root)
        {
            arr = Inorder(root);
            Array.Sort(arr);
            Node temp=  TreeInorder(arr, root);
            Console.WriteLine(temp);
}
        public Node TreeInorder(int[] arr,Node root)
        {
            if (root != null)
            {
                TreeInorder(arr,root.left);
                root.key = arr[index1++];
                TreeInorder(arr,root.right);
            }
            return root;
        }
        public int[] Inorder(Node root)
        {
            if (root != null)
            {
                Inorder(root.left);
                arr[index++] = root.key;
                Inorder(root.right);
            }
            return arr;
        }
        public int height(Node node)
        {

            if (node == null)
                return 0;

            return 1 + Math.Max(height(node.left), height(node.right));
        }
        public void Nodesbtwn2levels(Node root,int low, int high)
        {
            Queue<Node> q = new Queue<Node>();
            int level = 1;
            q.Enqueue(root);
            q.Enqueue(null);
            
            if(low<=0 || high<= 0 )
            {
                Console.WriteLine("Levels cannot be less than 1");
                return;
            }

            if(low>height(root) || high>height(root))
            {
                Console.WriteLine("Levels cannot be greater than the height of the tree");
                return;
            }

                while (q.Count>0)
            {
                Node temp = q.Dequeue();

                if (temp == null) {
                    level++;

                    if(q.Count==0 || level > high)
                    break;

                    else q.Enqueue(null);
                }
                else
                {
                    if (level >= low)
                    Console.WriteLine(temp.key + " ");
                    
                    if (temp.left != null)
                    q.Enqueue(temp.left);
                    
                    if (temp.right != null)
                    q.Enqueue(temp.right);
                    
                }
            }
        }
    }
}
