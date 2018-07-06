using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Russian_Doll_Envelopes : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[,] { { 5, 4 }, { 6, 4 }, { 6, 7 }, { 2, 3 } };
            var ret = MaxEnvelopes(a);
            Console.Write(ret);
            Console.WriteLine();
            Console.ReadKey();
        }

        public int MaxEnvelopes(int[,] envelopes)
        {
            int max = 0;
            for (int i = 0; i < envelopes.Length / 2; i++)
            {
                int cur = GetInEnvelope(envelopes, i);
                max = Math.Max(max, cur);
            }
            return max;
        }

        private int GetInEnvelope(int[,] envelopes, int index)
        {
            if (index >= envelopes.Length / 2)
                return 0;

            int max = 0;
            int w = envelopes[index, 0];
            int h = envelopes[index, 1];
            for (int i = 0; i < envelopes.Length / 2; i++)
            {
                if (envelopes[i, 0] > w && envelopes[i, 1] > h)
                {
                    int count = GetInEnvelope(envelopes, i);
                    max = Math.Max(max, count);
                }
            }

            return max + 1;
        }
    }
}
