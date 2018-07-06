using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class _4Sum : LeetCodeBase
    {
        public override void Run()
        {
            int[] a = { 1, 0, -1, 0, -2, 2 };
            var ret = FourSum(a, 0);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }

                IList<IList<int>> temp = ThreeSum(nums, i + 1, target - nums[i]);
                foreach (IList<int> list in temp)
                {
                    list.Add(nums[i]);
                }

                ret.AddRange(temp);
            }

            return ret;
        }

        private IList<IList<int>> ThreeSum(int[] nums, int first, int sum)
        {
            // 先排序，然后从左到右，先拿1个，然后两头往内搜索
            List<IList<int>> ret = new List<IList<int>>();
            for (int i = first; i < nums.Length - 2; i++)
            {
                // 如果有连续重复的，只算第一个就够了，后面的可以跳过
                if (i > first && nums[i] == nums[i - 1])
                {
                    continue;
                }

                int start = i + 1;
                int end = nums.Length - 1;
                int target = sum - nums[i];
                while (start < end)
                {
                    if (nums[start] + nums[end] == target)
                    {
                        List<int> result = new List<int>();
                        result.Add(nums[i]);
                        result.Add(nums[start]);
                        result.Add(nums[end]);
                        ret.Add(result);

                        start++;
                        end--;

                        // 跳过重复的
                        while (start < end && nums[start] == nums[start - 1]) start++;
                        while (start < end && nums[end] == nums[end + 1]) end--;
                    }
                    else if (nums[start] + nums[end] < target)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            return ret;
        }
    }
}
