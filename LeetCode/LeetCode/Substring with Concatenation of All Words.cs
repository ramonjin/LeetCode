using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Substring_with_Concatenation_of_All_Words : LeetCodeBase
    {
        public override void Run()
        {
            var a = "ababCabab";
            var b = new string[] { "ab", "ab" };
            var ret = FindSubstring(a, b);
            foreach(var item in ret)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        // accept
        public IList<int> FindSubstring(string s, string[] words)
        {
            List<int> ret = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return ret;
            }

            int wordLen = words[0].Length;
            int wordsLen = words.Length * wordLen;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dic.ContainsKey(word))
                {
                    dic[word]++;
                }
                else
                {
                    dic[word] = 1;
                }
            }

            for (int i = 0; i < s.Length - wordsLen + 1; i++)
            {
                Dictionary<string, int> tempDic = new Dictionary<string, int>(dic);
                bool allMatch = true;
                for (int j = 0; j < words.Length; j++)
                {
                    string sub = s.Substring(i + j * wordLen, wordLen);
                    if (tempDic.ContainsKey(sub) && tempDic[sub] > 0)
                    {
                        tempDic[sub]--;
                    }
                    else
                    {
                        allMatch = false;
                        break;
                    }
                }

                if (allMatch)
                {
                    ret.Add(i);
                }
            }

            return ret;
        }

        // time limit exceeded
        public IList<int> FindSubstring2(string s, string[] words)
        {
            List<int> ret = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return ret;
            }

            // 计算words总长度
            int wordLen = words[0].Length;
            int wordsLen = words.Length * wordLen;
            int curStart = 0;
            int curTest = 0;
            bool wordSelected = false;
            int[] wordsIndex = new int[words.Length];   // -1：已经使用完，index >= 0：正在使用
            while (curStart <= s.Length - wordsLen)
            {
                // 如果当前没有选定匹配哪个wordSelected == false
                // 遍历所有的words，看到某个匹配的时候，把对应对应的wordsIndex++
                // 如果已经开始匹配wordSelected = true
                // 遍历所有words，看到有正在遍历的（index > 0），则继续匹配。
                // 如果某个正在匹配的word此时不匹配，把index设置成0
                // 当某个word完全匹配后，将当前index设置为-1，
                // 检查所有words，如果都是-1，则是结果ret.Add(curStart)，否则wordSelected = false
                bool findMatch = false;
                if (!wordSelected)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (wordsIndex[i] == 0 && words[i][0] == s[curTest])
                        {
                            findMatch = true;
                            if (++wordsIndex[i] == wordLen)
                            {
                                wordsIndex[i] = -1;
                                // 有一个完全匹配了，判断是不是所有都完全匹配
                                // 如果是的，则ret.Add, 重置wordsIndex，curStart++
                                // 否则把wordSelected = false
                                bool allMatch = true;
                                for (int j = 0; j < words.Length; j++)
                                {
                                    if (wordsIndex[j] != -1)
                                    {
                                        allMatch = false;
                                        break;
                                    }
                                }

                                if (allMatch)
                                {
                                    ret.Add(curStart);
                                    findMatch = false;
                                }
                                else
                                {
                                    wordSelected = false;
                                }
                                break;
                            }
                            else
                            {
                                wordSelected = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (wordsIndex[i] > 0)
                        {
                            if (words[i][wordsIndex[i]] == s[curTest])
                            {
                                findMatch = true;
                                if (++wordsIndex[i] == wordLen)
                                {
                                    wordsIndex[i] = -1;
                                    // 有一个完全匹配了，判断是不是所有都完全匹配
                                    // 如果是的，则ret.Add, 重置wordsIndex，curStart++
                                    // 否则把其他的wordsIndex = 0，把wordSelected = false
                                    bool allMatch = true;
                                    for (int j = 0; j < words.Length; j++)
                                    {
                                        if (wordsIndex[j] != -1)
                                        {
                                            wordsIndex[j] = 0;
                                            allMatch = false;
                                        }
                                    }

                                    if (allMatch)
                                    {
                                        ret.Add(curStart);
                                        findMatch = false;
                                    }
                                    else
                                    {
                                        wordSelected = false;
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                wordsIndex[i] = 0;
                            }
                        }
                    }
                }

                if (!findMatch)
                {
                    for (int i = 0; i < wordsIndex.Length; i++)
                    {
                        wordsIndex[i] = 0;
                    }

                    wordSelected = false;
                    curStart++;
                    curTest = curStart;
                }
                else
                {
                    curTest++;
                }
            }

            return ret;
        }
    }
}
