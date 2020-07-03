using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.*/

namespace Lesson44
{
    class Program
    {
        public struct Account
        {
            public string Login;
            public string Password;
        }

        static void Main(string[] args)
        {
            List<Account> listAccount = new List<Account>();
            string path = Directory.GetCurrentDirectory() + "\\file.txt";
            FileInfo info = new FileInfo(path);
            if (info.Exists)
            {
                StreamReader reader = new StreamReader(path);
                string numberString = string.Empty;
                List<string> listString = new List<string>();
                do
                {
                    numberString = reader.ReadLine();
                    if(!string.IsNullOrEmpty(numberString))
                        listString.Add(numberString);
                } while (!string.IsNullOrEmpty(numberString));
                reader.Close();
                foreach (string item in listString)
                {
                    string[] buffer = item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    listAccount.Add(new Account { Login = buffer.ElementAt(0), Password = buffer.ElementAt(1) });
                }
            }
            else { 
                Console.WriteLine("Файл не найден!!!");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Вывод логина и пароля из файла:");
            foreach(Account item in listAccount)
            {
                Console.WriteLine($"{item.Login}  {item.Password}");
            }
            Console.ReadKey();
        }
    }
}
