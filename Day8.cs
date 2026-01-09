int width = Console.BufferWidth;
int height = Console.BufferHeight;

for (int x = 0; x < width; x++)
{
    for (int y = 0; y < height; y++)
    {
        Console.Write('█');
    }
}

int frame = 0;

while (true)
{
    Console.SetCursorPosition(frame % width, frame % height);

    Console.Write(' ');

    frame++;
    await Task.Delay(4);
}
