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
                dx = x - width / 2,
                dy = y - height / 2,
                dis = Math.Sqrt(dx * dx + dy * dy),
                angle = Math.Atan2(dy, dx);

            double v = (Math.Sin(angle * 6 + time)
                * Math.Sin(dis * 0.2 - time * 2)
                + Math.Cos(dis * 0.1) + 2) / 4;

            Console.SetCursorPosition(x, y);
            Console.Write("░▒▓█"[(int)(v * 4)]);
        }
    }

    frame++;
    await Task.Delay(10);
}
