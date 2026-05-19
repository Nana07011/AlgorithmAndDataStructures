using System;
namespace Home3kr13052
{
    internal class Programm
    {
        static bool Solution9(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var set1 = new Dictionary<char, int>();
            foreach(char c in s)
                set1[c] = set1.GetValueOrDefault(c)+1;
            foreach (char c in t)
            {
                if (!set1.ContainsKey(c)) return false;
                if (set1[c] < 0) return false;
            }
            return true;
        }
        static int[] Solution10(string[] queries, string[] words)
        {
            int[] wunique = new int[words.Length];
            for(int i = 0; i < words.Length; i++)
            {
                wunique[i] = new HashSet<char>(words[i]).Count;
            }
            Array.Sort(wunique);
            int[] res = new int[queries.Length];
            for(int i = 0; i < queries.Length; i++)
            {
                int qunique = new HashSet<char>(queries[i]).Count;
                int count = 0;
                foreach (int w in wunique)
                {
                    if (w > qunique) count++;
                }
                res[i] = count;
            }
            return res;
        }
        static int Solution11(int[] nums)
        {
            var set = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (set.ContainsKey(i))
                    return i;
                else set[i] = 1;
            }
            return -1;
        }
        static char Solution12(string s, string t)
        {
            var set = new Dictionary<char, int>();
            foreach(char c in t)
                set[c] = set.GetValueOrDefault(c)+1;
            foreach (char c in s)
                set[c] = set.GetValueOrDefault(c) + -1;
            foreach (var pair in set)
            {
                if (pair.Value > 0) return pair.Key;
            }
            return '-';
        }
        static void Main()
        {
            //Console.WriteLine(Solution9("listek", "silent")); 9 задача

            //string[] res1 = { "aabb", "abcd", "a"};
            //string[] res2 = { "abc", "ab", "aab", "aaaa" };
            //int[] res = Solution10(res1,res2);
            //foreach (int i in res) Console.WriteLine(i); 10 задача

            //Console.WriteLine(Solution11([1,2,3,2,1])); 11 задача

            //Console.WriteLine(Solution12("abd", "ff")); 12 задача
        }
    }
}
