﻿namespace HunterSim.Tests
{
    public class FakeStatCalculator : BaseStatCalculator
    {
        private readonly double _value;

        public FakeStatCalculator(double returnValue) => _value = returnValue;

        protected override double InstanceCalculate(SimulationState state) => _value;

        protected override double InstanceCalculate(GearItem weapon, SimulationState state) => _value;
    }
}
