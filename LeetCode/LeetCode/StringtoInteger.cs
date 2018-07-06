using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class StringtoInteger : LeetCodeBase
    {
        public override void Run()
        {
            string a = "2147483648";
            int b = MyAtoi(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }


        public int MyAtoi(string str)
        {
            str = str.Trim();
            if (str.Length == 0)
            {
                return 0;
            }

            long temp = 0;
            int start = 0;
            bool negetive = false;

            if (str[0] == '+')
            {
                start = 1;
            }
            else if (str[0] == '-')
            {
                start = 1;
                negetive = true;
            }

            for (int i = start; i < str.Length; i++)
            {
                char c = str[i];
                if (c < '0' || c > '9')
                {
                    break;
                }

                temp = 10 * temp + (c - '0');
                if (temp > int.MaxValue)
                {
                    return negetive ? int.MinValue : int.MaxValue;
                }
            }

            if (negetive)
            {
                temp = -temp;
            }

            return (int)temp;
        }
    }
}
