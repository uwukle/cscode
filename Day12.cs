int width = Console.BufferWidth, height = Console.BufferHeight;

Console.Clear();
Console.CursorVisible = false;

int frame = 0;

while (true)
{
    double time = frame * 0.03;

    for (int x = 0; x < width - 1; x++)
    {
        for (int y = 0; y < height - 1; y++)
        {
            double
                w0 = Math.Sin(Math.Sqrt(x * x + y * y) * 0.2 - time * 3),
                w1 = Math.Sin(x * 0.15 - time * 2)
                    * Math.Cos(y * 0.1 - time * 1.5),
                w2 = Math.Sin((x + y) * 0.08 + time);

            double v = (((w0 + w1 + w2) / 3) + 1) / 2;

            Console.SetCursorPosition(x, y);
            Console.Write("░▒▓█"[(int)(v * 4)]);
        }
    }

    frame++;
    await Task.Delay(10);
}
