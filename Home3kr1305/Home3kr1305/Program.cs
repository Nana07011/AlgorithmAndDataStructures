using System;
namespace Home3kr1305
{
    internal class Program
    {
        static string[] Solution1(string[] city1, string[] city2) //1 задача
        {
            var set1 = new HashSet<string>(city1);
            var res = new HashSet<string>();
            foreach (var city in city2)
            {
                if (set1.Contains(city)) res.Add(city);
            }
            return res.ToArray();
        }
        static int Solution2(string s)//2 задача
        {
            var set = new Dictionary<char, int>();
            foreach (char c in s)
            {
                set[c] = set.GetValueOrDefault(c)+1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (set[s[i]] == 1) return i;
            } 
            return -1;
        }
        static int[] Solution3(int[] nums, int target)
        {
            var set = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                if (set.ContainsKey(num)) 
                    return new int[] { set[num], i};
                set[nums[i]] = i;
            }
            return new int[0];   
        }
        static int Solution4(int[] nums)
        {
            var res = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (res.ContainsKey(num))
                    res[num]++;
                else
                    res[num] = 1;
            }
            int count = 0;
            foreach(int value in res.Values)
            {
                if (value == 1) count++; 
            }
            return count;
        }
        static bool Solution5(string s)
        {
            var res = new HashSet<char>(s.ToLower());
            foreach(char c in s.ToLower())
            {
                if (c >= 'a' && c <= 'z') res.Add(c);
            }
            if (res.Count == 26) return true;
            return false;

        }
        static int Solution6(int[] nums)
        {
            var set = new HashSet<int>(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                if (!set.Contains(i)) return i;
            }
            return -1;
        }
        static bool Solution7 (int[] nums)
        {
            var res = new HashSet<int>(nums);
            if (res.Count < nums.Length) return true;
            return false;
        }
        static string[] Solution8(string[] words1, string[] words2)
        {
            var set1 = new Dictionary<string, int>();
            var set2 = new Dictionary<string, int>();

            foreach (var w in words1)
                set1[w] = set1.GetValueOrDefault(w) + 1;
            foreach (var w in words2)
                set2[w] = set2.GetValueOrDefault(w) + 1;
            var res = new HashSet<string>();
            foreach(var pair in set1)
            {
                if (pair.Value == 1 && set2.GetValueOrDefault(pair.Key) == 1)
                    res.Add(pair.Key);
            }
            return res.ToArray();
        }
        static void Main() 
        {
            string[] city1 = { "Moscow", "Paris", "London", "Berlin" };
            string[] city2 = { "Berlin", "Rome", "Paris", "Madrid" };
            string[] res = Solution1(city1, city2);
            foreach (var city in res)
                Console.WriteLine(city); //1 задача

            string s = "abc";
            Console.WriteLine(Solution2(s)); //2 задача

            int[] res0 = { 2, 7, 11, 15 };
            int[] res1 = Solution3(res0, 9);
            foreach (int i in res1) Console.WriteLine(i); //3 задача

            int[] nums = { 1, 2, 1, 3, 2, 4 };
            Console.WriteLine(Solution4(nums)); //4 задача

            string s1 = "thequickbrownfoxjumpsoverthelazydo";
            Console.WriteLine(Solution5(s1)); //5 задача

            int[] nums1 = { 9, 6, 4, 2, 3, 5, 7, 0, 1 };
            Console.WriteLine(Solution6(nums1)); //6 задача

            Console.WriteLine(Solution7([1, 2, 3, 4, 1, 2])); //7 задача

            string[] words1 = { "a", "b", "c", "a" };
            string[] words2 = { "b", "c", "d", "e" };
            string[] res3 = Solution8(words1, words2);
            foreach (string word in res3) Console.WriteLine(word); //8 задача
        }
        
    }
}