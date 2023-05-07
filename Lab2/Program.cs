using System;
using System.Threading;

namespace ThreadCalculationulation
{
    public class Program
    {
        static void Main(string[] args)
        {            
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
                b[i] = 4 / ((double)Math.Pow((double)i + 1, 3)+ 3);
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
                    y2[i] += A1[i, j] * (b1[j] + 4 * c1[i,j]);
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
                    C2[i, j] = 1 / (Math.Pow((double)i + 1,1) + Math.Pow((double)j + 1, 2));
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
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
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
                Console.WriteLine($"b[{i}] = {b[i]}");
            }

            Console.WriteLine("Матриця y1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(y1[i] + " ");
                }
                Console.WriteLine();
            }
            //2
            Console.WriteLine("Масив b1:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"b[{i}] = {b1[i]}");
            }
            Console.WriteLine("Матриця c1:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(c1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця y2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(y2[i] + " ");
                }
                Console.WriteLine();
            }
            //3
            Console.WriteLine("Матриця C2:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(C2[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Матриця Y3:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(Y3[i, j] + " ");
                }
                Console.WriteLine();
            }
            //x
            Console.WriteLine("Матриця x:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(x[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}