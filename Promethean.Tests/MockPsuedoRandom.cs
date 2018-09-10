using Promethean.Core;
using System.IO;
using System.Collections.Generic;

namespace Promethean.Tests
{
    public class MockPsuedoRandom : IPsuedoRandom
    {
        private Queue<int> _numbers;

        public MockPsuedoRandom(int number)
        {
            _numbers = new Queue<int>(new int[] { number });
        }

        public MockPsuedoRandom(params int[] numbers)
        {
            _numbers = new Queue<int>(numbers);
        }

        public int Next(int min, int max)
        {
            return _numbers.Dequeue();
        }
    }
}