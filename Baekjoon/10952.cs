while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
        break;

    var splitedInputs = input.Split();
    var a = int.Parse(splitedInputs[0]);
    var b = int.Parse(splitedInputs[1]);

    if (a == 0 && b == 0)
        break;

    Console.WriteLine(a + b);

}