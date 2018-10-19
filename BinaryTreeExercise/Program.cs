using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BinaryTreeExercise
{
    class Program
    {
        // Do not want to fill it up with zeros so an IEnumerable
        // smaller input for testing
        // static List<int[]> Input = new List<int[]> { new int[] { 1 }, new int[] { 8, 9 }, new int[] { 1, 5, 9 }, new int[] { 4, 5, 2, 3 } };

        // big input
        static List<int[]> Input = new List<int[]> {
            new int[] { 215 },
            new int[] { 192, 124 },
            new int[] { 117, 269, 442 },
            new int[] { 218, 836, 347, 235 },
            new int[] { 320, 805, 522, 417, 345 },
            new int[] { 229, 601, 728, 835, 133, 124 },
            new int[] { 248, 202, 277, 433, 207, 263, 257 },
            new int[] { 359, 464, 504, 528, 516, 716, 871, 182 },
            new int[] { 461, 441, 426, 656, 863, 560, 380, 171, 923},
            new int[] { 381, 348, 573, 533, 448, 632, 387, 176, 975, 449 },
            new int[] { 223, 711, 445, 645, 245, 534, 931, 532, 937, 541, 444 },
            new int[] { 330, 131, 333, 928, 376, 733, 017, 778, 839, 168, 197, 197 },
            new int[] { 131, 171, 522, 137, 217, 224, 291, 413, 528, 520, 227, 229, 928 },
            new int[] { 223, 626, 034, 683, 839, 052, 627, 310, 713, 999, 629, 817, 410, 121},
            new int[] { 924, 622, 911, 233, 325, 139, 721, 218, 253, 233, 107, 233, 230, 124, 233},
        };
        static void Main(string[] args)
        {
            var nodes = GetBinaryNodes();
            var calc = CalculateMaxSumOfPaths(nodes);
            Console.WriteLine("MAX PATH SUM: {0}",  calc.Sum(node => node.Value));
            Console.Write("PATH: {0}", string.Join(", ", calc.Select(d => d.Value)));
            Console.ReadKey();

        }

        static List<BinaryNode> CalculateMaxSumOfPaths(BinaryNode node)
        {
            int sum = node.Value;
            var paths = new List<BinaryNode> { node };
            var firstChildPaths = new List<BinaryNode>();
            var secondChildPaths = new List<BinaryNode>();
            var pathsCollection = new List<List<BinaryNode>> { paths };
            if (node.FirstChild != null && node.FirstChild.Value % 2 != node.Value % 2)
            {
                firstChildPaths = (CalculateMaxSumOfPaths(node.FirstChild)).ToList();
            }
            if (node.SecondChild != null && node.SecondChild.Value % 2 != node.Value % 2)
            {
                secondChildPaths = (CalculateMaxSumOfPaths(node.SecondChild)).ToList();
            }
            return paths.Concat(firstChildPaths.Sum(n => n.Value) > secondChildPaths.Sum(n => n.Value) ? firstChildPaths : secondChildPaths).ToList();
        }

        static BinaryNode GetBinaryNodes(BinaryNode currentNode = null, int index = 0, int offset = 0)
        {
            if (Input.Count <= index || Input[index].Length <= offset)
            {
                return null;
            }
            if (currentNode == null)
            {
                currentNode = new BinaryNode();
            }
            currentNode.Value = Input[index][offset];
            currentNode.FirstChild = GetBinaryNodes(currentNode.FirstChild, index + 1, offset);
            currentNode.SecondChild = GetBinaryNodes(currentNode.SecondChild, index + 1, offset + 1);
            return currentNode;
        }
    }

    class BinaryNode
    {
        public int Value { get; set; }
        public BinaryNode FirstChild { get; set; }
        public BinaryNode SecondChild { get; set; }
    }
}
