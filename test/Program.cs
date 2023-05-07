using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadCalculationulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Впишіть тип програми: \n 1)Самостійне введення даних(обчислення без потоків) \n 2)Рандомне введення даних(обчислення без потоків) \n " +
                "3)Самостійне введення даних(Обчислення одним потоком) \n 4)Самостійне введення даних(Обчислення двома потоками) \n " +
                "5)Рандомне введення даних(Обчислення одним потоком) \n 6)Рандомне введення даних(Обчислення двома потоками) \n 7)Рандомне введення даних (багато потоків)");
            int Input = Convert.ToInt32(Console.ReadLine());
            switch (Input)
            {
                case 1:
                    CalculationDataEntry();
                    break;
                case 2:
                    CalculationDataRandom();
                    break;
                case 3:
                    ThreadCalculationDataEntry();
                    break;
                case 4:
                    ThreadCalculationDataEntryTy();
                    break;
                case 5:
                    ThreadCalculationDataRandom();
                    break;
                case 6:
                    ThreadCalculationDataRandomTy();
                    break;
                case 7:
                    ThreadCalculationDataRandomLot();
                    break;
            }
        }
        static void CalculationDataEntry()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());

            // Створюємо матриці і заповнюємо її значеннями, введеними користувачем
            Console.WriteLine("Значення для матриці A");
            int[,] A = new int[n, n + 3];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A1");
            int[,] A1 = new int[n, n + 3];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A2");
            int[,] A2 = new int[n, n + 3];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці B2");
            int[,] B2 = new int[n, n + 3];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    B2[i, j] = int.Parse(Console.ReadLine());
                }
            }



            /*1).Задати* квадратну матрицю А порядку n. Отримати вектор(стовпець) 
             * y1A*b, де b – вектор-стовпець, елементи якого обраховуються за формулою, 
             * згідно варіанту.*/
            double[] b = new double[n];//bi=4/(i3+3)
            for (int i = 0; i < n; i++)
            {
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }

            double[] y1 = new double[n];//y1=A*b
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y1[i] += A[i, j] * b[j];
                }
            }

            /*2).Задати квадратну матрицю А1 порядку n та вектори-стовпці 
             * b1 та c1 з n елементами кожен. Отримати вектор y2 згідно формули, 
             * що задається варіантом.
             */
            double[] b1 = new double[n];//bi=4/(i3+3)
            for (int i = 0; i < n; i++)
            {
                b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            double[,] c1 = new double[n, n];//Cij=1/(i+j2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            double[] y2 = new double[n];//A1(b1+4c1)
            for (int i = 0; i < n; i++)
            {
                y2[i] = 0;

                for (int j = 0; j < n; j++)
                {
                    y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                }
            }
            /*
             3).Задати квадратні матриці А2 та B2 порядку n. 
            Отримати матрицю Y3, яка залежить від А2, B2 та додатково 
            визначеної матриці С2, елементи якої знаходяться за формулою, 
            вказаною варіантом.             
             */
            double[,] C2 = new double[n, n];//Cij=1/(i+j2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            double[,] Y3 = new double[n, n];//A2(B2-C2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                }
            }
            //Знаходження Х
            double[,] x = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                }
            }



            //Виводимо матриці та вектори-стовпці на екран
            Console.WriteLine("Введені матриці:");
            Console.WriteLine("Матриця A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця B2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B2[i, j] + " ");
                }
                Console.WriteLine();
            }
            //


            Console.WriteLine("Обчислені за формулами:");
            //1
            Console.WriteLine("Масив b:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b[i]);
                Console.WriteLine($"b[{i}] = {result}");
            }

            Console.WriteLine("Матриця y1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //2
            Console.WriteLine("Масив b1:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b1[i]);
                Console.WriteLine($"b1[{i}] = {result}");
            }
            Console.WriteLine("Матриця c1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", c1[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця y2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y2[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //3
            Console.WriteLine("Матриця C2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", C2[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця Y3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", Y3[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //x
            Console.WriteLine("Матриця x:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", x[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
        static void CalculationDataRandom()
        {
            Stopwatch stopwatch = new Stopwatch();//Таймер

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());

            //Створюємо матриці і заповнюємо її випадковими значеннями в діапазоні від 0 до 10
            int[,] A = GenerateRandomMatrix(n);
            int[,] A1 = GenerateRandomMatrix(n);
            int[,] A2 = GenerateRandomMatrix(n);
            int[,] B2 = GenerateRandomMatrix(n);

            static int[,] GenerateRandomMatrix(int n)
            {
                int[,] matrix = new int[n, n + 3];
                Random rand = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = rand.Next(0, 11);
                    }
                }
                return matrix;
            }
            /*1).Задати* квадратну матрицю А порядку n. Отримати вектор(стовпець) 
             * y1A*b, де b – вектор-стовпець, елементи якого обраховуються за формулою, 
             * згідно варіанту.*/
            double[] b = new double[n];//bi=4/(i3+3)
            for (int i = 0; i < n; i++)
            {
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }

            double[] y1 = new double[n];//y1=A*b
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y1[i] += A[i, j] * b[j];
                }
            }

            /*2).Задати квадратну матрицю А1 порядку n та вектори-стовпці 
             * b1 та c1 з n елементами кожен. Отримати вектор y2 згідно формули, 
             * що задається варіантом.
             */
            double[] b1 = new double[n];//bi=4/(i3+3)
            for (int i = 0; i < n; i++)
            {
                b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            double[,] c1 = new double[n, n];//Cij=1/(i+j2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            double[] y2 = new double[n];//A1(b1+4c1)
            for (int i = 0; i < n; i++)
            {
                y2[i] = 0;

                for (int j = 0; j < n; j++)
                {
                    y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                }
            }
            /*
             3).Задати квадратні матриці А2 та B2 порядку n. 
            Отримати матрицю Y3, яка залежить від А2, B2 та додатково 
            визначеної матриці С2, елементи якої знаходяться за формулою, 
            вказаною варіантом.             
             */
            double[,] C2 = new double[n, n];//Cij=1/(i+j2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            double[,] Y3 = new double[n, n];//A2(B2-C2)
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                }
            }
            //Знаходження Х
            double[,] x = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                }
            }



            //Виводимо матриці та вектори-стовпці на екран
            Console.WriteLine("Виведення матриць:");
            Console.WriteLine("Матриця A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця B2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B2[i, j] + " ");
                }
                Console.WriteLine();
            }



            Console.WriteLine("Обчислені за формулами:");
            //1
            Console.WriteLine("Масив b:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b[i]);
                Console.WriteLine($"b[{i}] = {result}");
            }

            Console.WriteLine("Матриця y1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //2
            Console.WriteLine("Масив b1:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b1[i]);
                Console.WriteLine($"b1[{i}] = {result}");
            }
            Console.WriteLine("Матриця c1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", c1[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця y2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y2[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //3
            Console.WriteLine("Матриця C2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", C2[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця Y3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", Y3[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //x
            Console.WriteLine("Матриця x:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", x[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        } 
        static void ThreadCalculationDataEntry()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());
            // Створюємо матриці і заповнюємо її значеннями            
            int[,] A = new int[n, n + 3];
            int[,] A1 = new int[n, n + 3];
            int[,] A2 = new int[n, n + 3];
            int[,] B2 = new int[n, n + 3];
            double[] b = new double[n];
            double[] y1 = new double[n];
            double[] b1 = new double[n];
            double[,] c1 = new double[n, n];
            double[] y2 = new double[n];
            double[,] C2 = new double[n, n];
            double[,] Y3 = new double[n, n];
            double[,] x = new double[n, n];

            // Створюємо матриці і заповнюємо її значеннями, введеними користувачем
            Console.WriteLine("Значення для матриці A");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A1");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A2");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці B2");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    B2[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Thread thread1 = new Thread(() =>
            {
                /*1).Задати* квадратну матрицю А порядку n. Отримати вектор(стовпець) 
                * y1A*b, де b – вектор-стовпець, елементи якого обраховуються за формулою, 
                * згідно варіанту.*/
                for (int i = 0; i < n; i++)
                {
                    b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
                    for (int j = 0; j < n; j++)
                    {
                        y1[i] += A[i, j] * b[j];
                    }
                }
                /*2).Задати квадратну матрицю А1 порядку n та вектори-стовпці 
                * b1 та c1 з n елементами кожен. Отримати вектор y2 згідно формули, 
                * що задається варіантом.*/         
                for (int i = 0; i < n; i++)
                {
                    b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
                    y2[i] = 0;
                    for (int j = 0; j < n; j++)
                    {
                        c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                        y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                    }
                }
                /* 3).Задати квадратні матриці А2 та B2 порядку n. 
                   Отримати матрицю Y3, яка залежить від А2, B2 та додатково 
                   визначеної матриці С2, елементи якої знаходяться за формулою, 
                   вказаною варіантом. */ 
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                        Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                    }
                }
                // Знаходження Х
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                    }
                }
            });            
            thread1.Start();

            // Виводимо матриці та вектори-стовпці на екран
            Console.WriteLine("Згенеровані матриці матриці:");
            Console.WriteLine("Матриця A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця B2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Обчислені за формулами:");
            // 1
            Console.WriteLine("Масив b:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b[i]);
                Console.WriteLine($"b[{i}] = {result}");
            }
            Console.WriteLine("Матриця y1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            // 2
            Console.WriteLine("Масив b1:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b1[i]);
                Console.WriteLine($"b1[{i}] = {result}");
            }
            Console.WriteLine("Матриця c1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", c1[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця y2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y2[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            // 3
            Console.WriteLine("Матриця C2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", C2[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця Y3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", Y3[i, j]);
                    Console.Write(result + " ");
                }
            }
            //x
            Console.WriteLine("\nМатриця x:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", x[i, j]);
                    Console.Write(result + " ");
                }
            }
            thread1.Join();
            stopwatch.Stop();
            Console.WriteLine("\nЧас виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
        static void ThreadCalculationDataEntryTy()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());

            int[,] A = new int[n, n + 3];
            int[,] A1 = new int[n, n + 3];
            int[,] A2 = new int[n, n + 3];
            int[,] B2 = new int[n, n + 3];
            double[] b = new double[n];
            double[] y1 = new double[n];
            double[] b1 = new double[n];
            double[,] c1 = new double[n, n];
            double[] y2 = new double[n];
            double[,] C2 = new double[n, n];
            double[,] Y3 = new double[n, n];
            double[,] x = new double[n, n];

            // Створюємо матриці і заповнюємо її значеннями, введеними користувачем
            Console.WriteLine("Значення для матриці A");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A1");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A1[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці A2");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    A2[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Значення для матриці B2");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введіть значення для рядка матриці {i + 1}:");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Елемент [{i}, {j}]: ");
                    B2[i, j] = int.Parse(Console.ReadLine());
                }
            }



            /*1).Задати* квадратну матрицю А порядку n. Отримати вектор(стовпець) 
            * y1A*b, де b – вектор-стовпець, елементи якого обраховуються за формулою, 
            * згідно варіанту.*/
            for (int i = 0; i < n; i++)
            {
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y1[i] += A[i, j] * b[j];
                }
            }

            /*2).Задати квадратну матрицю А1 порядку n та вектори-стовпці 
             * b1 та c1 з n елементами кожен. Отримати вектор y2 згідно формули, 
             * що задається варіантом.
             */
            for (int i = 0; i < n; i++)
            {
                b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                }
            }
            /*
             3).Задати квадратні матриці А2 та B2 порядку n. 
            Отримати матрицю Y3, яка залежить від А2, B2 та додатково 
            визначеної матриці С2, елементи якої знаходяться за формулою, 
            вказаною варіантом.             
             */
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                }
            }
            //Знаходження Х
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                }
            }

            //Потік 1
            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Введені матриці:");
                Console.WriteLine("Матриця A:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A1[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця B2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(B2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                //
            });
            thread1.Start(); // Запускаємо потік 1
            thread1.Join(); // Очікуємо завершення потоку 1
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Обчислені за формулами:");
                //1
                Console.WriteLine("Масив b:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b[i]);
                    Console.WriteLine($"b[{i}] = {result}");
                }

                Console.WriteLine("Матриця y1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", y1[i]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //2
                Console.WriteLine("Масив b1:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b1[i]);
                    Console.WriteLine($"b1[{i}] = {result}");
                }
                Console.WriteLine("Матриця c1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", c1[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця y2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", y2[i]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //3
                Console.WriteLine("Матриця C2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", C2[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця Y3:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", Y3[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //x
                Console.WriteLine("Матриця x:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", x[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
            });
            thread2.Start(); // Запускаємо потік 2            
            thread2.Join(); // Очікуємо завершення потоку 2
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
        static void ThreadCalculationDataRandom()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());

            // Створюємо матриці і заповнюємо її значеннями            
            int[,] A = new int[n, n + 3];
            int[,] A1 = new int[n, n + 3];
            int[,] A2 = new int[n, n + 3];
            int[,] B2 = new int[n, n + 3];
            double[] b = new double[n];
            double[] y1 = new double[n];
            double[] b1 = new double[n];
            double[,] c1 = new double[n, n];
            double[] y2 = new double[n];
            double[,] C2 = new double[n, n];
            double[,] Y3 = new double[n, n];
            double[,] x = new double[n, n];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A1[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A2[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B2[i, j] = rand.Next(0, 11);
                }
            }

            Thread thread1 = new Thread(() =>
            {
                // 1). Задати квадратну матрицю А порядку n та отримати вектор y1 = A * b
                for (int i = 0; i < n; i++)
                {
                    b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        y1[i] += A[i, j] * b[j];
                    }
                }
                // 2). Задати квадратну матрицю А1 порядку n та отримати вектор y2 згідно формули
                for (int i = 0; i < n; i++)
                {
                    b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                    }
                }
                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < n; j++)
                    {
                        y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                    }
                }
                // 3). Задати квадратні матриці А2 та B2 порядку n та отримати матрицю Y3
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                    }
                }

                // Знаходження Х
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                    }
                }

            });            
            thread1.Start();
            thread1.Join();
            // Виводимо матриці та вектори-стовпці на екран
            Console.WriteLine("Рандомні матриці:");
            Console.WriteLine("Матриця A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця A2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(A2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця B2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(B2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Обчислені за формулами:");
            //1
            Console.WriteLine("Масив b:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b[i]);
                Console.WriteLine($"b[{i}] = {result}");
            }

            Console.WriteLine("Матриця y1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //2
            Console.WriteLine("Масив b1:");
            for (int i = 0; i < n; i++)
            {
                string result = string.Format("{0:f3}", b1[i]);
                Console.WriteLine($"b1[{i}] = {result}");
            }
            Console.WriteLine("Матриця c1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", c1[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця y2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", y2[i]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //3
            Console.WriteLine("Матриця C2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", C2[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця Y3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", Y3[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }
            //x
            Console.WriteLine("Матриця x:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string result = string.Format("{0:f3}", x[i, j]);
                    Console.Write(result + " ");
                }
                Console.WriteLine();
            }            
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
        static void ThreadCalculationDataRandomTy()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());
            Random rand = new Random();


            int[,] A = new int[n, n + 3];
            int[,] A1 = new int[n, n + 3];
            int[,] A2 = new int[n, n + 3];
            int[,] B2 = new int[n, n + 3];
            double[] b = new double[n];
            double[] y1 = new double[n];
            double[] b1 = new double[n];
            double[,] c1 = new double[n, n];
            double[] y2 = new double[n];
            double[,] C2 = new double[n, n];
            double[,] Y3 = new double[n, n];
            double[,] x = new double[n, n];

            // Створюємо матриці і заповнюємо її значеннями, введеними користувачем
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A1[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A2[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B2[i, j] = rand.Next(0, 11);
                }
            }

            /*1).Задати* квадратну матрицю А порядку n. Отримати вектор(стовпець) 
            * y1A*b, де b – вектор-стовпець, елементи якого обраховуються за формулою, 
            * згідно варіанту.*/
            for (int i = 0; i < n; i++)
            {
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    y1[i] += A[i, j] * b[j];
                }
            }

            /*2).Задати квадратну матрицю А1 порядку n та вектори-стовпці 
             * b1 та c1 з n елементами кожен. Отримати вектор y2 згідно формули, 
             * що задається варіантом.
             */
            for (int i = 0; i < n; i++)
            {
                b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    y2[i] += A1[i, j] * (b1[j] + 4 * c1[i, j]);
                }
            }
            /*
             3).Задати квадратні матриці А2 та B2 порядку n. 
            Отримати матрицю Y3, яка залежить від А2, B2 та додатково 
            визначеної матриці С2, елементи якої знаходяться за формулою, 
            вказаною варіантом.             
             */
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Y3[i, j] = A2[i, j] * (B2[i, j] - C2[i, j]);
                }
            }
            //Знаходження Х
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i, j] = Y3[i, j] * y2[i] + Math.Pow(Y3[i, j], 3) - Y3[i, j] * y1[i] * y2[i] + Math.Pow(Y3[i, j], 2) * y1[i];
                }
            }

            //Потік 1
            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Введені матриці:");
                Console.WriteLine("Матриця A:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A1[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця B2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(B2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                //
            });
            thread1.Start(); // Запускаємо потік 1
            thread1.Join(); // Очікуємо завершення потоку 1
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Обчислені за формулами:");
                //1
                Console.WriteLine("Масив b:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b[i]);
                    Console.WriteLine($"b[{i}] = {result}");
                }

                Console.WriteLine("Матриця y1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", y1[i]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //2
                Console.WriteLine("Масив b1:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b1[i]);
                    Console.WriteLine($"b1[{i}] = {result}");
                }
                Console.WriteLine("Матриця c1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", c1[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця y2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", y2[i]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //3
                Console.WriteLine("Матриця C2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", C2[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця Y3:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", Y3[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //x
                Console.WriteLine("Матриця x:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", x[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
            });
            thread2.Start(); // Запускаємо потік 2            
            thread2.Join(); // Очікуємо завершення потоку 2
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
        static void ThreadCalculationDataRandomLot()
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Console.Write("Введіть розмірність матриць n: ");
            int n = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[,] A = new int[n, n + 3];
            int[,] A1 = new int[n, n + 3];
            int[,] A2 = new int[n, n + 3];
            int[,] B2 = new int[n, n + 3];
            double[] b = new double[n];
            double[] y1 = new double[n];
            double[] b1 = new double[n];
            double[,] c1 = new double[n, n];
            double[] y2 = new double[n];
            double[,] C2 = new double[n, n];
            double[,] Y3 = new double[n, n];
            double[,] result1 = new double[n, n];
            double[,] result2 = new double[n, n];
            double[,] result3 = new double[n, n];
            double[,] result4 = new double[n, n];
            double[,] x = new double[n, n];

            //Перший ряд Діаграми A1,b1,C1,A2,B2,C2,b,A           
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A1[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                b1[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    c1[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A2[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B2[i, j] = rand.Next(0, 11);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    C2[i, j] = 1 / (Math.Pow((double)i + 1, 1) + Math.Pow((double)j + 1, 2));
                }
            }
            for (int i = 0; i < n; i++)
            {
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3) + 3);
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    A[i, j] = rand.Next(0, 11);
                }
            }

            //Другий рядок діаграми
            Thread thread21 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {

                    for (int j = 0; j < n; j++)
                    {
                        y2[i] = A1[i, j] * (b1[i] + 4 * c1[i, j]);
                    }
                }
            });
            Thread thread22 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Y3[i, j] = A2[i, j] * (B2[i, j] + C2[i, j]);
                    }
                }
            });
            Thread thread23 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        y1[i] = A[i, j] * b[i];
                    }
                }
            });
            thread21.Start();
            thread22.Start();
            thread23.Start();
            thread21.Join();
            thread22.Join();
            thread23.Join();            

            //Третій рядок діаграми
            Thread thread31 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result1[i, j] = Y3[i, j] * y2[i];
                    }
                }
            });
            Thread thread32 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result2[i, j] = Math.Pow(Y3[i, j], 3) - Y3[i, j] * Math.Pow(y1[i], 2);
                    }
                }

            });
            thread31.Start();
            thread32.Start();
            thread31.Join();
            thread32.Join();

            //Четвертий рядок діаграми
            Thread thread41 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        result3[i,j] = result1[i, j] + result2[i,j];
                    }
                }
            });
            Thread thread42 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result4[i, j] = y1[i] * y2[i] * Math.Pow(Y3[i, j], 2) * y1[i];
                    }
                }
            });
            thread41.Start();   
            thread42.Start();
            thread41.Join();
            thread42.Join();

            //П'ятий рядок діаграми
            Thread thread51 = new Thread(() =>
            {
                for(int i = 0; i < n; i++)
                {
                    for(int j = 0; j < n; j++)
                    {
                        x[i,j] = result3[i,j] + result4[i,j];
                    }
                }
            });
            thread51.Start();
            thread51.Join();

            Console.WriteLine("Введені матриці:");
                Console.WriteLine("Матриця A:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A1[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця A2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(A2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця B2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(B2[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Обчислені за формулами:");
                //1
                Console.WriteLine("Масив b:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b[i]);
                    Console.WriteLine($"b[{i}] = {result}");
                }

                Console.WriteLine("Матриця y1:");
                for (int i = 0; i < n; i++)
                {                   
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.WriteLine($"y1[{i}] = {result}");
                }
                //2
                Console.WriteLine("Масив b1:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", b1[i]);
                    Console.WriteLine($"b1[{i}] = {result}");
                }
                Console.WriteLine("Матриця c1:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", c1[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця y2:");
                for (int i = 0; i < n; i++)
                {
                    string result = string.Format("{0:f3}", y1[i]);
                    Console.WriteLine($"y2[{i}] = {result}");
                }
                //3
                Console.WriteLine("Матриця C2:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", C2[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Матриця Y3:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", Y3[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
                //x
                Console.WriteLine("Матриця x:");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        string result = string.Format("{0:f3}", x[i, j]);
                        Console.Write(result + " ");
                    }
                    Console.WriteLine();
                }
            stopwatch.Stop();
            Console.WriteLine("Час виконання програми: {0} мс", stopwatch.ElapsedMilliseconds);
        }
    }
}