using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SpiralDiagonalUDMatrix :IAlgorithm
    {
        int[,] matrix;
        int R, C, r, c,evenrow, oddrow;
        public SpiralDiagonalUDMatrix(int[,] input)
        {
            matrix = input;
            R = matrix.GetLength(0);
            C = matrix.GetLength(1);
            r = 0;
            c = 0;
            evenrow = 0;
            oddrow = 1;
        }

        public void Execute()
        {

            //  Generate a square matrix filled with elements from 1 to n square in spiral order
            int[,] matrix = GenerateMatrix(4);


            printMatrix(matrix);

            Console.WriteLine("Above is the generated matrix");
            //  spiral Mtarix
            //while (r < R && c < C)
            //{
            //    for (int i = c; i < C; i++)
            //    {
            //        Console.WriteLine(matrix[r, i]);
            //    }
            //    r++;

            //    for (int i = r; i < R; i++)
            //    {
            //        Console.WriteLine(matrix[i, C - 1]);
            //    }
            //    C--;
            //    if (r < R)
            //    {
            //        for (int i = C - 1; i >= c; i--)
            //        {
            //            Console.WriteLine(matrix[R - 1, i]);
            //        }
            //        R--;
            //    }
            //    if (c < C)
            //    {
            //        for (int i = R - 1; i >= r; i--)
            //        {
            //            Console.WriteLine(matrix[i, c]);
            //        }
            //        c++;
            //    }
            //}

            //Diagonal Matrix(Downwards)

            //for (int k = 0; k < C; k++)
            //{

            //    int i = 0;  // set row index for next 
            //                // point in diagonal 
            //    int j = k;    // set column index for  
            //                  // next point in diagonal 

            //    /* Print Diagonally upward */
            //    while (isValid(i, j))
            //    {
            //        Console.Write(matrix[i, j] + " ");

            //        i++;
            //        j--; // move in upright direction 
            //    }

            //    Console.Write("\n");
            //}
            //for (int k = 1; k < R; k++)
            //{

            //    int i = k;  // set row index for next  
            //                // point in diagonal 
            //    int j = C - 1;  // set column index for  
            //                    // next point in diagonal 


            //    while (isValid(i, j))
            //    {
            //        Console.Write(matrix[i, j] + " ");

            //        i++;
            //        j--; // move in upright direction 
            //    }

            //    Console.Write("\n");
            //}

            //Diagonal Matrix( Upwards Default)
            //for (int k = 0; k < R; k++)
            //{
            //    Console.Write(matrix[k, 0] + " ");

            //    int i = k - 1;  // set row index for next 
            //                    // point in diagonal 
            //    int j = 1;    // set column index for  
            //                  // next point in diagonal 


            //    while (isValid(i, j))
            //    {
            //        Console.Write(matrix[i, j] + " ");

            //        i--;
            //        j++; // move in upright direction 
            //    }

            //    Console.Write("\n");
            //}
            //for (int k = 1; k < C; k++)
            //{
            //    Console.Write(matrix[R - 1, k] + " ");

            //    int i = R - 2;  // set row index for next  
            //                    // point in diagonal 
            //    int j = k + 1;  // set column index for  
            //                    // next point in diagonal 


            //    while (isValid(i, j))
            //    {
            //        Console.Write(matrix[i, j] + " ");

            //        i--;
            //        j++; // move in upright direction 
            //    }

            //    Console.Write("\n");
            //}

            //Zig-Zag Matrix
            //while (evenrow < R)
            //{
            //    for(int i = 0; i < C; i++)
            //    {
            //        Console.WriteLine(matrix[evenrow,i]);
            //    }
            //    evenrow = evenrow + 2;

            //    if (oddrow < R)
            //    {
            //        for (int i =C-1; i >=0; i--)
            //        {
            //            Console.WriteLine(matrix[oddrow, i]);
            //        }
            //      }
            //    oddrow = oddrow + 2;
            //}

            //Rotate Matrix clockwise (Transpose and then reverse columns of a matrix)
            //transpose
            for (int i = 0; i < R; i++)
            {
                for(int j = i; j < C; j++)
                {
                    int temp = matrix[j, i];
                    matrix[j, i] = matrix[i, j];
                    matrix[i, j] = temp;
                }
            }
//reverse rows(for clockwise)
            for (int i = 0; i < R; i++)
            {
                for(int j =0,k=R-1;j<k;j++,k--)
                {
                    int temp = matrix[i,j];
                    matrix[i,j] = matrix[i,k];
                    matrix[i,k] = temp;
                }
            }

            //reverse cols(for anti-clockwise)

            for (int i = 0; i < C; i++) { 
                for (int j = 0, k = C - 1;j < k; j++, k--)
                {
                    int temp = matrix[j, i];
                    matrix[j, i] = matrix[k, i];
                    matrix[k, i] = temp;
                }
        }
        printMatrix(matrix);


        }
        static public int[,] GenerateMatrix(int n)
        {
            int rowBegin = 0;
            int colBegin = 0;
            int rowEnd = n - 1;
            int colEnd = n - 1;

            int[,] arr = new int[n, n];
            int counter = 0;

            while (rowBegin <= rowEnd || colBegin <= colEnd)
            {
                for (int i = colBegin; i <= colEnd; i++)
                {
                    arr[rowBegin, i] = ++counter;
                }
                rowBegin++;

                for (int i = rowBegin; i <= rowEnd; i++)
                {
                    arr[i, colEnd] = ++counter;
                }
                colEnd--;

                for (int i = colEnd; i >= colBegin; i--)
                {
                    arr[rowEnd, i] = ++counter;
                }
                rowEnd--;

                for (int i = rowEnd; i >= rowBegin; i--)
                {
                    arr[i, colBegin] = ++counter;
                }

                colBegin++;
            }

            return arr;
        }

        public bool isValid(int i, int j)
        {
            if (i < 0 || i >= R ||
                j >= C || j < 0) return false;
            return true;
        }
        public void printMatrix(int[,] arr)
        {

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine("");
            }
        }
    }
}
