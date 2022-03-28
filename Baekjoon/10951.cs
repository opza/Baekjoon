while (true)
{
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
        return;

    var splitedInputs = input.Split();
    var a = int.Parse(splitedInputs[0]);
    var b = int.Parse(splitedInputs[1]);

    Console.WriteLine(a + b);

}