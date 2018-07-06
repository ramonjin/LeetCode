using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Coin_Change : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[] { 243, 291, 335, 209, 177, 345, 114, 91, 313, 331 };
            var b = 7367;
            var ret = CoinChange(a, b);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        private int minCount = int.MaxValue;
        public int CoinChange(int[] coins, int amount)
        {
            Array.Sort(coins);
            Find(coins, coins.Length - 1, amount, 0);

            if (minCount < int.MaxValue)
            {
                return minCount;
            }
            return -1;
        }

        private void Find(int[] coins, int len, int amount, int count)
        {
            if (count >= minCount)
            {
                return;
            }

            if (amount == 0)
            {
                minCount = Math.Min(minCount, count);
            }

            for (int i = len; i >= 0; i--)
            {
                int num = amount / coins[i];
                if (num < minCount - count)
                {
                    for (int j = num; j > 0; j--)
                    {
                        Find(coins, i - 1, amount - coins[i] * j, count + j);
                    }
                }
            }
        }
    }
}
