using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Divide_Two_Integers : LeetCodeBase
    {
        public override void Run()
        {
            var a = -2147483648;
            var b = 2;
            var ret = Divide(a, b);
            Console.WriteLine(ret);
            Console.ReadKey();
        }


        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                return int.MaxValue;
            }

            if (dividend == 0)
            {
                return 0;
            }

            if (divisor == 1)
            {
                return (int)dividend;
            }

            if (divisor == -1)
            {
                if (dividend == int.MinValue)
                {
                    return int.MaxValue;
                }
                else
                {
                    return (int)-dividend;
                }
            }

            long a = dividend;
            long b = divisor;

            bool negetive = false;
            if (a < 0)
            {
                a = -a;
                negetive = !negetive;
            }

            if (b < 0)
            {
                b = -b;
                negetive = !negetive;
            }

            int ret = 0;
            while (a >= 0)
            {
                long t = b;
                long tempRet = 1;
                while (t <= a)
                {
                    t = t << 1;
                    tempRet = tempRet << 1;
                }
                a -= t >> 1;
                ret +=(int)(tempRet >> 1);
            }

            return negetive ? -ret : ret;
        }
    }
}
