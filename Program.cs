//***************************************************************************************************
//* Практическая работа № 16                                                                        *
//* Выполнил: Пирогов Д., группа 2ИСП                                                               *
//* Задание: разработать программу алгоритма решения задачи, используя библиотеки работы с файлами  *
//***************************************************************************************************

namespace pr16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath;
            int M = 3, N = 3;
            double product = 1.0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Практическая работа № 16.");
            Console.WriteLine("Введите путь к сохраненному файлу и укажите имя файла, \n\tнапример: C:\\Users\\Denis\\source\\repos\\pr16\\pr16.txt");
            filepath = Console.ReadLine();

            if (String.IsNullOrEmpty(filepath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вы ввели пустой путь к файлу.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                try
                {
                    FileStream F = new FileStream(filepath, FileMode.Create);
                    StreamWriter writer = new StreamWriter(F);
                    Random rnd = new Random();
                    double[,] Mas = new double[M, N];

                    for (int i = 0; i < M; i++)
                    {
                        for (int j = 0; j < N; j++)
                        {
                            Mas[i, j] = (rnd.NextDouble() * 20) - 10; // Генерация числа в интервале [-10, 10]

                            if (j % 2 != 0) product *= Mas[i, j];

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Mas[i, j] + "\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            writer.Write(Mas[i, j] + "\n");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Произведение элементов с нечетными номерами: " + product);
                    Console.ForegroundColor = ConsoleColor.White;
                    writer.Write("Произведение элементов с нечетными номерами: " + product);
                    writer.Close();
                }
                catch (IOException e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка открытия/записи файла. Проверьте месторасположение файла!\n", e.Message);
                    Console.BackgroundColor = ConsoleColor.White;
                }
                catch (FormatException fe)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата числа: {0}", fe.Message);
                    Console.BackgroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
