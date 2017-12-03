using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checksum
{
    class Program
    {
        private const string FILENAME = "input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Starting corruption checksum...");

            long checksum = 0;
            List<List<int>> data = ReadFile();
            checksum = CalculateChecksum(data, checksum);

            Console.WriteLine($"Calculated checksum to: [{checksum}].");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static long CalculateChecksum(List<List<int>> data, long checksum)
        {
            foreach (var row in data)
            {
                int divisionResult = 0;

                foreach (var cell in row)
                {
                    foreach (var compareCell in row)
                    {
                        if (cell != compareCell && cell % compareCell == 0)
                        {
                            divisionResult = cell / compareCell;
                            Console.WriteLine($"Division {cell} / {compareCell} = {divisionResult}");
                            break;
                        }
                    }
                    if (divisionResult != 0)
                        break;
                }
                checksum += divisionResult;
            }
            return checksum;
        }

        static List<List<int>> ReadFile()
        {
            List<List<int>> dataInts = new List<List<int>>();
            try
            {
                IEnumerable<string> lines = File.ReadLines(FILENAME);
                int idx = 0;
                foreach (var line in lines)
                {
                    dataInts.Add(new List<int>());
                    string[] posts = line.Split('\t');
                    foreach (var post in posts)
                    {
                        dataInts[idx].Add(Int32.Parse(post));
                    }
                    ++idx;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return dataInts;
        }
    }
}
