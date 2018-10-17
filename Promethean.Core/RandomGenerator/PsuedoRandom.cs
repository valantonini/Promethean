using System;

namespace Promethean.Core.RandomGenerator
{
    public class PsuedoRandom : IPsuedoRandom
    {
        private Random _random;

        public PsuedoRandom(int seed)
        {
            _random = new Random(seed);
        }

        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }

        public int NextOdd(int min, int max)
        {
            var next = _random.Next(min, max);
            if (next % 2 != 0)
            {
                return next;
            }

            return next < max ? next + 1 : next - 1;
        }
    }
}