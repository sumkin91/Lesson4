using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Реализуйте задачу 1 в виде статического класса StaticClass;
а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
б) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
в)** Добавьте обработку ситуации отсутствия файла на диске.
*/
namespace Lesson42
{
    static class StaticClass
    {
        
        static public int CountInputNumber()
        {
            int i = 0;
            int[] massive = new int[20];
            while (i < massive.Length)
            {
                int value = 0;
                Console.Write($"{i+1}) ");
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    massive[i] = value;
                    i++;
                }
                else Console.WriteLine("Это не значение, повторите попытку!");
            }
            return CountNotThree(massive);
        }

        static public int CountNotThree(int[] arg)
        {
            int count = 0;
            for (int i = 0; i < arg.Length - 1; i++)
                if (arg[i] % 3 == 0 && arg[i + 1] % 3 != 0) count++;
            return count;
        }

        static public int CountReadFile()
        {
            List<int> outList = new List<int>();
            int value = 0;
            string path = Directory.GetCurrentDirectory() + "\\file.txt";
            FileInfo info = new FileInfo(path);
            if (info.Exists)
            {
                StreamReader reader = new StreamReader(path);
                string numberString = reader.ReadToEnd();
                string[] massiveString = numberString.Split(new string[] { " " },StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in massiveString)
                    if (Int32.TryParse(item, out value))
                    {
                        Console.Write($"{value} ");
                        outList.Add(value);
                    }
            }
            else Console.WriteLine("Файл не найден!!!");
            
            //преобразование списка в массив
            if (outList.Count != 0)
            {
                int[] arg = new int[outList.Count];
                for (int i = 0; i < outList.Count; i++) 
                    arg[i] = outList.ElementAt(i);
                return CountNotThree(arg);
            }
            else return 0;
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите 20 значений:");
            Console.WriteLine($"Количество пар элементов, где только одно число кратно трем: {StaticClass.CountInputNumber()}");
            Console.WriteLine("\nСчитывание данных из файла file.txt:");
            Console.WriteLine($"\nКоличество пар элементов из файла, где только одно число кратно трем: {StaticClass.CountReadFile()}");
            Console.ReadKey();
        }
    }
}
