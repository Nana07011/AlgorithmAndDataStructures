namespace Program1
{
    internal class Program
    {
        /// <summary>
        /// Вход в программу. Запуск игры "Угадай число"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game();
        }
        /// <summary>
        /// Основной цикл.Управляет процессом игры,
        /// отслеживает результаты игр, обрабатывает повторные попытки.
        /// </summary>
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
                        CountAttemps(ref min, ref max, ref counter, ref countGame, ref count);
                        break;
                    }


                }
                answer = PlayAgain();
            }
            while (answer == 'Y');
            Results(ref min, ref max, ref count, ref countGame);


        }
        /// <summary>
        /// Получает и обрабатывает число, введенное пользователем.
        /// </summary>
        /// <returns></returns> Возвращает число пользователя в диапазоне от 1 до 100
        /// или завершает программу, если пользователь ввел не те данные 3 раза.
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
        /// <summary>
        /// Сравнивает число пользователя с загаданным числом.
        /// </summary>
        /// <param name="userNumber"></param> Число, введенное пользователем
        /// <param name="number"></param> Загаданное число
        /// <returns></returns> Возвращает false, если пользователь не угадывает число, True - если угадал
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
        /// <summary>
        /// Рассчитывает результаты игры: минимальное, максимальное количество попыток, а также общее число игр.
        /// </summary>
        /// <param name="min"></param> Минимальное количество попыток
        /// <param name="max"></param> Максимальное количество попыток
        /// <param name="counter"></param> Количество попыток в текущей игре
        /// <param name="countGame"></param> Общее количество сыгранных игр
        /// <param name="count"></param> Общее число попыток
        static void CountAttemps(ref int min, ref int max, ref int counter, ref int countGame, ref int count)
        {
            if (min == 0 || min > counter) min = counter;
            max = max < counter ? counter : max;
            countGame++;
            count += counter;
        }
        /// <summary>
        /// Запрашивает у пользователя хочет ли он сыграть снова
        /// </summary>
        /// <returns></returns> символ введенный пользователем
        static char PlayAgain()
        {
            Console.WriteLine("Do you want to play again?");
            return Convert.ToChar(Console.Read());
        }
        /// <summary>
        /// Выводит результат за все партии игр
        /// </summary>
        /// <param name="min"></param>Минимальное количество попыток
        /// <param name="max"></param>Максимальное количество попыток
        /// <param name="count"></param>Общее число попыток
        /// <param name="countGame"></param>Общее количество сыгранных игр
        /// Выводит на экран минимальное, максимальное и среднее количество попыток.
        static void Results(ref int min, ref int max, ref int count, ref int countGame)
        {
            Console.WriteLine($"min = {min} max = {max} avg = {count * 1.0 / countGame}");
        }
    }
}