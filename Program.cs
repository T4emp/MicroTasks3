using System;
using System.Collections.Generic;

namespace MicroTasks3
{
    class Program
    {
        static void Main()
        {
            var needToContinue = true;
            while (needToContinue)
            {
                Menu();
                Console.WriteLine("Начать заново? (Ent)");
                var key = Console.ReadKey().Key;
                do
                {
                    if (key == ConsoleKey.Escape)
                    {
                        needToContinue = false;
                    }
                    else if (key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("Неправильная клавиша! Начать заного? (Ent)");
                        key = Console.ReadKey().Key;
                    }
                }
                while (needToContinue && key != ConsoleKey.Enter);
                Console.Clear();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Номер задачи: ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    First();
                    break;
                case 2:
                    Second();
                    break;
            }
        }

        public static void First()
        {
            int tr1 = 0, tr2 = 0, sp = 0;
            Console.WriteLine("Введите условия задачи:\nst - Standart\nmod - Modified");
            string s1 = Console.ReadLine();
            if(s1 == "st")
            {
                tr1 = 40; tr2 = 60; sp = 3;
            }
            else if(s1 == "mod")
            {
                Console.WriteLine("Трамваев, обгонявшего человека:");
                tr1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Встречные трамваи:");
                tr2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Скорость человека:");
                sp = Convert.ToInt32(Console.ReadLine());
            }
            //Допустим x = 2
            int x = 2;
            //(x - sp) / (x + sp) = tr1 / tr2  =>
            //tr2 * (x - sp) = tr1 * (x + sp)  =>
            //tr2 * x - tr2 * sp = tr1 * x + tr1 * sp  =>
            //tr2 * x - tr2 * sp - (-tr1 / x) - (-tr1 / sp)
            //Вместо x умножаем все на 2
            //tr2 * x - tr2 * sp * x - tr1 * x - tr1 * sp * x
            //Разделяем на две части, temp1 = где были x, temp2 = без x
            int temp1 = -(tr2 * x - tr1 * x);
            int temp2 = -(tr2 * sp * x) - tr1 * sp * x;
            //По сути получаем ЧислоX = Число
            Console.WriteLine($"Средняя скорость трамвая: {temp2 / temp1} км/ч");
        }

        public static void Second()
        {
            var values1 = new List<double> { 123, 142, 125, 154, 133, 119, 148 };
            var values2 = new List<double> { 134, 142, 163, 127, 142, 155, 120 };
            Console.WriteLine($"Корреляция Спирмена равна: {Pearson(values1, values2)}");
        }

        public static double Pearson(IEnumerable<double> dataA, IEnumerable<double> dataB)
        {
            int num = 0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            using (IEnumerator<double> enumerator = dataA.GetEnumerator())
            {
                using (IEnumerator<double> enumerator2 = dataB.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (!enumerator2.MoveNext())
                        {
                            throw new ArgumentOutOfRangeException("dataB", "Аргументы массива должны иметь одинаковую длину.");
                        }
                        double num7 = enumerator.Current;
                        double num8 = enumerator2.Current;
                        double num9 = num7 - num3;
                        double num10 = num9 / (double)(++num);
                        double num11 = num8 - num4;
                        double num12 = num11 / (double)num;
                        num3 += num10;
                        num4 += num12;
                        num5 += num10 * num9 * (double)(num - 1);
                        num6 += num12 * num11 * (double)(num - 1);
                        num2 += num9 * num11 * (double)(num - 1) / (double)num;
                    }
                    if (enumerator2.MoveNext())
                    {
                        throw new ArgumentOutOfRangeException("dataA", "Аргументы массива должны иметь одинаковую длину.");
                    }
                }
            }
            return num2 / Math.Sqrt(num5 * num6);
        }
    }
}