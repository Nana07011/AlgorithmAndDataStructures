using System;
namespace ControlTaskTwoPointers
{
    internal class Program
    {
        static void Main() //Иманбаева Жасмина 110б
        {
            int[]? array = null;
            int[] arr = [];
            int[] arr1 = { -1, 3, 3, 45, 50 };
            int[] arr2 = { -1, 3, 3, 45, 50 };
            int[] arr3 = { -10, 3, 6, 34, 70 };
            int[] arr4 = { -1, 2, 4, 6, 20 };
            int[] arr5 = { 1, 2, 7, 11 };

            int[]? result = TargetSum(array,4);
            int[]? res = TargetSum(arr, 2);
            int[]? res1 = TargetSum(arr1, 100);
            int[]? res2 = TargetSum(arr2, -1);
            int[]? res3 = TargetSum(arr3, 37);
            int[]? res4 = TargetSum(arr4, 11);
            int[]? res5 = TargetSum(arr5, 9);

            foreach (int i in res3)
                Console.WriteLine(i);
        }
        static int[]? TargetSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return null;
            int n = nums.Length;
            int sum = 0;
            int left = 0, right = nums.Length - 1;
            if (nums[n - 1] <= target || nums[0] >= target) return null;
            for (int i  = 0; i < nums.Length; i++)
            {
                sum = nums[left] + nums[right];
                if (sum == target) return new int[] { nums[left], nums[right] };
                else if (sum >= target) right--;
                else left++;
            }
            return null;
        }
    }
}