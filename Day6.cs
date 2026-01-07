Console.WriteLine("Sosal?");

(int left, int top) = Console.GetCursorPosition();

string? input = Console.ReadLine();

if (input is "no")
{
    Console.SetCursorPosition(left, top);
    Console.WriteLine("Sovri!");
    Console.WriteLine(input);
}

Console.WriteLine("Nice! UwU");
