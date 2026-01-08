const int scale = 15;
const int delay = 25;

Random random = new();

Console.Clear();
Console.CursorVisible = false;

int frame = 0;

while (true)
{
    int width = Console.BufferWidth;
    int height = Console.BufferHeight;

    for (int x = 0; x < width; x++)
    {
        int shift = (int)(Math.Tan(x) * 256);
        int current = (frame + shift) % (height + scale);

        for (int y = 0; y < height; y++)
        {
            Console.SetCursorPosition(x, y);

            char chr;

            if ((current < scale && y < current)
                || (current >= scale && y >= current - scale && y < current))
            {
                chr = (char)random.Next(0x1E00, 0x1F00);
            }
            else
            {
                chr = ' ';
            }

            Console.Write(chr);
        }
    }

    frame++;
    await Task.Delay(delay);
}
