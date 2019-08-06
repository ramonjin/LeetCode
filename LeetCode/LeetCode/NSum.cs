using System;
using System.Collections.Generic;

namespace LeetCode
{
    public class _NSum : LeetCodeBase
    {
        public override void Run()
        {
            int[] a = { 1, 0, -1, 0, -2, 2 };
            var ret = NSum(a, 0, 4);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        List<IList<int>> ret;
        public IList<IList<int>> NSum(int[] nums, int target, int n)
        {
            ret = new List<IList<int>>();
            Array.Sort(nums);
            Helper(nums, 0, target, n, new int[n]);
            return ret;
        }

        public void Helper(int[] nums, int start, int target, int count, int[] arr)
        {
            if (count == 0)
            {
                if (target == 0)
                    ret.Add(new List<int>(arr));
                return;
            }
            if (count == 2)
            {
                TwoSum(nums, start, target, arr);
                return;
            }
            int last = int.MaxValue;
            for (int i = start; i < nums.Length; i++)
            {
                if (nums[i] != last)
                {
                    last = nums[i];
                    arr[arr.Length - count] = nums[i];
                    Helper(nums, i + 1, target - nums[i], count - 1, arr);
                }
            }
        }

        public void TwoSum(int[] nums, int start, int target, int[] arr)
        {
            int lastMin = int.MinValue;
            int lastMax = int.MaxValue;
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                if (nums[i] + nums[j] == target)
                {
                    arr[arr.Length - 2] = nums[i];
                    arr[arr.Length - 1] = nums[j];
                    ret.Add(new List<int>(arr));
                    lastMin = nums[i];
                    lastMax = nums[j];
                    i++;
                    j--;
                }
                else if (nums[i] + nums[j] > target)
                {
                    lastMax = nums[j];
                    j--;
                }
                else
                {
                    lastMin = nums[i];
                    i++;
                }

                while (i < j && nums[i] == lastMin) i++;
                while (i < j && nums[j] == lastMax) j--;
            }
        }
    }
}