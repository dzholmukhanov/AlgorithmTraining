using CFTraining.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 5, 4, 1, 3, 10, 7};
            SegmentTree tree = new SegmentTree(a);
            tree.Update(2, 4, 5);
            tree.Update(3, 5, 9);
            Console.WriteLine(tree.QueryMin(0, 5));
            Console.WriteLine(tree.QueryMin(0, 2));
            Console.WriteLine(tree.QueryMin(3, 5));
            Console.WriteLine(tree.QueryMin(0, 1));
            Console.WriteLine(tree.QueryMin(4, 5));
            Console.WriteLine(tree.QueryMin(2, 2));
        }
    }
}
