using System;
using System.Linq;

namespace Practice_27_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
        }
        static void Exercise1()
        {
            double[] A = new double[5];
            double[,] B = new double[3, 4];
            double composAB = 1;
            double sumA = 0;
            double sumB = 0;

            Random rand = new Random();

            try
            {
                Console.WriteLine("Заполнение массива А");

                for (int i = 0; i < A.Length; i++)
                {
                    Console.WriteLine($"ведите {i} элемент массива А");
                    A[i] = Convert.ToDouble(Console.ReadLine());
                    composAB = composAB * A[i];

                    if (i % 2 == 0)
                    {
                        sumA += A[i];
                    }
                    Console.Clear();
                }
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = Math.Round(rand.NextDouble(), 2) + rand.Next(10);
                        composAB = composAB * B[i, j];

                        if (j % 2 != 0)
                        {
                            sumB += B[i, j];
                        }
                    }
                }

                Console.WriteLine("Массив А");
                for (int i = 0; i < A.Length; i++)
                {
                    Console.Write($"{A[i]}" + "\t");
                }

                Console.WriteLine();
                Console.WriteLine("Массив B");
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        Console.Write($"{B[i, j]}" + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.WriteLine("Максимальный элемент массива А = " + A.Max());
                Console.WriteLine("Максимальный элемент массива B = " + B.Cast<double>().Max());

                if (B.Cast<double>().Contains(A.Max()))
                {
                    Console.WriteLine("Максимальный общий элемент в массивах = " + A.Max());
                }
                else
                {
                    Console.WriteLine("Общего максимального элемента в массивах нет ");
                }

                Console.WriteLine("Минимальный элемент массива А = " + A.Min());
                Console.WriteLine("Минимальный элемент массива B = " + B.Cast<double>().Min());

                if (A.Min() == B.Cast<double>().Min())
                {
                    Console.WriteLine("Минимальный общий элемент в массивах = " + A.Min());
                }
                else
                {
                    Console.WriteLine("Общего минимального элемента в массивах нет ");
                }

                Console.WriteLine("Сумма элементов массивов = " + (A.Sum() + B.Cast<double>().Sum()));
                Console.WriteLine("Общее произведение элементов массивов = " + composAB);
                Console.WriteLine("Cуммa четных элементов массива А = " + sumA);
                Console.WriteLine("Cуммa нечетных столбцов массива В = " + sumB);

            }
            catch (Exception)
            {
                Console.WriteLine("Завершение программы");
                Environment.Exit(0);
            }
        }
        static void Exercise2()
        {
            Console.WriteLine("Введите размерность массива");

            Console.WriteLine("Введите М");
            var valueM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите N");
            var valueN = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();

            int count = 0;
            int[] A = new int[valueM];
            int[] B = new int[valueN];

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(15);
            }
            for (int i = 0; i < B.Length; i++)
            {
                B[i] = rand.Next(15);
                for (int j = 0; j < A.Length; j++)
                {
                    if (B[i] == A[j])
                    {
                        count++;
                    }
                }
            }

            PrintArray("Массив A", A);
            PrintArray("Массив B", B);
            if (count != 0)
            {
                int[] AB = new int[count];
                int z = 0;

                for (int i = 0; i < B.Length; i++)
                {
                    for (int j = 0; j < A.Length; j++)
                    {
                        if ((B[i] == A[j]) && (!AB.Contains(B[i])))
                        {
                            AB[z] = B[i];
                            z++;
                        }
                    }
                }

                Array.Resize(ref AB, z);
                PrintArray("Массив общий", AB);
            }
            else
            {
                Console.WriteLine("Общих элементов в массивах нет");
            }
        }
        static void Exercise3()
        {
            Console.WriteLine("Введите строку для проверки является ли она палиндромом");

            string str = Console.ReadLine();
            char[] temp = new char[str.Length];
            int j = 0, countNull = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    countNull++;
                    continue;
                }
                temp[j] = str[i];
                j++;
            }
            Array.Resize(ref temp, str.Length - countNull);
            string output = new string(temp);
            Console.Clear();
            Console.WriteLine(str);

            str = output;
            output = new string(output.ToCharArray().Reverse().ToArray());

            if (String.Compare(str, output, true) == 0)
            {
                Console.WriteLine("Строка ЯВЛЯЕТСЯ палиндромом");
            }
            else
            {
                Console.WriteLine("Строка НЕ ЯВЛЯЕТСЯ палиндромом");
            }
        }
        static void Exercise4()
        {
            Console.WriteLine("Введите предложение для подсчета слов");
            string str = Console.ReadLine();

            Console.Clear();
            Console.WriteLine(str);
 
            string[] strArr = str.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Количество слов в предложении = " + strArr.Length);
        }
        static void Exercise5()
        {
            int[,] B = new int[5, 5];
            int sumB = 0, max = B[0, 0], min = B[0, 0];
            int ni = 0, mj = 0, ki = 0, lj = 0;
            bool count = false;
            Random rand = new Random();

            try
            {
                Console.WriteLine("Заполнение массива А");
                Console.WriteLine("Массив B");
                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        B[i, j] = rand.Next(-100, 100);

                        if (max < B[i, j])
                        {
                            max = B[i, j];
                            ni = i;
                            mj = j;
                        }

                        if (min > B[i, j])
                        {
                            min = B[i, j];
                            ki = i;
                            lj = j;
                        }
                        Console.Write($"{B[i, j]}\t");
                    }
                    Console.WriteLine();
                }

                for (int i = 0; i < B.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        if ((i == ni && j == mj) || (i == ki && j == lj))
                        {
                            if (count)
                            {
                                count = false;
                                continue;
                            }
                            else
                            {
                                count = true;
                                continue;
                            }
                        }
                        if (count)
                        {
                            sumB += B[i, j];
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Максимальный элемент массива B = " + max);
                Console.WriteLine("Минимальный элемент массива B = " + min);
                Console.WriteLine($"Максимальный элемент {B.Cast<int>().Max()} находится в массиве строка {ni + 1} столбец {mj + 1} позиции");
                Console.WriteLine($"Минимальный элемент {B.Cast<int>().Min()} находится в массиве строка {ki + 1} столбец {lj + 1} позиции");

                Console.WriteLine("Cуммa элементов массива, расположенных между минимальным и максимальным элементами = " + sumB);
            }
            catch (Exception)
            {
                Console.WriteLine("Завершение программы");
                Environment.Exit(0);
            }
        }
        static void PrintArray(string text, int[] arr)
        {
            Console.WriteLine(text + ": ");
            for (int A = 0; A < arr.Length; A++)
            {
                Console.Write(arr[A] + "\t");
            }
            Console.WriteLine();
        }
    }
}
