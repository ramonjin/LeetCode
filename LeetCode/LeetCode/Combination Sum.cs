using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Combination_Sum : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[] { 2, 3, 6, 7 };
            var b = 7;
            var ret = CombinationSum(a, b);
            foreach (var list in ret)
            {
                foreach (int n in list)
                {
                    Console.Write(n);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> ret = new List<IList<int>>();
            List<int> temp = new List<int>();
            Find(candidates, target, 0, temp, ret);
            return ret;
        }

        private void Find(int[] c, int target, int begin, List<int> temp, List<IList<int>> ret)
        {
            if (target < 0)
            {
                // Can't find a match
                return;
            }

            if (target == 0)
            {
                // Adds the temp into ret.
                ret.Add(new List<int>(temp));
                return;
            }

            for (int i = begin; i < c.Length; i++)
            {
                temp.Add(c[i]);
                Find(c, target - c[i], i, temp, ret);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
