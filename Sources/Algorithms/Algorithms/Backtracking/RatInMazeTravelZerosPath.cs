using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class RatInMazeTravelZerosPath : IAlgorithm
    {
       
       public int N = 4;
    

       public int[,] a ={ { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
       public int rowCount = 3;
       public int colCount =3;

        public int[,] sol = new int[4, 4];
        int[,] maze = {{1, 0, 0, 0},
                {1, 1, 0, 1},
                {0, 1, 0, 0},
                {1, 1, 1, 1} };

        public char[,] PM = { { 'a', 'a', 'a', 'b' }, { 'b', 'a', 'a', 'a' }, { 'a', 'b', 'b', 'a' } };
        public void Execute()
        {
            //Rat in a maze
           // findSolution();

// Print all paths from top left to bottom right with only down and right moves
           // printAll(0, 0, "");
           

            //Palindromic paths in matrix
            PalindromicPath("", PM, 0, 0, 3, 4);
        }

        public void printAll(int currentRow, int currentColumn, String path)
        {
          
            if (currentRow == rowCount - 1)
            {
                for (int i = currentColumn; i < colCount; i++)
                {
                    path += "-" + a[currentRow,i];
                   
                }
                Console.WriteLine( path);
              //  count++;
                return;
            }
            if (currentColumn == colCount - 1)
            {
                
                for (int i = currentRow; i <= rowCount - 1; i++)
                {
                    path += "-" + a[i,currentColumn];
                    
                  
                }
                Console.WriteLine(path);
                return;
            }
      
            path = path + "-" + a[currentRow,currentColumn];
           
            printAll(currentRow + 1, currentColumn, path);
            printAll(currentRow, currentColumn + 1, path);
           // printAll(currentRow-1, currentColumn, path);
            //printAll(currentRow, currentColumn-1, path);
            printAll(currentRow + 1, currentColumn + 1, path);
            //return count;
           
        }
        public void PalindromicPath(string str, char[,] a,
                                   int currentRow, int currentColumn, int rowCount, int colCount)
        {

            if (currentRow == rowCount - 1 && currentColumn == colCount - 1)
            {
                str = str + a[rowCount - 1,colCount - 1];
                if (isPalin(str))
                {
                    Console.WriteLine(str);
                }
            }

            else {

                 if (currentRow < rowCount - 1)
                {
                    PalindromicPath(str + a[currentRow, currentColumn],
                              a, currentRow + 1, currentColumn, rowCount, colCount);
                }
                if (currentColumn < colCount - 1)
                {
                    PalindromicPath(str + a[currentRow, currentColumn],
                              a, currentRow, currentColumn + 1, rowCount, colCount);
                }


            }
        }

        public static bool isPalin(string str)
        {
            int len = str.Length / 2;
            for (int i = 0; i < len; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }
        public bool findSolution()
        {
            if (solveRatMaze(0, 0) == false)
            {
                Console.WriteLine( "There is no path");
                return false;
            }
            showPath();
            return true;
        }

        public void showPath()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.WriteLine( sol[i,j] + " ");
                Console.WriteLine("  ");
            
            }
        }
        public bool isValidPlace(int x, int y)
        {   
            if (x >= 0 && x < N && y >= 0 && y < N && maze[x,y] == 1)
                return true;
            return false;
        }

        public bool solveRatMaze(int x, int y)
        {
            if (x == N - 1 && y == N - 1)
            {    
                sol[x,y] = 1;
                return true;
            }

            if (isValidPlace(x, y) == true)
            {   
                sol[x,y] = 1;
                if (solveRatMaze(x + 1, y) == true)       //right direction
                    return true;
                if (solveRatMaze(x, y + 1) == true)      // bottom direction
                    return true;
                if (solveRatMaze(x-1, y) == true)        // left direction
                    return true;
                if (solveRatMaze(x , y-1) == true)       // top direction
                    return true;
                sol[x,y] = 0;        
                return false;
            }
            return false;
        }
    }
}
