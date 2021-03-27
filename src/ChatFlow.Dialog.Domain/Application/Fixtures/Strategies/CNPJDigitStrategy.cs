namespace ChatFlow.Dialog.Domain.Application.Fixtures.Strategies
{
	public class CNPJDigitStrategy : IDigitsStrategy
	{
		public CNPJDigitStrategy()
		{
			Min = 14;
			Max = 14;
		}

		public int Min { get; }
		public int Max { get; }

		public DigitsFixtureResult Validate(string input)
		{
			if (string.IsNullOrEmpty(input))
				return DigitsFixtureResult.Silence;

			if (input.Length < 14)
				return DigitsFixtureResult.Incomplete;

			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempinput;
			input = input.Trim();
			input = input.Replace(".", "").Replace("-", "").Replace("/", "");

			tempinput = input.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempinput[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempinput += digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempinput[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return input.EndsWith(digito) == true ? DigitsFixtureResult.Ok : DigitsFixtureResult.Rejection;
		}

		public CompoundDigitsFixtureResult ValidateV2(string input)
		{
			if (string.IsNullOrEmpty(input))
				return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Silence, type = this };

			if (input.Length < 14)
				return new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Incomplete, type = this };

			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempinput;
			input = input.Trim();
			input = input.Replace(".", "").Replace("-", "").Replace("/", "");

			tempinput = input.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempinput[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempinput += digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempinput[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return input.EndsWith(digito) == true ?
				new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Ok, type = this } :
				new CompoundDigitsFixtureResult { digitsFixtureResult = DigitsFixtureResult.Rejection, type = this }; ;
		}
	}

}
