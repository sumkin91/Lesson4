using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WriteReaderDoubleMassiveLibrary;
/*
*а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
 Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, 
 возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер 
 максимального элемента массива (через параметры, используя модификатор ref или out).
**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
**в) Обработать возможные исключительные ситуации при работе с файлами.
*/
namespace Lesson45
{
    class Program
    {
        static void Main(string[] args)
        {
            DoubleMassive doubleMassive = new DoubleMassive(5, 6);
            Console.WriteLine("Вывод массива рандомного от 0 до 1000");
            doubleMassive.PrintMassive();
            Console.WriteLine($"Минимальное - {doubleMassive.Min}; максимальное - {doubleMassive.Max}");
            Console.WriteLine("Запись в файл write.txt, смотри в файле");
            doubleMassive.WriteToFile("write.txt");
            Console.WriteLine("Чтение из файла writer.txt");
            DoubleMassive readerMassive = new DoubleMassive("write.txt");
            Console.WriteLine("Вывод массива считанного");
            readerMassive.PrintMassive();
            Console.WriteLine($"Сумма массива - {readerMassive.Summa()}");
            Console.ReadKey();
        }
    }
}
