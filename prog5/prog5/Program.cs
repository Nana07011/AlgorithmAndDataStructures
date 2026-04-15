using System;
namespace Program
{
    internal class Program
    {
        static int Solution2(int[] arr, int k)
        {
            if (arr is null || arr.Length == 0) return 0;
            int top = 0; int bottom = 0;
            int max = 0;
            int tmp = arr[0] == 0 ? 1 : 0;
            while (top < arr.Length - 1)
            {
                if (tmp < k || tmp == k && arr[top + 1] == 1)
                {
                    top++;
                    if (arr[top] == 0)
                        tmp += 1;
                }
                else
                {
                    max = Math.Max(max, top - bottom + 1);
                    if (arr[bottom] == 0)
                    {
                        tmp--;
                    }
                    bottom++;
                }
            }
            return max > top-bottom+1? max:top - bottom + 1;
        }
        static void Main()
        {
            //int a = Solution2([0,0,1,0], 2);
            //Console.WriteLine(a + "3");
            //int[] newarr = Generate();
            //int b = Solution2(newarr, 2);
            //Console.WriteLine("Результат Solution: " + b);
            //Console.WriteLine("Результат Generate: ");
            //foreach (int i in newarr)
                //Console.WriteLine(i);
            for (int i = 0;  i < 5; i++)
            {
                Random random = new Random();
                int k = random.Next(0, 5);
                int[] newarr = Generate();
                int b = Solution2(newarr, k);
                Console.WriteLine("Результат Solution: " + b + ", k = " + k);
                foreach (int n in newarr)
                    Console.Write(n + " ");
                Console.WriteLine();
            }
        }
        //написать метод, который возвращает заполненный случайно массив из 0 и 1 длина генерируется внутри метода
        //и в мейн написать цикл на 5 проверок функции т.е.  вызываем метод Generate и передаем его в Solution 
        //затем печатаем на экран результат Generate и результат Solution
        static int[] Generate()
        {
           Random random = new Random();
        int Length = random.Next(0, 16);
        int[] Array = new int[Length];
        for(int i = 0; i < Length; i++)
            {
                Array[i] = random.Next(0,2);
            }
        return Array;
        }
    }
}