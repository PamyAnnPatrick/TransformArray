using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformArray360
{
    public class Solution
    {
        public int[] SortTransformedArray(int[] nums, int a, int b, int c)
        {
            int[] sols = new int[nums.Length];
            int i = 0;

            bool isAPositive = a >= 0;
            int left, right;
            if (isAPositive)
            {
                left = ((nums.Length - 1) / 2) + 1;
                right = (nums.Length - 1) / 2;
            }
            else
            {
                right = nums.Length - 1;
                left = 0;
            }
            while ((left <= right && !isAPositive) || ((left < nums.Length || right >= 0) && isAPositive))
            {
                int? leftsum = calc(nums, a, b, c, left);
                int? rightsum = calc(nums, a, b, c, right);

                if (leftsum == null)
                {
                    sols = AddSorted(sols, rightsum.Value, i++);
                    right--;
                }
                else if (rightsum == null)
                {
                    sols = AddSorted(sols, leftsum.Value, i++);
                    left++;
                }
                else if (rightsum < leftsum)
                {
                    sols = AddSorted(sols, rightsum.Value, i++);
                    right--;
                }
                else if (rightsum > leftsum)
                {
                    sols = AddSorted(sols, leftsum.Value, i++);
                    left++;
                }
                else
                {
                    sols = AddSorted(sols, leftsum.Value, i++);
                    sols = AddSorted(sols, rightsum.Value, i++);
                    left++;
                    right--;
                }
            }

            return sols;
        }
        private int? calc(int[] nums, int a, int b, int c, int pos)
        {
            if (pos < 0 || pos >= nums.Length)
                return null;
            return (a * nums[pos] * nums[pos]) + (b * nums[pos]) + c;
        }
        private int[] AddSorted(int[] sols, int s, int position)
        {
            if (position < sols.Length)
            {
                int i = position;
                //Manual sort when value of b is high
                while (i > 0 && sols[i - 1] > s)
                {
                    sols[i] = sols[i - 1];
                    i--;
                }
                sols[i] = s;
            }
            return sols;
        }
    }
}
