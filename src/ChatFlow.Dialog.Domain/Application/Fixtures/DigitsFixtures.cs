using ChatFlow.Dialog.Domain.Application.Fixtures.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace ChatFlow.Dialog.Domain.Application.Fixtures
{
    public class DigitsFixtures
    {
        private readonly string digits;
        public List<IDigitsStrategy> strategies;

        public DigitsFixtures(string digits)
        {
            this.digits = digits;

            strategies = new List<IDigitsStrategy>();
        }

        public CompoundDigitsFixtureResult Validate()
        {
            if (string.IsNullOrEmpty(digits))
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Silence };

            int digitsInput = digits.Length;
            int minRequiredLenth = strategies
                .OrderBy(c => c.Min)
                .First()
                .Min;

            if (digitsInput < minRequiredLenth)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Incomplete };

            foreach (var item in strategies)
            {
                var result = item.ValidateV2(digits);
                if (result.digitsFixtureResult == DigitsFixtureResult.Ok)
                    return result;
            }

            minRequiredLenth = strategies
                .Where(c => c.Min > 1)
                .OrderBy(c => c.Min)
                .First()
                .Min;

            if (digitsInput < minRequiredLenth)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Incomplete };

            return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Rejection };
        }
    }
}
