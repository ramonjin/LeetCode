using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LeetCode
{
    class ZigZagConversion : LeetCodeBase
    {
        public override void Run()
        {
            string input = "ABC";
            int rows = 1;
            Console.WriteLine(Convert(input, rows));
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            List<List<char>> l = new List<List<char>>();
            for (int i = 0; i < numRows; i++)
            {
                List<char> list = new List<char>();
                l.Add(list);
            }

            int column = 0;
            int row = 0;
            int index = 0;
            bool straight = true;
            while (index < s.Length)
            {
                if (l[row].Count < index)
                {
                    for (int i = l[row].Count; i < index; i++)
                    {
                        l[row].Add(' ');
                    }
                }

                l[row].Add(s[index]);

                index++;
                if (straight)
                {
                    row++;
                }
                else
                {
                    row--;
                    column++;
                }

                if (row % (numRows - 1) == 0)
                {
                    straight = !straight;
                }
            }

            StringBuilder sb = new StringBuilder(s.Length);
            foreach (List<char> lst in l)
            {
                for (int j = 0; j < lst.Count; j++)
                {
                    if (lst[j] != ' ')
                    {
                        sb.Append(lst[j]);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
