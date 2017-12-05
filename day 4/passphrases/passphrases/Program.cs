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
            Console.WriteLine("Starting passphrases...");
            int validCount = 0;
            List<List<string>> data = ReadFile();
            Console.WriteLine($"Going over {data.Count()} passphrases.");
            foreach (var datum in data)
            {
                if (!datum.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key)
                    .Any())
                {
                    ++validCount;
                }
            }
            

            Console.WriteLine($"There are {validCount} valid passphrases.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static List<List<string>> ReadFile()
        {
            List<List<string>> data = new List<List<string>>();
            try
            {
                IEnumerable<string> lines = File.ReadLines(FILENAME);
                int idx = 0;
                foreach (var line in lines)
                {
                    data.Add(new List<string>());
                    string[] posts = line.Split(' ');
                    foreach (var post in posts)
                    {
                        data[idx].Add(post);
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
