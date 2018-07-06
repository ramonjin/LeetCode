using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Integer_to_English_Words : LeetCodeBase
    {
        public override void Run()
        {
            var a = 100;
            var ret = NumberToWords(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return numStrU20[0];
            }


            StringBuilder sb = new StringBuilder();

            bool negetive = false;
            if (num < 0)
            {
                negetive = true;
                num = -num;
            }

            int comma = 0;
            while (num > 0)
            {
                int temp = num % 1000;
                num = num / 1000;
                string str = ParseInThousand(temp);
                if (str.Length > 0)
                {
                    sb.Insert(0, str);
                    sb.Insert(str.Length, sb.Length > str.Length ? commaStr[comma] + " " : commaStr[comma]);
                }
                comma++;
            }

            if (negetive)
            {
                sb.Insert(0, "Negetive ");
            }
            return sb.ToString();
        }

        private string ParseInThousand(int num)
        {
            if (num >= 1000)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();

            // 百位
            if (num >= 100)
            {
                int hundreds = num / 100;
                sb.Append(numStrU20[hundreds]);
                sb.Append(" Hundred");
            }

            // 后面的
            string str = ParseInHundred(num % 100);
            if (!string.IsNullOrEmpty(str))
            {
                if(sb.Length > 0)
                {
                    sb.Append(" ");
                }
                sb.Append(str);
            }
            return sb.ToString();
        }

        private string ParseInHundred(int num)
        {
            if (num >= 100 || num == 0)
            {
                return string.Empty;
            }

            if (num < 20)
            {
                return numStrU20[num];
            }

            StringBuilder sb = new StringBuilder();

            // 十位
            int tens = num / 10;
            sb.Append(numStrU100[tens]);

            // 个位
            if (num % 10 != 0)
            {
                sb.Append(" ");
                sb.Append(numStrU20[num % 10]);
            }

            return sb.ToString();
        }

        private string[] numStrU20 = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private string[] numStrU100 = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private string[] commaStr = { "", " Thousand", " Million", " Billion" };
    }
}
