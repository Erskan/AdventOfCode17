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
            Console.WriteLine("Starting jump maze...");

            int jumps = 0;
            List<int> data = ReadFile();

            jumps = CalculateJumpBeforeExit(data);
            Console.WriteLine($"Jumps until exit: [{jumps}].");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static int CalculateJumpBeforeExit(List<int> list)
        {
            int nrOfJumps = 0;
            int index = 0;
            try
            {
                while (true)
                {
                    int instruction = list[index];
                    list[index] += 1;
                    index += instruction;
                    ++nrOfJumps;
                }
            }
            catch (Exception e)
            {
                return nrOfJumps;
            }
            return nrOfJumps;
        }

        static List<int> ReadFile()
        {
            List<int> dataInts = new List<int>();
            try
            {
                IEnumerable<string> lines = File.ReadLines(FILENAME);
                foreach (var line in lines)
                {
                    dataInts.Add(Int32.Parse(line));
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
