namespace Program1
{
    internal class Program
    {
        //метод мейн, вызов программы
        static void Main(string[] args)
        {
            Game();
        }
        //1 метод основная логика и алгоритм игры, где включены все другие методы
        static void Game()
        {
            int min = 0;
            int max = 0;
            int count = 0;
            int countGame = 0;

            Random rnd = new Random();
            char answer = 'Y';
            do
            {
                int counter = 0;
                int number = rnd.Next(1, 101);
                while (true)
                {
                    counter++;
                    int UserNumber = GetNumber();

                    if (CheckNumbers(UserNumber, number))
                    {
                        Console.WriteLine("You win");
                        CountAttemps(ref min,ref max,ref counter,ref countGame,ref count);
                        break;
                    }


                }
                answer = PlayAgain();
            }
            while (answer == 'Y');
            Results(ref min,ref max,ref count,ref countGame);


        }
        //2 метод, где мы считываем число от пользователя
        static int GetNumber()
        {
            Console.WriteLine("Input number from [1,100]");
            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out int UserNumber)
                || UserNumber > 100 || UserNumber < 1)
                    Console.WriteLine("Input number from [1,100]");
                else
                    return UserNumber;
                if (i == 2)
                {
                    Console.WriteLine("You are dumb");
                    Environment.Exit(0);
                }
            }
            return 0;
        }
        //3 метод проверки числа
        static bool CheckNumbers(int userNumber, int number)
        {
            if (userNumber > number)
            {
                Console.WriteLine("Your number is greater");
                return false;
            }

            else if (userNumber < number)
            {
                Console.WriteLine("Your number is less");
                return false;
            }
            return true;
        }
        //4 метод рассчет количества попыток, а также их мин и макс значение
        static void CountAttemps(ref int min,ref int max,ref int counter,ref int countGame,ref int count)
        {
            if (min == 0 || min > counter) min = counter;
            max = max < counter ? counter : max;
            countGame++;
            count += counter;
        }
        //5 метод проверка, хочет ли пользователь поиграть еще раз
        static char PlayAgain()
        {
            Console.WriteLine("Do you want to play again?");
            return Convert.ToChar(Console.Read());
        }
        //6 метод вывод результатов на экран по окончании игры
        static void Results(ref int min, ref int max, ref int count, ref int countGame)
        {
            Console.WriteLine($"min = {min} max = { max} avg = {count *1.0/countGame}");
        }
    }
}