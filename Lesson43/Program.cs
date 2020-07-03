using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyLibArray; //библиотека
/*а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного 
 * размера и заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое 
 * возвращает сумму элементов массива, метод Inverse, возвращающий новый массив с измененными знаками у всех 
 * элементов массива (старый массив, остается без изменений),  метод Multi, умножающий каждый элемент массива 
 * на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
б)** Создать библиотеку содержащую класс для работы с массивом. Продемонстрировать работу библиотеки
е) *** Подсчитать частоту вхождения каждого элемента в массив (коллекция Dictionary<int,int>)
*/
namespace Lesson43
{
    class Program
    {
        static public void PrintElements(int [] arg)
        {
            foreach (int item in arg)
                Console.Write($"{item} ");
            Console.Write("\n");
        } 
        static void Main(string[] args)
        {
            //1
            MyArray myArray = new MyArray();
            Console.WriteLine("\nИнвертированный массив:");
            PrintElements(myArray.Inverse());
            Console.WriteLine("Введите множитель:");
            int factor = 0;
            while (Int32.TryParse(Console.ReadLine(), out factor) != true)
            {
                Console.WriteLine("Повторите ввод, должно быть значение!");
            }
            Console.WriteLine($"Массив, умноженный на {factor}:");
            PrintElements(myArray.Multi(factor));
            //2
            (int number, int count)  = myArray.MaxCount();
            Console.WriteLine($"Максимальное значение исходного массива - {number}, максимальное число максимальных значений - {count}");
            
            //3 Cловарь
            Dictionary<int, int> dict = new Dictionary<int, int>();//key,value
            int[] mas = myArray.Massive;
            int i = 0;
            while (i <mas.Length)
            {
                if (!dict.ContainsKey(mas[i])) dict.Add(mas[i], 1);
                else dict[mas[i]] += 1; 
                i++;
            }
            foreach(KeyValuePair<int,int> pair in dict)
            {
                Console.WriteLine($"Значение {pair.Key} повторяется {pair.Value} раз");
            }
            
            Console.ReadKey();
        }
    }
}
