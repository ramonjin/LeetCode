using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ContainerWithMostWater : LeetCodeBase
    {
        public override void Run()
        {
            int[] a = {2, 2, 2 };
            int ret = MaxArea(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public int MaxArea(int[] height)
        {
            int left = 0;
            int right = height.Length - 1;
            int max = 0;
            while (left < right)
            {
                int temp = (right - left) * Math.Min(height[left], height[right]);
                if (temp > max)
                {
                    max = temp;
                }

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return max;
        }
    }
}
