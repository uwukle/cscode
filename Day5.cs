const string text = "Hello, World!";

Random random = new();

(int left, int top) = Console.GetCursorPosition();

Console.CursorVisible = false;

for (int i = 0; i < text.Length; i++)
{
    for (int j = 0; j < 10; j++)
    {
        Console.SetCursorPosition(left + i, top);
        Console.Write((char)random.Next(0x4E00, 0x4F00));

        await Task.Delay(25);
    }

    Console.SetCursorPosition(left + i, top);
    Console.Write(text[i]);

    await Task.Delay(15);
}

Console.WriteLine();
Console.CursorVisible = true;
