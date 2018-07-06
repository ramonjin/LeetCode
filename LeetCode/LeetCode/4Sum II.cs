using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class _4Sum_II : LeetCodeBase
    {
        public override void Run()
        {
            int[] a = { 1, 2 };
            int[] b = { -2, -1};
            int[] c = { -1, 2 };
            int[] d = { 0, 2 };
            var ret = FourSumCount(a, b, c, d);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int ret = 0;
            int len = A.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    int sum = A[i] + B[j];
                    if (map.ContainsKey(sum))
                    {
                        map[sum]++;
                    }
                    else
                    {
                        map[sum] = 1;
                    }
                }
            }

            for (int k = 0; k < len; k++)
            {
                for (int l = 0; l < len; l++)
                {
                    int sum = C[k] + D[l];
                    {
                        if (map.ContainsKey(-sum) && map[-sum] > 0)
                        {
                            ret+= map[-sum];
                        }
                    }
                }
            }
            return ret;
        }
    }
}
