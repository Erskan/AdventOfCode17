using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memory
{
    class Program
    {
        public static string FILENAME = "input.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            List<int> data = ReadFile();

            int rearranges = RedistributeMemory(data);

            Console.WriteLine($"Result: {rearranges}");
            Console.ReadKey();
        }

        private static int RedistributeMemory(List<int> data)
        {
            int rearranges = 0;
            int idx = 0;
            int currentBlock = 0;
            List<List<int>> previousStates = new List<List<int>>();
            previousStates.Add(data.GetRange(0, data.Count()));
            while (true)
            {
                for (int blockIdx = 0; blockIdx < data.Count(); ++blockIdx)
                {
                    if (data[blockIdx] > currentBlock)
                    {
                        currentBlock = data[blockIdx];
                        idx = blockIdx;
                    }
                }
                data[idx] = 0;
                // Rearrange
                for (; currentBlock > 0; --currentBlock)
                {
                    ++idx;
                    if (idx >= data.Count())
                    {
                        idx = 0;
                    }
                    data[idx] += 1;
                }

                ++rearranges;
                
                foreach (var previousState in previousStates)
                {
                    if (data.SequenceEqual(previousState))
                    {
                        return rearranges;
                    }
                }

                previousStates.Add(data.GetRange(0, data.Count()));
            }
        }

        static List<int> ReadFile()
        {
            List<int> data = new List<int>();
            try
            {
                IEnumerable<string> lines = File.ReadLines(FILENAME);
                int idx = 0;
                foreach (var line in lines)
                {
                    string[] posts = line.Split('\t');
                    foreach (var post in posts)
                    {
                        data.Add(Int32.Parse(post));
                    }
                    ++idx;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
            return data;
        }
    }
}
