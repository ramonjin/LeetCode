using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Ugly_Number_II : LeetCodeBase
    {
        public override void Run()
        {
            var a = 1;
            var ret = NthUglyNumber(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }
        public int NthUglyNumber(int n)
        {
            if (n <= 0)
            {
                return 0;
            }

            int t2 = 0;
            int t3 = 0;
            int t5 = 0;
            int[] nums = new int[n];
            nums[0] = 1;
            for (int i = 1; i < n; i++)
            {
                nums[i] = Math.Min(nums[t2] * 2, Math.Min(nums[t3]* 3, nums[t5] * 5));
                if (nums[t2] * 2 == nums[i]) t2++;
                if (nums[t3] * 3 == nums[i]) t3++;
                if (nums[t5] * 5 == nums[i]) t5++;
            }
            return nums[n - 1];
        }
    }
}
