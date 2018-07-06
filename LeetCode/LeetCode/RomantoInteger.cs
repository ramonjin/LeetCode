using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RomantoInteger : LeetCodeBase
    {
        public override void Run()
        {
            string a = "MCM";
            int i = RomanToInt(a);
            Console.WriteLine(i.ToString());
            Console.ReadKey();
        }

        public int RomanToInt(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            map.Add('I', 1);
            map.Add('V', 5);
            map.Add('X', 10);
            map.Add('L', 50);
            map.Add('C', 100);
            map.Add('D', 500);
            map.Add('M', 1000);

            int ret = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                ret += map[c];
                if (i > 0)
                {
                    char lastC = s[i - 1];
                    if (map[c] > map[lastC] && map[lastC] < 500)
                    {
                        ret -= map[s[i - 1]] * 2;
                    }
                }
            }

            return ret;
        }
    }
}
