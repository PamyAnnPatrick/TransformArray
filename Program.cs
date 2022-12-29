using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformArray360
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums =new int[] { -4, -2, 2, 4 };
            int a = 1, b = 43, c = 5;
            //int a = -1, b = 3, c = 5;
            Solution sol = new Solution();
            sol.SortTransformedArray(nums, a, b, c);
        }
    }
}
