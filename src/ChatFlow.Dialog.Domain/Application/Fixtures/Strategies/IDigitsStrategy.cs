namespace ChatFlow.Dialog.Domain.Application.Fixtures.Strategies
{
    public interface IDigitsStrategy
    {
        int Min { get; }
        int Max { get; }
        public DigitsFixtureResult Validate(string input);

        public CompoundDigitsFixtureResult ValidateV2(string input);
    }
}
