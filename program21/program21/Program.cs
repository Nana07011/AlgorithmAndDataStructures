using System;
namespace Program
{
    internal class Program
    {
        static int[]? TwoSum(int[] array, int target)
        {
            if (array == null || array.Length <= 1) return null;
            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                if (array[left] + array[right] > target)
                    right--;
                else
                {
                    if (array[left] + array[right] < target)
                        left++;
                    else return [left + 1, right + 1];
                }
            }
            return null;
        }
        static int[]? Square(int[] arr) // ctrl k ctrl d
        {
            if (arr == null) return null;
            if (arr.Length == 0) return arr;
            int[] res = new int[arr.Length];
            int left = 0, right = arr.Length - 1;
            for (int k = arr.Length - 1; left <= right; k--)
            {
                if (arr[left] * arr[left] < arr[right] * arr[right])
                {
                    res[k] = arr[right] * arr[right];
                    right--;
                }
                else res[k] = arr[left] * arr[left++];
            }
            return res;
        }
        static int? Counter(int[] arr, int k)
        {
            if (arr is null) return null;
            if ((arr.Length == 0)) return 0;

            int top = 0, bottom = 0;
            int max = 0, count = 0;
            while (top < arr.Length)
            {
                if (count <= k || arr[top++] == 1)
                {
                    top++;
                    if (arr[top] == 0)
                        count++;
                }
                else
                {

                }
            }
        }

        static void Main()
        {
            Counter();

            /*int[]? res1 = Square([-4,-1,0,3,10]);
            if (res1 is null)
                Console.WriteLine("error");
            else
            {
                foreach (int i in res1)
                    Console.WriteLine(i);
            }
            int[] mass = { 2, 7, 11, 15 };
            int[]? res = TwoSum(mass, 9);
            if (res is null)
                Console.WriteLine("Таких нет");
            else
            {
                Console.WriteLine(res[0] + " " + res[1]);
                Console.WriteLine();
                Console.WriteLine(mass[res[0] - 1] + " " + mass[res[1] - 1]);
            }*/
        }
    }
}