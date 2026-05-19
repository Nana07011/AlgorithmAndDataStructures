using System;
namespace prog10
{
    internal class Program
    {
        static void Main()
        {
            //Five();
            //Num(0.7);
            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //Console.WriteLine(Arr(arr));
            int[] nums = { 1, 2, 2, 4, 5, 5, 5, 7 };
            var res = num(nums);
            foreach (var i in res)
            {
                Console.WriteLine(i.Key+" : "+i.Value);
            }
            
        }
        /*static void Five()
        {
            Console.WriteLine(5);
        }*/
        /*static void Num(double n)
        {
            Console.WriteLine(n); 
        }*/
        /*static int Arr(int[] arr)
        {
            if (arr == null) return 0;
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
                sum += arr[i];
            return sum;
        }*/
        static Dictionary<int,int>? num (int[] arr)
        {
            if (arr is null || arr.Length == 0) return null;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int num in arr)
            {
                if (dic.ContainsKey(num)) dic[num]++;
                else dic[num] = 1;
            }
            return dic;
        }
    }
}
//метод напечатает на экран число 5
//метод печатает на экран передаваемое в этот метод вещественное число
//метод на вход получает целочисленный массив, возвращает сумму элементов этого массива
//словарь. приходит в метод массив, возвращает словаь, где в качестве ключа значения, сколько раз цифры встречаются