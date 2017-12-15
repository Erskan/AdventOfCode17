using System;

namespace generatorduel
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator genA = new Generator(722, 16807);
            Generator genB = new Generator(354, 48271);
            uint matches = 0;

            if (Match16Bits(genA.CurrentValue, genB.CurrentValue))
                ++matches;

            for (uint idx = 0; idx < 40000000; ++idx)
            {
                genA.Generate();
                genB.Generate();

                if (Match16Bits(genA.CurrentValue, genB.CurrentValue))
                    ++matches;
            }

            Console.WriteLine($"Total matches: {matches}");
            Console.ReadKey();
        }

        static bool Match16Bits(ulong valueA, ulong valueB)
        {
            return unchecked((ushort)valueA) == unchecked((ushort)valueB);
        }
    }
}
