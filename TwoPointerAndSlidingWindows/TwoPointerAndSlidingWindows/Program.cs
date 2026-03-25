using System;
using System.Runtime.CompilerServices;
namespace Program
{
    internal class Program
    {
        static void Main()
        {
            string a = "aba"; //1 задание
            string b = "aabba";
            Console.WriteLine(CanConstruct(a, b));
            int[] array = { 3, 3, 1, 2, 3, 4, 5, 6, 7, 8, 2 };//2 задание 
            Console.WriteLine(FindLucky(array));
            int[] nums = { 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0 };//3 задание
            int k = 2;
            Console.WriteLine(LongestOnes(nums,k));
        }
        public static bool CanConstruct(string ransomNote, string magazine)//1 задание
        {
            char[] ransomeChar = ransomNote.ToCharArray();
            char[] magazineChar = magazine.ToCharArray();

            Array.Sort(ransomeChar);
            Array.Sort(magazineChar);

            int firstPoint = 0;
            int secondPoint = 0;

            while (firstPoint < ransomeChar.Length && secondPoint < magazineChar.Length)
            {
                if (ransomeChar[firstPoint] == magazineChar[secondPoint])
                {
                    firstPoint++;
                    secondPoint++;
                }
                else if (ransomeChar[firstPoint] > magazineChar[secondPoint])
                {
                    secondPoint++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static int FindLucky(int[] arr)//2 задание
        {
            Array.Sort(arr);
            int Slow = 0;
            int luckynumber = 0;
            while (Slow < arr.Length)
            {
                int num = arr[Slow];
                int Fast = Slow;
                while (Fast < arr.Length && arr[Fast] == num)
                {
                    Fast++;
                }
                int count = Fast - Slow;
                if (count == num)
                {
                    luckynumber = num;
                }
                Slow = Fast;

            }
            return luckynumber;
        }
        public static int LongestOnes(int[] nums, int k)//3 задание
        {
            int left = 0;
            int zeros = 0;
            int maxones = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] == 0)
                {
                    zeros++;
                }
                while (zeros > k)
                {
                    if (nums[left] == 0)
                    {
                        zeros--;
                    }
                    left++;
                }
                maxones = Math.Max(maxones, right - left + 1);
            }
            return maxones;
        }
    }
}