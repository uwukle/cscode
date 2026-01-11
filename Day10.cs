int width = Console.WindowWidth;
int height = Console.WindowHeight / 2;
int centerY = height / 2;

double time = 0.0;

Console.Clear();
Console.CursorVisible = false;

while (true)
{
    Console.SetCursorPosition(0, 0);
    char[,] buffer = new char[width, height];

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            buffer[x, y] = ' ';
        }
    }

    for (int x = 0; x < width; x += 10)
    {
        for (int y = 0; y < height; y++)
        {
            buffer[x, y] = y == centerY ? '+' : '.';
        }
    }

    for (int y = 0; y < height; y += 5)
    {
        for (int x = 0; x < width; x++)
        {
            buffer[x, y] = x == 0 ? '+' : '.';
        }
    }

    for (int x = 0; x < width; x++)
    {
        double t = time + x * 0.1;

        int sinY = centerY + (int)(Math.Sin(t) * (height / 3));

        if (sinY >= 0 && sinY < height)
        {
            buffer[x, sinY] = '●';
        }
    }

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            Console.Write(buffer[x, y]);
        }
    }

    time += 0.1;
    await Task.Delay(32);
}
