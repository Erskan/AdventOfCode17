using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spiral
{
    class Program
    {
        private const int TARGET = 265149;
        static void Main(string[] args)
        {
            int ring = FindRingContainingTarget();
            Console.WriteLine($"Target is in ring nr [{ring}]");

            int pathLength = SolvePathByRingIndex(ring);
            Console.WriteLine($"The path length for target value {TARGET} is {pathLength}");

            Console.ReadKey();
        }

        private static int SolvePathByRingIndex(int ring)
        {
            int ringSides = 1 + (ring * 2);
            Console.WriteLine($"Ring sides are [{ringSides}] long.");
            int startValue = (int) Math.Pow(ringSides - 2, 2);
            int xPos = 0;
            int yPos = 0;
            char walkDirection = 'Y';
            int step = 1;
            int ringStrech = (TARGET - startValue) / (ringSides - 1);
            int currentValue = startValue + ringStrech*(ringSides - 1);
            Console.WriteLine($"Target is in {ringStrech} stretch");
            // Where are we in relation to '1' or (0, 0)?
            switch (ringStrech)
            {
                case 1:
                    yPos = -(ringSides / 2 - 1);
                    xPos = ringSides / 2;
                    walkDirection = 'Y';
                    step = 1;
                    break;
                case 2:
                    yPos = ringSides / 2;
                    xPos = ringSides / 2;
                    walkDirection = 'X';
                    step = -1;
                    break;
                case 3:
                    yPos = ringSides / 2;
                    xPos = -(ringSides / 2);
                    walkDirection = 'Y';
                    step = -1;
                    break;
                case 4:
                    yPos = -(ringSides / 2);
                    xPos = -(ringSides / 2);
                    walkDirection = 'X';
                    step = 1;
                    break;
                default:
                    Console.WriteLine("You have miscalculated. Impossible ringstretch.");
                    break;
            }
            while (true)
            {
                if (currentValue == TARGET)
                {
                    return FindPathLengthFromCoordinates(xPos, yPos);
                }
                switch (walkDirection)
                {
                    case 'Y':
                        yPos += step;
                        break;
                    case 'X':
                        xPos += step;
                        break;
                    default:
                        Console.WriteLine("Invalid walk-direction.");
                        break;
                }
                ++currentValue;
            }
        }

        private static int FindPathLengthFromCoordinates(int x, int y)
        {
            Console.WriteLine($"X from target = [{x}], Y from target = [{y}]");
            return Math.Abs(x) + Math.Abs(y);
        }

        public static int FindRingContainingTarget()
        {
            int ring = 0;
            int ringSize = 1 + (ring * 2);
            int maxRingValue = 1;
            while (maxRingValue < TARGET)
            {
                ++ring;
                ringSize = 1 + (ring * 2);
                maxRingValue = (int)Math.Pow(ringSize, 2);
            }

            return ring;
        }
    }
}
