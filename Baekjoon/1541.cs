var input = Console.ReadLine();
Console.WriteLine(CalculateMiniestValue(input));

int CalculateMiniestValue(string expression)
{
	var strValues = expression.Split('+', '-');
	if (strValues[0] == string.Empty)
		strValues[0] = "0";

	var values = strValues.Select(int.Parse).ToArray();
	var operators = expression.Where(c => c == '+' || c == '-').ToArray();

	var sum = values[0];
	for (int i = 0; i < operators.Length; i++)
	{
		if (operators[i] == '-')
		{
			sum -= values.Skip(i + 1).Sum();
			break;
		}

		sum += values[i + 1];
	}

	return sum;
}