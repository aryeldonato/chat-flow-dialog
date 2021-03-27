namespace ChatFlow.Dialog.Domain.Application.Fixtures.Strategies
{
    public class SingleDigitStrategy : IDigitsStrategy
    {
        private readonly string _digits;

        public SingleDigitStrategy(string digits)
        {
            this._digits = digits;
            Min = 1;
            Max = 1;
        }

        public int Min { get; }
        public int Max { get; }

        public DigitsFixtureResult Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return DigitsFixtureResult.Silence;

            if (_digits == input)
                return DigitsFixtureResult.Ok;

            return DigitsFixtureResult.Rejection;
        }

        public CompoundDigitsFixtureResult ValidateV2(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Silence, type = this };

            if (_digits == input)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Ok, type = this };

            return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Rejection, type = this };
        }
    }
}
