using System;

namespace HunterSim
{
    public class RandomGenerator
    {
        public static RandomGenerator Instance = new RandomGenerator();
        private readonly Random _random;

        public static double Roll()
        {
            return Instance.RollImplementation();
        }

        public RandomGenerator()
        {
            _random = new Random();
        }

        public RandomGenerator(int seed)
        {
            _random = new Random(seed);
        }

        private double RollImplementation()
        {
            return _random.NextDouble();
        }
    }
}
