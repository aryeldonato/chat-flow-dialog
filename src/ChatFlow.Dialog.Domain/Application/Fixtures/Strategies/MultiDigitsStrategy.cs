namespace ChatFlow.Dialog.Domain.Application.Fixtures.Strategies
{
    public class MultiDigitsStrategy : IDigitsStrategy
    {
        public MultiDigitsStrategy(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }

        public DigitsFixtureResult Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return DigitsFixtureResult.Silence;

            if (input.Length < Min)
                return DigitsFixtureResult.Incomplete;

            if (input.Length >= Min && input.Length <= Max)
                return DigitsFixtureResult.Ok;

            return DigitsFixtureResult.Rejection;
        }

        public CompoundDigitsFixtureResult ValidateV2(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Silence, type = this };

            if (input.Length < Min)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Incomplete, type = this };

            if (input.Length >= Min && input.Length <= Max)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Ok, type = this };

            return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Rejection, type = this };
        }
    }
}
