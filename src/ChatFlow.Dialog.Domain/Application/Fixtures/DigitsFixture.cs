using ChatFlow.Dialog.Domain.Application.Fixtures.Strategies;
using System;

namespace ChatFlow.Dialog.Domain.Application.Fixtures
{
    public class DigitsFixture
    {
        private readonly string digits;
        public IDigitsStrategy strategy;

        public DigitsFixture(string digits)
        {
            this.digits = digits;
        }

        public DigitsFixtureResult Validate()
        {
            return strategy.Validate(digits);
        }
    }

    public enum DigitsFixtureResult
    {
        Ok,
        Silence,
        Rejection,
        Incomplete
    }

    public struct CompoundDigitsFixtureResult
    {
        public DigitsFixtureResult digitsFixtureResult;
        public IDigitsStrategy type;
    }
}
