namespace Promethean.Core.RandomGenerator
{
    public interface IPsuedoRandom
    {
        int Next(int min, int max);
        int NextOdd(int min, int max);
    }
}