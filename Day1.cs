Console.Write("Enter your name: ");

string? name = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name))
    throw new InvalidOperationException("Name cannot be empty!");

Console.WriteLine("Hello, {0}!", name);
