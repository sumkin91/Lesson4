using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WriteReaderDoubleMassiveLibrary
{
    public class DoubleMassive
    {
        int[,] massive;
        int first;
        int second;
        public DoubleMassive(int first, int second)
        {
            this.first = first;
            this.second = second;
            massive = new int[first, second];
            Random rand = new Random();
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++) massive[f, s] = rand.Next(0, 1000);
            }
        }

        public DoubleMassive(string file)
        {
            int bufferFirstIndex = 0;
            int bufferSecondIndex = 0;
            List<string[]> list = new List<string[]>();
            StreamReader reader = new StreamReader(file);
            do
            {
                string row = reader.ReadLine();
                list.Add(row.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
                bufferFirstIndex++;
            } while (!reader.EndOfStream);
            reader.Close();
            foreach (string[] item in list)
            {
                if (bufferSecondIndex < item.Length) bufferSecondIndex = item.Length;
            }
            first = bufferFirstIndex;
            second = bufferSecondIndex;

            massive = new int[first, second];
            int result = 0;
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++)
                {
                    if (Int32.TryParse(list.ElementAt(f).ElementAt(s), out result))
                        massive[f, s] = result;
                    else massive[f, s] = 0;
                }
            }
        }

        public void WriteToFile(string file)
        {
            StreamWriter writer = new StreamWriter(file);
            List<string> list = new List<string>();
            for (int f = 0; f < first; f++)
            {
                string row = string.Empty;
                for (int s = 0; s < second; s++) row += $"{massive[f, s]} ";
                list.Add(row);
            }
            foreach (string item in list) writer.WriteLine(item);
            writer.Close();
        }

        public int Summa()
        {
            int retSum = 0;
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++) retSum += massive[f, s];
            }
            return retSum;
        }

        private List<int> GetList()
        {
            List<int> list = new List<int>();
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++) list.Add(massive[f, s]);
            }
            list.Sort();
            return list;
        }

        public int Min => GetList().ElementAt(0);

        public int Max => GetList().ElementAt(first * second - 1);

        public void IndexMaxNumber(out int firstIndex, out int secondIndex)
        {
            firstIndex = 0;
            secondIndex = 0;
            int maxNumber = this.Max;
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++)
                {
                    if (maxNumber == massive[f, s]) (firstIndex, secondIndex) = (f, s);
                }
            }
        }
        public void Print(string str)
        {
            Console.WriteLine(str);
        }
        public void PrintMassive()
        {
            for (int f = 0; f < first; f++)
            {
                for (int s = 0; s < second; s++)
                {
                    Console.Write($"{massive[f,s]}\t");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
    }
}
