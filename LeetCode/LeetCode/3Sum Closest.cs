using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class _3Sum_Closest : LeetCodeBase
    {
        public override void Run()
        {
            int[] a = { 1, 1, 1, 0 };
            var ret = ThreeSumClosest(a, 100);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            // 先排序，然后从左到右，先拿1个，然后两头往内搜索
            Array.Sort(nums);
            int ret = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                // 如果有连续重复的，只算第一个就够了，后面的可以跳过
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[start] + nums[end] + nums[i];
                    if (sum > target)
                    {
                        end--;
                    }
                    else
                    {
                        start++;
                    }

                    // 如果差别更小，存起来
                    if (Math.Abs(sum - target) < Math.Abs(ret - target))
                    {
                        ret = sum;
                    }
                }
            }
            return ret;
        }
    }
}
