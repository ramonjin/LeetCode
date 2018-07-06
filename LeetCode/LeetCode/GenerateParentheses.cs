using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class GenerateParentheses : LeetCodeBase
    {
        public override void Run()
        {
            int a = 4;
            var ret = GenerateParenthesis(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public IList<string> GenerateParenthesis(int n)
        {
            ret = new List<string>();
            char[] c = new char[n * 2];
            Generate(c, 0, n, n);
            return ret;
        }

        private List<string> ret;
        private void Generate(char[] c, int cur, int leftCount, int rightCount)
        {
            if (leftCount == 0 && rightCount == 0)
            {
                ret.Add(new string(c));
                return;
            }

            if (leftCount == rightCount)
            {
                c[cur] = '(';
                Generate(c, cur + 1, leftCount - 1, rightCount);
            }
            else
            {
                if (leftCount > 0)
                {
                    c[cur] = '(';
                    Generate(c, cur + 1, leftCount - 1, rightCount);
                }

                c[cur] = ')';
                Generate(c, cur + 1, leftCount, rightCount - 1);
            }
        }
    }
}
