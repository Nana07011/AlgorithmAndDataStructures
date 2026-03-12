using System;
namespace Program
{
    internal class Program
    {
        //вариант 1
        static void Main()
        {
            int[] num = { 1, 2, 3, 4, 5 };
            int sec = FindSecondMax(num);
            Console.WriteLine($"Второй по величине элемент: {sec}"); //1.5 задача
            int F = 5;
            Console.WriteLine($"Факториал: {GetFactorial(F)}"); //2.5 задача
        }
        static int FindSecondMax(int[] nums) // 1 метод 1 задание
        {
            if (nums == null || nums.Length == 0) return int.MinValue;
            int maxel = int.MinValue;
            int secondel = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > maxel)
                {
                    maxel = nums[i];
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > secondel && nums[i] != maxel)
                {
                    secondel = nums[i];
                }
            }
            return secondel;
        }
        static int GetFactorial(int n) // 2 метод 2 задание
        {
            if (n < 0) return -1;
            if (n == 0) return 1;
            int fact = 1;
            for (int i = 2; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }
    }
}