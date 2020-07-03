using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Дан целочисленный  массив из 20 элементов.Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
 * Заполнить случайными числами.Написать программу, позволяющую найти и вывести количество пар элементов массива, 
 * в которых только одно число делится на 3. В данной задаче под парой подразумевается два подряд идущих элемента массива.
 * Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
 */
namespace Lesson41
{
    class Program
    {
        static public int CountNotThree(int [] arg)
        {
            int count = 0;
            for (int i = 0; i < arg.Length - 1; i++)
            {
                if (arg[i] % 3 == 0 && arg[i + 1] % 3 != 0) count++;
            }
            return count;
        }
        
        static void Main(string[] args)
        {
            int [] massive = new int[20];
            massive.Initialize();
            int sign = 1;
            Random random = new Random();
            for(int i =0; i < massive.Length; i++)
            {
                if(random.NextDouble() > 0.5) sign = 1;
                else sign = -1;
                massive.SetValue(random.Next(0, 10000) * sign, i);
            }
            Console.WriteLine("Вывод 20 случайных чисел от -10000 до 10000:");
            foreach(int item in massive)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nКоличество пар элементов, где только одно число кратно трем: {CountNotThree(massive)}");
            Console.ReadKey();
        }
    }
}
