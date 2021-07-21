using System.Collections.Generic;
using System.Linq;

namespace HunterSim.Tests
{
    public class FakeRandomGenerator : RandomGenerator
    {
        private readonly IList<double> _values;

        public FakeRandomGenerator(params double[] values) => _values = new List<double>(values);

        protected override double RollImplementation()
        {
            if (_values.Any())
            {
                var result = _values.First();
                _values.RemoveAt(0);
                return result;
            }

            return 0.0;
        }
    }
}
