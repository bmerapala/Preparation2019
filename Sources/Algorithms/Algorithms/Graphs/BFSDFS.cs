using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BFSDFS: IAlgorithm
    {
        private int Vertices;
 
        private List<int>[] adj;
        public BFSDFS(int v)
        {
            Vertices = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
            //adj[0]= new List<int>();
            //adj[1] = new List<int>();
            //adj[2] = new List<int>();
            //adj[3] = new List<int>();



        }
        public void Execute()
        {
            AddEdge(0, 1);
            AddEdge(0, 2);
            AddEdge(1, 2);
            AddEdge(2, 0);
            AddEdge(2, 3);
            AddEdge(3, 3);
            PrintAdjacecnyMatrix();
            Console.WriteLine("BFS is");
            BFS(2);
            Console.WriteLine("DFS is");
            DFS(2);
        }

        public void PrintAdjacecnyMatrix()
        {
            for (int i = 0; i < Vertices; i++)
            {
                Console.Write(i + ":[");
                string s = "";
                foreach (var k in adj[i])
                {
                    s = s + (k + ",");
                }
                s = s.Substring(0, s.Length - 1);
                s = s + "]";
                Console.Write(s);
                Console.WriteLine();
            }
        }
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }
        //BFS uses queue as a base.
        public void BFS(int s)
        {
            bool[] visited = new bool[Vertices];

            //create queue for BFS
            Queue<int> queue = new Queue<int>();
            visited[s] = true;
            queue.Enqueue(s);

            //loop through all nodes in queue
            while (queue.Count != 0)
            {
                //Deque a vertex from queue and print it.
                s = queue.Dequeue();
                Console.WriteLine( s);

                //Get all adjacent vertices of s
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }

            }
        }
        public void DFS(int s)
        {
            bool[] visited = new bool[Vertices];

            //For DFS use stack
            Stack<int> stack = new Stack<int>();
            visited[s] = true;
            stack.Push(s);

            while (stack.Count != 0)
            {
                s = stack.Pop();
                Console.WriteLine(s);
                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
