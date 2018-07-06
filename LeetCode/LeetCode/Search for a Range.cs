using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Search_for_a_Range : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[] { 5, 7, 7, 8, 8, 10 };
            var b = 8;
            var ret = SearchRange(a, b);
            foreach (var item in ret)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        public int[] SearchRange(int[] nums, int target)
        {
            // the most left value and the most right value
            int left = -1;
            int right = -1;

            // indexes used to search the value
            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    // finds the left and right
                    for (int i = mid; i >= start; i--)
                    {
                        if (nums[i] == target)
                        {
                            left = i;
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int i = mid; i <= end; i++)
                    {
                        if (nums[i] == target)
                        {
                            right = i;
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                }

                if (nums[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }


            return new int[] { left, right };
        }

    }
}
