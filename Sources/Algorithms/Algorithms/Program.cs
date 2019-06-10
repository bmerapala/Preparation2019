using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Arrays;
using Algorithms.Common;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IAlgorithm algorithm = GetAlgorithm("FirstNonrptnChar_EquilibruimIndex_CommonPrefix");
            algorithm.Execute();
            //Console.WriteLine("value" + val);
        }

        private static IAlgorithm GetAlgorithm(string name)
        {
            switch (name)
            {
                case "RemoveDuplicatesfromString":
                    string Input = "You have beautiful eyes";
                    IAlgorithm RemoveDuplicatesfromString = new RemoveDuplicatesfromString(Input);
                    return RemoveDuplicatesfromString;
                case "PairAndThreewithGivenSum":
                    int[] Input1 = new int[] { 8, 4,7,10, 2, 5, -3 ,1,-1,0,4};
                    int sum = 0;
                    IAlgorithm PairandThreewithGivenSum = new PairAndThreewithGivenSum(Input1,sum);
                    return PairandThreewithGivenSum;
                case "RearrangeEvenAndOdd":
                    int[] Input2 = new int[] { 0,0,0,0,1,1,1,0,1,0,0,1,1,0,0,0,0,0,0,0,1 };
                    IAlgorithm RearrangeEvenAndOdd = new RearrangeEvenAndOdd(Input2);
                    return RearrangeEvenAndOdd;
                case "SpiralDiagonalUDMatrix":
                    int[,] Input3 = new int[,] { {1, 2, 3, 4},
                    {5,6,7,8},
                    {9,10,11,12},
                    {10,20,30,40}
                    };
                    IAlgorithm SpiralDiagonalUDMatrix = new SpiralDiagonalUDMatrix(Input3);
                    return SpiralDiagonalUDMatrix;
                case "SubstringsAndSubArrays":
                    int[] Input4 = new int[] { 1,2,3,5,6,7,3,5,5,5,5,5,5 };
                    int[] Input5 = new int[] { 1,6,7,9 };
                    IAlgorithm SubstringsAndSubArrays = new SubstringsAndSubArrays(Input4, Input5);
                    return SubstringsAndSubArrays;
                case "SubsequencesArrayString":
                    String Input6 = "abc";
                    IAlgorithm SubsequencesArrayString = new SubsequencesArrayString(Input6);
                    return SubsequencesArrayString;
                case "PermParanthesisBinaryOpDeckShuffle":
                    String Input7 = "acd";
                    IAlgorithm PermParanthesisBinaryOpDeckShuffle = new PermParanthesisBinaryOpDeckShuffle(Input7);
                    return PermParanthesisBinaryOpDeckShuffle;
                case "PrimeRectArea":
                    int Input8 = 1;
                    IAlgorithm PrimeRectArea = new PrimeRectArea(Input8);
                    return PrimeRectArea;
                case "ReverseInPlaceFibonacciAnagarams":
                    string[] Input9 = { "cat", "dog", "tacg", "god","odg", "dayiloh", "holiday" }; 
                    IAlgorithm ReverseInPlaceFibonacciAnagarams = new ReverseInPlaceFibonacciAnagarams(Input9);
                    return ReverseInPlaceFibonacciAnagarams;
                case "RotateArrayPalindromeVerticalPrint":
                    int[] Input10 = { 1,4,5,3,2,2,5};
                    int rotateBy = 3;
                    IAlgorithm RotateArrayPalindromeVerticalPrint = new RotateArrayPalindromeVerticalPrint(Input10, rotateBy);
                    return RotateArrayPalindromeVerticalPrint;
                case "FirstNonrptnChar_EquilibruimIndex_CommonPrefix":
                    string Input11 = "bhavana";
                    IAlgorithm FirstNonrptnChar_EquilibruimIndex_CommonPrefix = new FirstNonrptnChar_EquilibruimIndex_CommonPrefix(Input11);
                    return FirstNonrptnChar_EquilibruimIndex_CommonPrefix;
                case "SymtricPairs_abeqcdPairs_SubArr":
                    int[,] Input12 = { { 11, 20 }, { 30, 40 }, { 5, 10 }, { 40, 30 }, { 10, 5 } };
                    IAlgorithm SymtricPairs_abeqcdPairs_SubArr = new SymtricPairs_abeqcdPairs_SubArr(Input12);
                    return SymtricPairs_abeqcdPairs_SubArr;
                case "GCD_ModifyMatrix_InfixtPostfix":
                    int Input13 = 56, Input14 = 42;
                    IAlgorithm GCD_ModifyMatrix_InfixtPostfix = new GCD_ModifyMatrix_InfixtPostfix(Input13,Input14);
                    return GCD_ModifyMatrix_InfixtPostfix;
                case "LongestPalindromeUniqueCommonSubstring":
                    string Input15 = "Geeksforgeeks",  Input16 = "GoodMfororning";
                    IAlgorithm LongestPalindromeUniqueCommonSubstring = new LongestPalindromeUniqueCommonSubstring(Input15, Input16);
                    return LongestPalindromeUniqueCommonSubstring;
                case "LongstConsecSubseqLongstContSubarrayLongstcmnSubseq":
                    int[] Input17 = { 36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42 };
                    IAlgorithm LongstConsecSubseqLongstContSubarrayLongstcmnSubseq = new LongstConsecSubseqLongstContSubarrayLongstcmnSubseq(Input17);
                    return LongstConsecSubseqLongstContSubarrayLongstcmnSubseq;
                case "MedArrays":
                    int[] Input18 = { 36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42 };
                    IAlgorithm MedArrays = new MedArrays(Input18);
                    return MedArrays;
                case "VPArrays":
                    int[] Input19 = { 36, 41, 56, 35, 44, 33, 34, 92, 43, 32, 42 };
                    IAlgorithm VPArrays = new VPArrays(Input19);
                    return VPArrays;
                //Linked Lists
                case "MiddleElLoopExistsLLReverseRemoveNode":
                   IAlgorithm MiddleElLoopExistsLLReverseRemoveNode = new MiddleElLoopExistsLLReverseRemoveNode();
                    return MiddleElLoopExistsLLReverseRemoveNode;
                case "DuplicatesLengthPalindromeKthnode":
                    IAlgorithm DuplicatesLengthPalindromeKthnode = new DuplicatesLengthPalindromeKthnode();
                    return DuplicatesLengthPalindromeKthnode;
                case "DeleteAltSwapAdjacentSortandMergeAddLL":
                    IAlgorithm DeleteAltSwapAdjacentSortandMergeAddLL = new DeleteAltSwapAdjacentSortandMergeAddLL();
                    return DeleteAltSwapAdjacentSortandMergeAddLL;
                case "RotateByKthSLLCRUD":
                    IAlgorithm RotateByKthSLLCRUD = new RotateByKthSLLCRUD();
                    return RotateByKthSLLCRUD;
                case "MedLL":
                    IAlgorithm MedLL = new MedLL();
                    return MedLL;
                case "SQSQQandQSQSSandSAQA":
                    IAlgorithm SQSQQandQSQSSandSAQA = new SQSQQandQSQSSandSAQA();
                    return SQSQQandQSQSSandSAQA;
                case "Sortusing2SMergeSortQuicksort":
                    IAlgorithm Sortusing2SMergeSortQuicksort = new Sortusing2SMergeSortQuicksort();
                    return Sortusing2SMergeSortQuicksort;
                case "CRUD":
                    IAlgorithm CRUD = new CRUD();
                    return CRUD;
                case "InorderSuccMinHgtBSTCmnAncestorValidBST":
                    IAlgorithm InorderSuccMinHgtBSTCmnAncestorValidBST = new InorderSuccMinHgtBSTCmnAncestorValidBST();
                    return InorderSuccMinHgtBSTCmnAncestorValidBST;
                case "InPrPsIterativeandRecursiveLeftTopRightBottomViews":
                    IAlgorithm InPrPsIterativeandRecursiveLeftTopRightBottomViews = new InPrPsIterativeandRecursiveLeftTopRightBottomViews();
                    return InPrPsIterativeandRecursiveLeftTopRightBottomViews;
                case "BoundarySpiralTraversalBuildTreeAllCombos":
                      IAlgorithm BoundarySpiralTraversalBuildTreeAllCombos = new BoundarySpiralTraversalBuildTreeAllCombos();
                    return BoundarySpiralTraversalBuildTreeAllCombos;
                case "ConnectlevelsCheckHeightBalancedSymmetricTree":
                    IAlgorithm ConnectlevelsCheckHeightBalancedSymmetricTree = new ConnectlevelsCheckHeightBalancedSymmetricTree();
                    return ConnectlevelsCheckHeightBalancedSymmetricTree;
                case "InvertTreePathsumMaxMinDepthTreeFlattenBTtoLL":
                    IAlgorithm InvertTreePathsumMaxMinDepthTreeFlattenBTtoLL = new InvertTreePathsumMaxMinDepthTreeFlattenBTtoLL();
                    return InvertTreePathsumMaxMinDepthTreeFlattenBTtoLL;
                case "Nodesbtwn2levelsLongestPathBinary2BSTVerticalNodesSum":
                    IAlgorithm Nodesbtwn2levelsLongestPathBinary2BSTVerticalNodesSum = new Nodesbtwn2levelsLongestPathBinary2BSTVerticalNodesSum();
                    return Nodesbtwn2levelsLongestPathBinary2BSTVerticalNodesSum;
                case "NodemstkSwapSubtreeofaTreeAllpathsrootToleaves":
                    IAlgorithm NodemstkSwapSubtreeofaTreeAllpathsrootToleaves = new NodemstkSwapSubtreeofaTreeAllpathsrootToleaves();
                    return NodemstkSwapSubtreeofaTreeAllpathsrootToleaves;
                case "RatInMazeTravelZerosPath":
                    IAlgorithm RatInMazeTravelZerosPath = new RatInMazeTravelZerosPath();
                    return RatInMazeTravelZerosPath;
                case "BFSDFS":
                    IAlgorithm BFSDFS = new BFSDFS(4);
                    return BFSDFS;


            }

            return null;
        }
    }
}
