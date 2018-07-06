using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class IntegerToRoman : LeetCodeBase
    {
        public override void Run()
        {
            var a = 151;
            var ret = IntToRoman(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public string IntToRoman(int num)
        {
            //I = 1;
            //V = 5;
            //X = 10;
            //L = 50;
            //C = 100;
            //D = 500;
            //M = 1000;

            StringBuilder sb = new StringBuilder();
            char[] chList = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            int[] numList = { 1000, 500, 100, 50, 10, 5, 1 };
            int[] adjustList = { 2, 4, 6 };

            int cur = 0;
            // 从大往小实验
            for (int i = 0; i < chList.Length; i++)
            {
                // 找到第一个比num大的倍数mul，计算大多少，
                // 如果大不多，则用减的方式，
                // 否则mul-1个字母，然后往后遍历
                for (int mul = 1; mul < 5; mul++)
                {
                    int diff = numList[cur] - num;
                    if (diff > 0)
                    {
                        for (int adjustIndex = 0; adjustIndex < adjustList.Length; adjustIndex++)
                        {
                            if (adjustList[adjustIndex] > cur)
                            {
                                int adjustNum = numList[adjustList[adjustIndex]];
                                if (diff <= adjustNum)
                                {
                                    num -= numList[i] - adjustNum;
                                    sb.Append(chList[adjustList[adjustIndex]]);
                                    sb.Append(chList[i]);
                                    break;
                                }
                            }
                        }

                        break;
                    }
                    else
                    {
                        num -= numList[i];
                        sb.Append(chList[i]);
                    }

                    if (num == 0)
                    {
                        break;
                    }
                }

                if (num == 0)
                {
                    break;
                }
                cur++;
            }

            return sb.ToString();
        }
    }
}
