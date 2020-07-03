using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibArray
{
    public class MyArray
    {
        int[] a;
        public MyArray()
        {
            int count = 0;
            Print("Введите количество элементов в массиве:");
            while (Int32.TryParse(Console.ReadLine(), out count) != true)
            {
                Print("Повторите ввод, должно быть значение!");
            }
            a = new int[count];
            for (int i = 0; i < a.Length; i++)
                a[i] = i + 3;
            Print("Полученный массив:");
            PrintArray();
        }

        public int[] Massive => a;

        public int Length => a.Length;

        public int Sum
        {
            get
            {
                int sum = 0;
                foreach (int el in a) sum += el;
                return sum;
            }
        }

        public int[] Inverse()
        {
            int[] inverse = new int[a.Length];
            a.CopyTo(inverse, 0);
            for (int i = 0; i < inverse.Length; i++) inverse[i] *= -1;
            return inverse;
        }

        public int[] Multi(int factor)
        {
            int[] multi = new int[a.Length];
            a.CopyTo(multi, 0);
            for (int i = 0; i < multi.Length; i++) multi[i] *= factor;
            return multi;
        }

        public (int, int) MaxCount()
        {
            int number = 0;
            int count = 1;
            List<int> list = new List<int>();
            for(int i =0;i< a.Length; i++) list.Add(a[i]);
            list.Sort();
            number = list.ElementAt(list.Count-1);
            for(int i = list.Count-2; i<0; i--)
            {
                if (number == list.ElementAt(i)) count++;
            }
            return (number, count);
        }

        public int Max => a[a.Length - 1];

        public int Min => a[0];

        public void PrintArray()
        {
            foreach (int el in a)
                Console.Write($"{el} ");
        }
        public void Print(string msg)
        {
            Console.WriteLine(msg);
        }

    }
}
