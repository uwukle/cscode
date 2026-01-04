while (true)
{
    Console.Write("> ");

    string? input = Console.ReadLine();

    switch (input)
    {
        case { } when input.StartsWith("say/"):
            Console.WriteLine(input.AsSpan()[4..]);
            break;
        case "exit":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Unknown command: {0}", input);
            break;
    }
}
