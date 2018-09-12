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
    }
}