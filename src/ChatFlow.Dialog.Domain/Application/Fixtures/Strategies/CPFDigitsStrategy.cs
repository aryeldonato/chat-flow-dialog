namespace ChatFlow.Dialog.Domain.Application.Fixtures.Strategies
{
    public class CPFDigitsStrategy : IDigitsStrategy
    {
        public CPFDigitsStrategy()
        {
            Min = 11;
            Max = 11;
        }

        public int Min { get; }
        public int Max { get; }

        public DigitsFixtureResult Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
                return DigitsFixtureResult.Silence;

            if (input.Length < 11)
                return DigitsFixtureResult.Incomplete;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempinput;
            string digito;
            int soma;
            int resto;

            input = input.Trim();
            input = input.Replace(".", "").Replace("-", "");

            tempinput = input.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempinput[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempinput += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempinput[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return input.EndsWith(digito) == true ? DigitsFixtureResult.Ok : DigitsFixtureResult.Rejection;
        }

        public CompoundDigitsFixtureResult ValidateV2(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Silence, type = this };

            if (input.Length < 11)
                return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Incomplete, type = this };

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempinput;
            string digito;
            int soma;
            int resto;

            input = input.Trim();
            input = input.Replace(".", "").Replace("-", "");

            tempinput = input.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempinput[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempinput += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempinput[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return input.EndsWith(digito) == true ?
                new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Ok, type = this } :
                new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Rejection, type = this }; ;
        }
    }
}
