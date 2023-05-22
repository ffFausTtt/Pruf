using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Resh a = new Resh();
            a.Vvod();
            a.Reshenie();
        }
    }

    internal class Resh
    {
        int[] ms1 = { }, ms2 = { };

        public void Vvod()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Pruf.csv"))
                {
                    while (sr.EndOfStream != true)
                    {
                        string
                        str1 = sr
                        .ReadLine(); // считываем в 2 строчки т.к. в условии всего 2 строчки и это самый оптимальный вариант
                        string str2 = sr.ReadLine(); // считываем 2 строку
                        ms1 = Array.ConvertAll(str1.Split(';'), int.Parse); // парсим в массив
                        ms2 = Array.ConvertAll(str2.Split(';'), int.Parse); // парсим вторую строку во второй массив
                        Debug.WriteLine("Входные данные:\n1 строка1: " + ms1.Length + "\n2 строка2: " + ms2);
                        for (int i = 0; i < ms1.Length; i++)
                        {
                            Debug.WriteLine(ms1[i]);
                        }

                        Console.WriteLine(str1);
                        Console.WriteLine(str2);
                    }
                }
            }
            catch
            {
                Debug.WriteLine("Не верно заданы входные значения");
                Environment.Exit(0);
            }
        }

        public bool Vivod(List<int> r)
        {
            try
            {
                using (StreamWriter sw =
                new StreamWriter("Pruf2.csv", false, Encoding.Default, 10))
                {
                    Debug.WriteLine("Перераспределение: ");
                    foreach (var t in r)
                    {
                        sw.Write(t + ";");
                        Debug.Write(t + ";");

                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Запись прервана: " + e.Message);
                return false;
            }
        }

        public void Reshenie()
        {
            int detal = ms1.Length;
            //Массив деталей
            int[,] mas = new int[2, detal];
            //Из одномерного в двумерный массив
            for (int i = 0; i < detal; i++)
            {
                mas[0, i] = ms1[i];
                mas[1, i] = ms2[i];
            }
            //for (int i = 0; i < mas[1, i]; i++)
            //{
            // if (ms2[i] < min)
            // {
            // min = ms2[i];

            // }
            // Console.WriteLine("Минимальный элемент: " + min);
            //}
            var result = new List<int>();


            bool f = true;
            int minElement = 0;
            while (result.Count < 8)
            {
                List<int> rr = new List<int>();
                List<int> rrr = new List<int>();
                int r = 0;
                for (var j = 0; j < ms1.Length; j++)
                {
                    for (var i = 0; i < ms1.Length; i++)
                    {
                        if (mas[0, i] == mas[1, j])
                        {
                            f = false;
                        }
                    }

                    if (f == true && mas[1, j] != 0)
                    {
                        rrr.Add(j);
                        rr.Add(mas[1, j]);
                        r++;
                    }

                    f = true;
                    try
                    {
                        minElement = rrr[0];
                    }
                    catch (Exception e)
                    {
                    }
                }

                try
                {
                    int minimumIndexInrr = rr.IndexOf(rr.Min());
                    int o = rrr[minimumIndexInrr];
                    result.Add(mas[0, o]);
                    mas[0, o] = 0;
                    mas[1, o] = 0;
                }
                catch (Exception e)
                {
                }
            }

            Console.WriteLine("Ответ");
            Vivod(result);
            foreach (var t in result)
            {
                Console.WriteLine(t);
            }
        }
    }
}