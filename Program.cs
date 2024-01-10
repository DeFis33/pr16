//***************************************************************************************************
//* Практическая работа № 16                                                                        *
//* Выполнил: Пирогов Д., группа 2ИСП                                                               *
//* Задание: разработать программу алгоритма решения задачи, используя библиотеки работы с файлами  *
//***************************************************************************************************

using System.IO;
using System;

namespace pr16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath;
            double product = 1.0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Практическая работа № 16.");
            Console.WriteLine("Введите путь к сохраненному файлу и укажите имя файла, \n\tнапример: D:\\Users\\1213-5\\Documents\\2-ИСП\\Дисциплина\\Основы программирования\\Фамилия\\Пирогов Д\\pr16\\pr16.txt");
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
                    Console.Write("\nВведите кол-во чисел: ");
                    int M = Int32.Parse(Console.ReadLine());
                    double[] Mas = new double[M];

                    for (int i = 0; i < M; i++)
                    {
                        Mas[i] = (rnd.NextDouble() * 20) - 10; // Генерация числа в интервале [-10, 10]
                        Mas[i] = Math.Round(Mas[i], 1);
                        if (i % 2 != 0) product *= Mas[i];
                        product = Math.Round(product, 1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Mas[i] + "\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        writer.Write(Mas[i] + "\n");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Произведение элементов с нечетными номерами: " + product);
                    Console.ForegroundColor = ConsoleColor.White;
                    writer.Close();
                }
                catch (IOException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка открытия/записи файла. Проверьте месторасположение файла!\n", e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException fe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата числа: {0}", fe.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата числа: {0}", e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                double[] mas = null;
                string s;
                try
                {
                    FileStream F1 = new FileStream(filepath, FileMode.Open);
                    StreamReader reader = new StreamReader(F1);
                    while ((s = reader.ReadLine()) != null) 
                    {
                        s = s.TrimEnd(' ');
                        string[] text = s.Split(' ');
                        for (int j = 0; j < text.Length; j++)
                        {
                            mas[j] = Convert.ToDouble(text[j]);
                        }
                    }
                    F1.Close();
                }
                catch (IOException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка открытия/записи файла. Проверьте месторасположение файла!\n", e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (FormatException fe)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата числа: {0}", fe.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка формата числа: {0}", e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.ReadKey();
        }
    }
}
// нужно, чтобы файл еще и считывался, а потом уже выводил произведение
