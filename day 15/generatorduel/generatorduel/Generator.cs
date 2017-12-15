using System;
using System.Collections.Generic;
using System.Text;

namespace generatorduel
{
    public class Generator
    {
        public ulong CurrentValue { get; set; }
        public ulong Factor { get; set; }
        public const ulong Divisior = 2147483647;
        public Generator(ulong seed, ulong factor)
        {
            Factor = factor;
            CurrentValue = (seed * Factor) % Divisior;
        }

        public ulong Generate()
        {
            CurrentValue = (CurrentValue * Factor) % Divisior;
            return CurrentValue;
        }
    }
}
