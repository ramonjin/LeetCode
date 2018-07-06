using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ReverseInteger : LeetCodeBase
    {
        public override void Run()
        {
            int a = -100;
            int i = Reverse(a);
            Console.WriteLine(i.ToString());
            Console.ReadKey();
        }

        public int Reverse(int x)
        {
            long ret = 0;
            long n = x;
            if (n < 0)
            {
                n = -n;
            }
            while (n > 0)
            {
                long temp = n % 10;
                ret = ret * 10 + temp;
                n = n / 10;
            }

            if (x < 0)
            {
                ret = -ret;
            }

            if (ret > int.MaxValue || ret < int.MinValue)
            {
                return 0;
            }

            return (int)ret;
        }
    }
}
