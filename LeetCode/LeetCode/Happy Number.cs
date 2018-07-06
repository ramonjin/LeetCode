using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Happy_Number : LeetCodeBase
    {
        public override void Run()
        {
            var a = 7;
            var ret = IsHappy(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public bool IsHappy(int n)
        {
            Dictionary<int, bool> dic = new Dictionary<int, bool>();
            while (true)
            {

                int sum = 0;
                while (n > 0)
                {
                    int temp = n % 10;
                    temp *= temp;
                    sum += temp;
                    n = n / 10;
                }

                Console.WriteLine(sum);
                if (sum == 1)
                {
                    return true;
                }
                else
                {
                    if (dic.ContainsKey(sum))
                    {
                        return false;
                    }

                    dic[sum] = true;
                    n = sum;
                }
            }
        }
    }
}
