using System;
namespace kr31405
{
    internal class Program //Иманбаева Жасмина 110б
    {
        static int Solution(int[] nums)
        {
            var set = new HashSet<int>(nums);
            for(int i = 0; i <= nums.Length; i++)
            {
                if(!set.Contains(i)) return i;
            }
            return 0;
        }
        static void Main()
        {
            int[] nums = { 3, 0, 1 }; //2
            int[] nums1 = { 0, 2, 4, 6, 8, 1, 3, 7, 9 }; //5
            int[] nums2 = { 0,1,2,3,6,5,7,8,9,10,}; //4
            Console.WriteLine("Ответ nums1: " + Solution(nums));
            Console.WriteLine("Ответ nums2: " + Solution(nums1));
            Console.WriteLine("Ответ nums3: " + Solution(nums2));
        }
    }
}